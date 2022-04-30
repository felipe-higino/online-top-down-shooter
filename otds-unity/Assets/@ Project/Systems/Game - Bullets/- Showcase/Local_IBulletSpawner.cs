using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Interfaces;

namespace OTDS.Bullets.Client.Showcase
{
    public class Local_IBulletSpawner : MonoBehaviour, IBulletSpawner
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnPoint;

        private static GameObject _bulletContainer;
        private static GameObject BulletContainer
        {
            get
            {
                if (null == _bulletContainer)
                {
                    _bulletContainer = new GameObject("[Bullet Container]");
                }
                return _bulletContainer;
            }
        }

        public void SpawnNewBullet()
        {
            var bullet = Instantiate(prefab, BulletContainer.transform);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
        }
    }

}