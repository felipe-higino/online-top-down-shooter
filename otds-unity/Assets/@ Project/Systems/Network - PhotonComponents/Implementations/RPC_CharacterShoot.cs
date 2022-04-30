using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace OTDS.Network.PhotonComponents.Implementations
{

    [DisallowMultipleComponent]
    public class RPC_CharacterShoot : MonoBehaviourPun
    {
        [PunRPC]
        private void Broadcast_OpenFire()
        {
            Debug.Log($"{gameObject.name}: {photonView.Owner.ToString()}: Requested Open Fire");
            //READ SERVER-SIDE PLAYER DATA
            //TODO: INSTANTIATE CORRECT BULLET PREFAB (PLAYER GUN)
            //TODO: CORRECT POSITION (PLAYER SERVER-SIDE BULLET SPAWN POSITION)
            //TODO: CALCULATE BULLET PHYSICS AND COLLISIONS SERVER-SIDE
        }
    }

}