using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents
{
    public class SpawnNetworkedAvatar : MonoBehaviourPunCallbacks
    {
        private GameObject m_instantiatedAvatar;

        public override void OnJoinedRoom()
        {
            //TODO: get spawn points
            m_instantiatedAvatar = PhotonNetwork.Instantiate("NetworkedAvatar", transform.position, transform.rotation);
        }

        public override void OnLeftRoom()
        {
            PhotonNetwork.Destroy(m_instantiatedAvatar);
        }
    }
}