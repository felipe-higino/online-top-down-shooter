using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    public interface IBulletSpawner
    {
        /// <summary>
        /// Responsible for bullet positioning, instantiation and lifecycle
        /// </summary>
        void SpawnNewBullet();
    }

}