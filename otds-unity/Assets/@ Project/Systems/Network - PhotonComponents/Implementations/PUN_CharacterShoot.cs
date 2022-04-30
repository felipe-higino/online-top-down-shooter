using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using OTDS.Character;

namespace OTDS.Network.PhotonComponents.Implementations
{

    public class PUN_CharacterShoot : A_CharacterShoot
    {
        [SerializeField] private A_CharacterAim characterAim;
        [SerializeField] private Transform bulletSpawnPoint;

        public override void OpenFire()
        {
            //TODO: server-side open fire calculation (collision, spawn position, spawn rotation, what bullet)
            //TODO: filter if should really call RPC (client-calculated action validation)

            CalculateFireClientSideRPC(out var isValid);

            if (isValid)
                S_NetworkedAvatar.Instance.photonView.RPC("Broadcast_OpenFire", RpcTarget.AllViaServer);
        }

        private void CalculateFireClientSideRPC(out bool isValid)
        {
            isValid = true;
        }
    }

}