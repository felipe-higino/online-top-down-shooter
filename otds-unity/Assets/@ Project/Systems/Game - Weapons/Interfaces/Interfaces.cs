using System;
using UnityEngine;

namespace OTDS.Weapons.Interfaces
{
    public interface IKnifeAttack
    {
        void SingleAttack(Data.KnifeData data, Action Start, Action End);
    }

    /// <summary>
    /// service responsible for spawning a bullets, called by player client
    /// </summary>
    public interface IBulletSpawnerService
    {
        void SpawnBullet(Transform location, GameObject bulletPrefab);
    }
}