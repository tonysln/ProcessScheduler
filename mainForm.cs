using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Protsessoriaja planeerimise algoritmide töö visualiseerimine
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace ProcessScheduler
{
    public partial class mainForm : Form
    { 
        private Scheduler scheduler;
        private string algoInputString;
        private Bitmap ganttChart;

        public mainForm()
        {
            InitializeComponent();
            scheduler = new Scheduler();
            algoInputString = "";
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            taskListGrid.Columns.Add("Name", "Nimi");
            taskListGrid.Columns.Add("ArrivalTime", "Saab");
            taskListGrid.Columns.Add("BurstTime", "Kest");
            taskListGrid.Columns.Add("WaitTime", "Oote");
            taskListGrid.Columns.Add("Start", "Algus");
            taskListGrid.Columns.Add("Exit", "Lõpp");
            taskListGrid.Columns.Add("Turnaround", "Pöörd");

            Clear();
        }

        private void loadAlgoInput()
        {
            // Check if custom input is selected & copy input from the textbox
            if (customAlgo.Checked && (customAlgoTextbox.Text.Length != 0))
            {
                algoInputString = customAlgoTextbox.Text;
            }
            else
            {
                // Find the selected radio button (yes there are many better ways to do this)
                algoInputString = sampleAlgo1.Checked ? sampleAlgo1.Text :
                    (sampleAlgo2.Checked ? sampleAlgo2.Text :
                    (sampleAlgo3.Checked ? sampleAlgo3.Text : ""));
            }
        }

        private void startAlgorithm(string algorithm)
        {
            Clear();
            loadAlgoInput();

            if (String.IsNullOrEmpty(algoInputString)) return; // No input was given at all, exit.

            chosenAlgoLabel.Text = algorithm;

            // Display messagebox on error (wrong string format)
            try { scheduler.LoadTasks(algoInputString); }
            catch (FormatException)
            {
                MessageBox.Show("Vale sisend!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Algorithm switcher based on the given parameter
            switch (algorithm)
            {
                case "FCFS":
                    scheduler.FCFS();
                    break;
                case "SRTF":
                    scheduler.SRTF();
                    break;
                case "RR4":
                    scheduler.RR(4);
                    break;
                case "2xFCFS":
                    scheduler.DoubleFCFS();
                    break;
                default:
                    return;
            }

            // Draw the Gantt chart.
            DrawGantt();

            // Now calculate and display the average waiting time
            averageTimeLabel.Text = Math.Round(scheduler.AvgWaitTime(), 1).ToString();

            // Draw content to the taskListGrid
            foreach (Task task in scheduler.TaskList)
            {
                taskListGrid.Rows.Add(task.Name, task.ArrivalTime, task.BurstTime, task.WaitTime, 
                                      task.Start, task.Exit, task.Turnaround);
                taskListGrid.Sort(taskListGrid.Columns["ArrivalTime"], ListSortDirection.Ascending);
                taskListGrid.ClearSelection();
            }
        }

        private void Clear()
        {
            scheduler.ClearTaskList();
            scheduler.ClearTaskHistory();
            ganttField.Image = null;
            chosenAlgoLabel.Text = "---";
            averageTimeLabel.Text = "0.0";
            taskListGrid.Rows.Clear();
            // Collect any garbage from drawing the bitmaps
            GC.Collect();
        }

        private void DrawGantt()
        {
            ganttChart = new Bitmap(ganttField.Width, ganttField.Height);

            int taskHeight = ganttField.Height - 22; // adjust for bottom tick number row

            // Calculate the width of every tick based on their amound & to get the best possible fit
            int taskWidth = ganttField.Width / scheduler.TaskHistory.Count;

            using (Graphics gr = Graphics.FromImage(ganttChart))
            using (Brush blackBrush = new SolidBrush(Color.Black))
            {
                // Iterate through the history list, which contains info on every tick
                // Here i is used for calculating the x coordinate (increasing by taskWidth every tick)
                for (int i = 0, tick = 0; tick < scheduler.TaskHistory.Count; i += taskWidth, tick++)
                {
                    // Draw and fill a rectangle for every tick
                    Rectangle rect = new Rectangle(i, 0, taskWidth, taskHeight - 1);
                    gr.FillRectangle(new SolidBrush(((Task)scheduler.TaskHistory[tick]).Color), rect);

                    using (Pen selPen = new Pen(Color.Black))
                    {
                        gr.DrawRectangle(selPen, rect);
                    }

                    // Draw the task name 
                    string taskName = ((Task)scheduler.TaskHistory[tick]).Name;

                    // Get the task name string size to center the string in each rectangle
                    SizeF stringSize = gr.MeasureString(taskName, DefaultFont);
                    PointF stringLocation = new PointF(i + (taskWidth / 2) - (stringSize.Width / 2),
                                                       (taskHeight / 2) - (stringSize.Height / 2));

                    // Skip drawing the task name for empty slots (P0)
                    if (!taskName.Equals("P0"))
                    { 
                        gr.DrawString(taskName, DefaultFont, blackBrush, stringLocation);
                    }

                    // Draw tick numbers below the rectangles
                    PointF tickStringLocation = new PointF(i - 3, 0 + (taskHeight) + 6);
                    gr.DrawString(tick.ToString(), DefaultFont, blackBrush, tickStringLocation);
                }

                // Draw the last tick number
                gr.DrawString(scheduler.TaskHistory.Count.ToString(), DefaultFont, blackBrush,
                    new PointF(scheduler.TaskHistory.Count * taskWidth - 13, (taskHeight) + 6));

            }

            ganttField.Image = ganttChart;
        }

        // Button clicks
        private void kryptonButton1_Click(object sender, EventArgs e) { startAlgorithm("FCFS"); }
        private void kryptonButton2_Click(object sender, EventArgs e) { startAlgorithm("SRTF"); }
        private void kryptonButton3_Click(object sender, EventArgs e) { startAlgorithm("RR4"); }
        private void kryptonButton4_Click(object sender, EventArgs e) { startAlgorithm("2xFCFS"); }
        private void kryptonButton5_Click(object sender, EventArgs e) { Clear(); }
        
        // Switch to the "custom algorithm" option automatically when selecting its input textbox
        private void customAlgoTextbox_TextChanged(object sender, EventArgs e) { customAlgo.Checked = true; }
        private void customAlgoTextbox_Click(object sender, EventArgs e) { customAlgo.Checked = true; }
        private void customAlgoTextbox_Enter(object sender, EventArgs e) { customAlgo.Checked = true; }
    }
}
