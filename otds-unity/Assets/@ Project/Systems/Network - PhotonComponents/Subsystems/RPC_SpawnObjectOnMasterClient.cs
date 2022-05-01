using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents
{
    public class RPC_SpawnObjectOnMasterClient : MonoBehaviour
    {
        [PunRPC]
        private void SpawnObjectOnMasterClient(string prefabName)
        {
            PhotonNetwork.InstantiateRoomObject(prefabName, transform.position, transform.rotation);
        }
    }

}