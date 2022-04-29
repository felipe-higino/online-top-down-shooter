using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents
{
    public class HideMine : MonoBehaviour
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private GameObject[] objectsToDestroy;

        private void Awake()
        {
            if (photonView.IsMine)
            {
                foreach (var obj in objectsToDestroy)
                {
                    Destroy(obj);
                }
            }
        }
    }
}