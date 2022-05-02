using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;

namespace OTDS.PlayerState.Showcase
{
    public class Local_IPlayerState : MonoBehaviour, Interface.IPlayerState
    {
        public SO_SimpleGun CurrentGun => S_ScenePlayerState.Instance.CurrentGun;
        public Transform GunSpawnPoint => S_ScenePlayerState.Instance.GunSpawnPoint;
    }
}