using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Interfaces
{
    /// <summary>
    /// service responsible for spawning a bullets, called by player client
    /// /// </summary>
    public interface IBulletSpawnerService
    {
        void SpawnBullet(Transform location, GameObject bulletPrefab);
    }
}