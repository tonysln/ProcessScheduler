using System;
using System.Collections;
using System.Linq;
using System.Drawing;

/// <summary>
/// Protsessoriaja planeerimise algoritmide töö visualiseerimine
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace ProcessScheduler
{
    class Scheduler
    {
        public ArrayList TaskList { get; }
        public ArrayList TaskHistory { get; }
        private readonly Color[] colors;

        public Scheduler()
        {
            TaskList = new ArrayList();
            TaskHistory = new ArrayList();

            // Req: 12 tasks max., so 12 distinct colors (will crash if more tasks found)
            colors = new Color[12] { Color.DarkRed,  Color.Red, Color.Orange, Color.Yellow, 
                                     Color.Green, Color.SpringGreen, Color.Cyan, Color.Blue, 
                                     Color.DarkBlue, Color.BlueViolet, Color.Purple, Color.DarkGray};
        }


        public void FCFS()
        {
            // Req: tasks arrive one after another, so they can be handled incrementally.
            Task current;
            for (int tick = 0, i = 0; tick <= 50; tick++)
            {
                if (i >= TaskList.Count) { return; } // End of task list.

                // Get a task, starting from the first one (index 0).
                current = (Task)TaskList[i];

                // History keeps track of all tasks on every tick (for easier drawing)
                if (current.Running) TaskHistory.Add(current);

                // Exit tick, finish the task and continue.
                if (current.Running && tick == current.Exit)
                {
                    current.WaitTime = current.Start - current.ArrivalTime;
                    current.Running = false;
                    i++; // move on to next task
                    tick--; // restart this tick with the new task
                    continue;
                }
                
                // If it doesn't start right away, move on (next tick).
                if (current.ArrivalTime > tick) {
                    TaskHistory.Add(new Task(0, 0, "P0", Color.White)); // Add an empty task
                    continue; 
                }

                // Now it should start running, set the start tick (only if not running yet).
                current.Start = current.Running ? current.Start : tick;
                // It should complete at (starting tick + burst time)
                current.Exit = current.Start + current.BurstTime;
                // In FCFS, tasks are not cut off.
                current.Turnaround = current.Exit;
                current.Running = true;
            }

        }


        public void SRTF()
        {
            // If a new task with less burst time arrives, the current one gets queued.
            // If a task with the same burst time arrives, the current one gets to finish.
            Task current;
            for (int tick = 0, i = 0; tick <= 50; tick++)
            {
                if (i >= TaskList.Count) { return; } // End of task list.

                // Get a task, starting from the first one (index 0).
                current = (Task)TaskList[i];
                // If there is no active task at the moment, move on to the next tick.
                if (!current.Running && current.ArrivalTime > tick) {
                    TaskHistory.Add(new Task(0, 0, "P0", Color.White)); // Add an empty task
                    continue; 
                }

                // Now the task must start at the current tick
                current.Start = current.Running ? current.Start : tick;
                current.Running = true;

                // Check if any other tasks arrive at this tick
                for (int j = i + 1; j < TaskList.Count; j++)
                {
                    Task other = (Task)TaskList[j];
                    // If the arrival time is < current tick, it's an unfinished task from before so ignore it
                    if (other.ArrivalTime < tick) continue;
                    // If the arrival time is > current tick, there's no reason to continue this loop
                    if (other.ArrivalTime > tick) break;
                    // If there is a new task at the current tick and its burst time is shorter than current,
                    // cut off the current task and complete it after the new one.
                    if (other.ArrivalTime == tick && other.BurstTime < current.Remaining) 
                    {
                        TaskList.Insert(i, other);
                        TaskList.RemoveAt(j + 1); // j + 1 because now the list is (n+1) and items have shifted
                        current.Running = false; 
                        tick--; // roll back the tick so it can start over with the new task
                        break;
                    } 
                }

                // This will activate during normal task execution, as opposed to a switch
                if (current.Running)
                {
                    // History keeps track of all tasks on every tick (for easier drawing)
                    TaskHistory.Add(current);
                    // Early remaining time decrease
                    current.Remaining--;
                    // Task is finished
                    if (current.Remaining <= 0)
                    {
                        current.Exit = tick + 1; // + 1 to account for the early decrease
                        current.Turnaround = current.Exit - current.ArrivalTime;
                        current.WaitTime = current.Turnaround - current.BurstTime; 
                        current.Running = false;
                        i++; // Move to the next task in the list
                        continue;
                    }

                }
            }
        }//test with 1,8;3,5;4,3;12,1;19,1


        public void RR(int quant)
        {
            // Every task <= quant (req: 4) ticks long gets completed right away,
            // all other tasks get cut off after 4 ticks and sent to the LAST position in the array,
            // so their turn comes after all the other tasks before them
            
            // Very clunky and ugly, rewrite this with a dequeue !!

            Task current;
            bool startOver = false; // helper for restarting the loop 
            for (int tick = 0, i = 0; tick <= 50; tick++)
            {
                if (i >= TaskList.Count) { return; } // End of task list.

                // Get a task, starting from the first one (index 0).
                current = (Task)TaskList[i];
                // Intended to possibly restart tasks from before 
                if (!current.Running && current.ArrivalTime > tick)
                {
                    // If there are no tasks at the current tick, search for the next available unfinished job.
                    // Rewrite this without the need for a search !!
                    for (int j = i + 1; j < TaskList.Count; j++)
                    {
                        // TODO! Should prefer tasks that are shorter even if they sit later in the list ??
                        Task other = (Task)TaskList[j];
                        if (other.ArrivalTime < tick && other.Remaining > 0)
                        {
                            // Move the unfinished job and restart the tick to start the job.
                            TaskList.Insert(i, other);
                            TaskList.RemoveAt(j + 1); // j + 1 because now the list is (n+1) and items have shifted
                            // Reset the tick and restart loop with the new task
                            tick--;
                            startOver = true; 
                            break;
                        }
                    }
                }

                // Turn off the restart signal and restart the loop
                if (startOver) { startOver = false; continue; }

                // If there is no active task at the moment, move on to the next tick
                // Intended to insert "empty ticks" when there are absolutely no tasks at all
                if (!current.Running && current.ArrivalTime > tick && current.Remaining == current.BurstTime)
                {
                    TaskHistory.Add(new Task(0, 0, "P0", Color.White)); // Add an empty task
                    continue;
                }

                // Now the task must start at the current tick
                current.Start = current.Running ? current.Start : tick;
                current.Running = true;

                if (current.Running)
                {
                    // History keeps track of all tasks on every tick (for easier drawing)
                    TaskHistory.Add(current);
                    // Early remaining time decrease
                    current.Remaining--;
                    // Count up the time for RR
                    current.Elapsed++;
                    // Task is finished
                    if (current.Remaining <= 0)
                    {
                        current.Exit = tick + 1; // + 1 to account for the early decrease
                        current.Turnaround = current.Exit - current.ArrivalTime;
                        current.WaitTime = current.Turnaround - current.BurstTime;
                        current.Running = false;
                        i++; // Move to the next task in the list
                        continue;
                    }
                    // Switch tasks, send the current one to the end of the list
                    if (current.Elapsed == quant)
                    {
                        current.Running = false;
                        current.Elapsed = 0; // reset the counter
                        TaskList.Insert(TaskList.Count, current);
                        TaskList.RemoveAt(i);
                        continue;
                    }
                }
            }

        }

        public void DoubleFCFS()
        {
            // Two queues for high and low priority tasks
            // All tasks with <= 5 ticks get into the priority queue
            // The priority queue gets to run first (in FCFS)
            // If there are no tasks left in the priority queue, the normal queue gets to work
            // If a high priority task arrives while a lower task is running, it gets CUT OFF until 
            // the higher priority task finishes
        }


        public double AvgWaitTime()
        {
            // Using LINQ to get the average of WaitTime for each Task in TaskList
            return (from Task task in TaskList select task.WaitTime).Average();
        }


        public void LoadTasks(string taskString)
        {
            // The input string does not contain ';' nor ',' or it is too long 
            // A string can have 12 tasks at most and take max. 
            // 50 ticks, so 12 * 5 (NN,NN) with ';' between tasks
            if (!taskString.Contains(";") || !taskString.Contains(",") || taskString.Length > 71) 
            { 
                throw new FormatException();
            }

            String[] tasks;

            try { tasks = taskString.Trim().Split(';'); } // Failed to split, input most likely incorrect.
            catch (FormatException) { throw; } // Re-throw the exception to the caller.

            // In case more than 12 tasks are found, throw an error.
            if (tasks.Length > 12) throw new FormatException(); 

            int i = 1;
            foreach (string task in tasks)
            {
                string[] taskParts = task.Split(',');
                Task newTask = new Task(Int32.Parse(taskParts[0]), // ArrivalTime
                                        Int32.Parse(taskParts[1]), // BurstTime
                                        ("P" + i), // Name
                                        (Color)colors[i++ - 1]); // Color (chosen from list)
                TaskList.Add(newTask);
            }
        }

        public void ClearTaskList() { TaskList.Clear(); }
        public void ClearTaskHistory() { TaskHistory.Clear(); }
    }
}
