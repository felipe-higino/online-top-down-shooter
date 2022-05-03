using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;

namespace OTDS.PlayerState.Showcase
{
    public class Local_IPlayerState : MonoBehaviour, Interfaces.IPlayerState
    {
        //server
        public Transform PlayerLocation => S_ScenePlayerState.Instance.PlayerLocation;
        public SO_SimpleGun CurrentGun => S_ScenePlayerState.Instance.CurrentGun;
        public Transform GunSpawnPoint => S_ScenePlayerState.Instance.GunSpawnPoint;

        //client
        public GameObject CurrentGunInstance
        {
            get => S_ScenePlayerState.Instance.CurrentGunInstance;
            set => S_ScenePlayerState.Instance.CurrentGunInstance = value;
        }
    }
}