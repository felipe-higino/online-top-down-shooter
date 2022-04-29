using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Libs.BoilerplateWrappers;

namespace OTDS.Network.PhotonComponents
{
    public class Movement_CallInsideLoop : A_CallInsideUpdate
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private Transform slaveTransform;
        [SerializeField] private Transform masterTransform;

        private void Start()
        {
            if (photonView.IsMine)
            {
                //TODO: inject this
                masterTransform = GameObject.Find("<p> playerTransform").transform;
            }
        }

        public override void Call()
        {
            if (photonView.IsMine)
            {
                slaveTransform.position = masterTransform.position;
                slaveTransform.rotation = masterTransform.rotation;
            }
        }
    }

}