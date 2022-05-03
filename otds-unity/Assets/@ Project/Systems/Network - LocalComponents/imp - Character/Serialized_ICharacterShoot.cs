using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Showcase
{

    public class Serialized_ICharacterShoot : MonoBehaviour, Interfaces.ICharacterShoot
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float spawnInterval = 1;
        private bool isOpen = false;

        private Transform m_characterTransform;
        private void Awake()
        {
            m_characterTransform = GameObject.Find("<p> playerTransform").transform;
        }

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
            Instantiate(bulletPrefab, m_characterTransform.position, m_characterTransform.rotation);
        }

        private void OnEnable() { }

    }

}