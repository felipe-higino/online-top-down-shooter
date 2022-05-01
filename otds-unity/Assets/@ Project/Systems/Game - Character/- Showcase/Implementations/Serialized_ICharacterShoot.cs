using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Showcase
{

    public class Serialized_ICharacterShoot : MonoBehaviour, Interfaces.ICharacterShoot
    {
        [SerializeField] Transform bulletSpawnPoint;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float spawnInterval = 1;
        private bool isOpen = false;

        public void CloseFire()
        {
            isOpen = false;
            StopCoroutine("SpawnLoop");
        }

        public void OpenFire()
        {
            isOpen = true;
            StartCoroutine("SpawnLoop");
        }

        private IEnumerator SpawnLoop()
        {
            while (isOpen)
            {
                NewBullet();
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void NewBullet()
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }

        private void OnEnable() { }

    }

}