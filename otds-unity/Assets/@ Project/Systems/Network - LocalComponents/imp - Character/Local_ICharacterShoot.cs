using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OTDS.Character.Showcase
{

    public class Local_ICharacterShoot : MonoBehaviour, Interfaces.ICharacterShoot
    {
        [Inject] private OTDS.Bullets.Interfaces.ISimpleBulletFactoryService simpleBulletFactory;
        [Inject] private OTDS.PlayerState.Interfaces.IPlayerState playerState;

        private float spawnInterval => playerState.CurrentGun.Data.ShootRate;

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
                yield return new WaitForSeconds(2);
            }
        }

        private void NewBullet()
        {
            simpleBulletFactory.TryFactoryContextBullet();
        }
    }

}