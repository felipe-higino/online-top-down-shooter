using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Interfaces;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents.Implementations
{

    public class PUN_IBulletSpawner : MonoBehaviour, IBulletSpawner
    {
        //TODO: read from photon player data and curent gun
        [SerializeField] private SO_BulletData __toRefactor__;

        public void SpawnNewBullet()
        {
            var playerPosition = S_NetworkedAvatar.Instance.transform;
            var data = __toRefactor__;
            var bulletData = new BulletData(data, playerPosition);

            var bulletSpawnPoint = S_NetworkedAvatar.Instance.photonView.transform;
            var bulletInstance = PhotonNetwork.Instantiate("Bullet", bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            var bulletDataResolver = bulletInstance.GetComponent<BulletDataResolver>();
            bulletDataResolver.Init(bulletData);
        }
    }

}