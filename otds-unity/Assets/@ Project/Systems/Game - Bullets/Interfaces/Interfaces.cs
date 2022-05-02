using System;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    // ------------  simple Bullet Factory
    public interface ISimpleBulletFactoryServiceParameters
    {
        GameObject BulletPrefab { get; }
        Transform BulletSpawnLocation { get; }
        ILifetimeChronometerParams ChronometerParams { get; }
        IAddBulletImpulseServiceParams ImpulseParams { get; }
    }

    public interface ISimpleBulletFactoryService
    {
        void FactoryContextBullet();
    }

    // ------------ bullet impulse 
    //TODO: remove
    public interface IAddBulletImpulseServiceParams
    {
        float ForceScale { get; }
        Rigidbody2D Rigidbody { get; set; }
    }

    //TODO: remove
    public interface IAddBulletImpulseService
    {
        void AddBulletImpulse(IAddBulletImpulseServiceParams parameters);
    }

    // ------------ lifetime chronometer
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