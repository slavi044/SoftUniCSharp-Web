namespace Chronometer
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            Chronometer chronometer = new Chronometer();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    Console.WriteLine(chronometer.GetLaps());
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                else if (command == "exit")
                {
                    break;
                }
            }
        }
    }
}
