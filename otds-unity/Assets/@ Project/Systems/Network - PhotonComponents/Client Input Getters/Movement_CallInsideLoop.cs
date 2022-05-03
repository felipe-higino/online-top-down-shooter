using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Libs.BoilerplateWrappers;
using Zenject;

namespace OTDS.Network.PhotonComponents
{
    public class Movement_CallInsideLoop : A_CallInsideUpdate
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private Transform slaveTransform;
        [SerializeField] private Transform masterTransform;

        [Inject] private OTDS.PlayerState.Interfaces.IPlayerState playerState;

        private void Start()
        {
            if (photonView.IsMine)
            {
                //TODO: inject this
                masterTransform = playerState.PlayerLocation;
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