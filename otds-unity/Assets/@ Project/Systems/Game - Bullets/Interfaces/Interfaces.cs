using System;

namespace OTDS.Bullets.Interfaces
{
    public interface IAddForceOnSpawn
    {
        float ForceScale { get; }
    }

    public interface ILifetimeChronometerParams
    {
        float Time { get; }
    }

    public delegate void EndCallback(bool didSuccess);

    public interface ILifetimeChronometerService
    {
        /// <summary>
        /// Start timer through chronometer implementation
        /// </summary>
        /// <param name="time"></param>
        /// <param name="Start"> Start callback</param>
        /// <param name="End"> End callback: true = sucess, false: failure</param>
        /// <summary>
        void StartTimer(ILifetimeChronometerParams parameters, Action Start = null, EndCallback End = null);
    }
}