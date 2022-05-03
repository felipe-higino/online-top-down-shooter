using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using OTDS.Character;

namespace OTDS.Network.PhotonComponents
{
    public class S_NetworkedAvatar : MonoBehaviourPun
    {
        public static S_NetworkedAvatar Instance { get; private set; }

        private void Awake()
        {
            //set object name
            gameObject.name = $"[NetworkedAvatar] {photonView.Owner.ToString()}";

            //set player view static reference
            if (photonView.IsMine)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}