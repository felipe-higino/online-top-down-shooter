using System.Collections;
using System.Collections.Generic;
using OTDS.Character.Interfaces;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace OTDS.Network.PhotonComponents.Implementations
{
    public class PUN_ICharacterShoot : MonoBehaviour, ICharacterShoot
    {
        public void CloseFire()
        {
            throw new System.NotImplementedException();
        }

        public void OpenFire()
        {
            CalculateFireClientSideRPC(out var isValid);

            if (isValid)
            {
                //TODO: SPAWN CURRENT BULLET
                // bulletSpawner.SpawnNewBullet();
                // S_NetworkedAvatar.Instance.photonView.RPC("Broadcast_OpenFire", RpcTarget.All);
            }
        }

        //TODO: implement
        private void CalculateFireClientSideRPC(out bool isValid)
        {
            //TODO: server-side open fire calculation (collision, spawn position, spawn rotation, what bullet)
            //TODO: filter if should really call RPC (client-calculated action validation)
            isValid = true;
        }
    }

}