using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Interfaces;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents.Implementations
{

    public class PUN_IBulletSpawner : MonoBehaviour, IBulletSpawner
    {
        public void SpawnNewBullet()
        {
            var bulletSpawnPoint = S_NetworkedAvatar.Instance.photonView.transform;
            PhotonNetwork.Instantiate("Bullet", bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        //TODO: BULLET LIFECYCLE
        //TODO: CURRENT GUN SPAWN APPROACH
        //TODO: SPAWN RATE

    }

}