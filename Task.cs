using System.Drawing;

/// <summary>
/// Protsessoriaja planeerimise algoritmide töö visualiseerimine
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace ProcessScheduler
{
    class Task
    {
        public string Name { get; }
        public int ArrivalTime { get; }
        public int BurstTime { get; set; }
        public int WaitTime { get; set; }
        public int Start { get; set; }
        public int Exit { get; set; }
        public int Remaining { get; set; }
        public int Turnaround { get; set; }
        public bool Running { get; set; }
        public Color Color { get; set; }
        public int Elapsed { get; set; }

        public Task(int arrivalTime, int burstTime, string name, Color color)
        {
            this.ArrivalTime = arrivalTime;
            this.BurstTime = burstTime;
            this.Name = name;
            this.Remaining = burstTime;
            this.Running = false;
            this.Color = color;
        }

        public override string ToString()
        {
            return this.Name + " [Arrive = " + this.ArrivalTime + ", Burst = " + this.BurstTime 
                + ", Start = " + this.Start + ", Exit = " + this.Exit 
                + ", Wait = " + this.WaitTime + ", Turn = " + this.Turnaround + "]";
        }
    }
}
