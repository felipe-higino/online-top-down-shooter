using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using OTDS.Utilities.Interfaces;

namespace OTDS.Network.PhotonComponents.Implementations
{

    public class PUN_IPrefabInstantiationService : MonoBehaviour, IPrefabInstantiationService
    {
        public void TryDestroy(GameObject gameObject)
        {
            PhotonNetwork.Destroy(gameObject);
        }

        public GameObject TryInstantiate(GameObject prefab, Transform location)
        {
            return PhotonNetwork.Instantiate(prefab.name, location.position, location.rotation);
        }
    }

}