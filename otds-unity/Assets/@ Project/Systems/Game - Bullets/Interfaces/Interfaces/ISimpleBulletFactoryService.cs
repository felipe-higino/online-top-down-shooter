using System;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    public interface ISimpleBulletFactoryService
    {
        void TryFactoryContextBullet();
    }

    public interface ISimpleBulletFactoryServiceParameters
    {
        GameObject BulletPrefab { get; }
        Transform BulletSpawnLocation { get; }
        //TODO: remove
        ILifetimeChronometerParams ChronometerParams { get; }
    }

}