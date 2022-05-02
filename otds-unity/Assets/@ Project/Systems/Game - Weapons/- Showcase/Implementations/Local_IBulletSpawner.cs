using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class Local_IBulletSpawner : MonoBehaviour, Interfaces.IBulletSpawnerService
    {
        public void SpawnBullet(Transform location, GameObject bulletPrefab)
        {
            Instantiate(bulletPrefab, location.position, location.rotation);
        }
    }
}