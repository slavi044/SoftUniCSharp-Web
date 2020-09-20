namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public string GetTime => stopwatch.Elapsed.ToString().Substring(3);

        public List<string> Laps;

        public string Lap()
        {
            TimeSpan time = stopwatch.Elapsed;
            string lap = time.ToString();
            Laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            stopwatch.Reset();
            Laps.Clear();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public string GetLaps()
        {
            string laps = "";

            for (int i = 1; i < Laps.Count + 1; i++)
            {
                if (i < 10)
                {
                    laps += $"0{i}. {Laps[i - 1]}{Environment.NewLine}";
                }
                else
                {
                    laps += $"{i}. {Laps[i - 1]}{Environment.NewLine}";
                }
            }

            return laps.TrimEnd();
        }
    }
}
