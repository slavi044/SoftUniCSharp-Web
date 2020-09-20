namespace Chronometer
{
    using System.Collections.Generic;

    public interface IChronometer
    {
        string GetTime { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
