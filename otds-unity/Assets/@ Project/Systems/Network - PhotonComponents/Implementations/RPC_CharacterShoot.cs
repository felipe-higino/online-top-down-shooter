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
        private void Broadcast_OpenFire(PhotonMessageInfo info)
        {
            Debug.Log($"{gameObject.name}: {photonView.Owner.ToString()}: Requested Open Fire");

            //READ SERVER-SIDE PLAYER DATA
            //TODO: INSTANTIATE CORRECT BULLET PREFAB (PLAYER GUN)
            //TODO: CALCULATE BULLET PHYSICS AND COLLISIONS SERVER-SIDE
            //TODO: CORRECT POSITION (PLAYER SERVER-SIDE BULLET SPAWN POSITION)

            var bulletTransform = info.photonView.transform;
            PhotonNetwork.Instantiate("Bullet", bulletTransform.position, bulletTransform.rotation);
        }
    }

}