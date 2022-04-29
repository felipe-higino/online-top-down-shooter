using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace OTDS.Network.PhotonComponents
{
    public class PhotonManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TextAsset appId;

        private void Awake()
        {
            var settings = new Photon.Realtime.AppSettings();
            settings.AppIdRealtime = appId.text;

            PhotonNetwork.ConnectUsingSettings(settings);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN: OnConnectedToMaster sucessfull");
        }
    }
}