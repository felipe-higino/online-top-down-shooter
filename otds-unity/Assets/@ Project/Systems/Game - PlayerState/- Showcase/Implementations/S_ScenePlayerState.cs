using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;

namespace OTDS.PlayerState.Showcase
{
    //sensible data being trusted to client (client singleton)
    public class S_ScenePlayerState : MonoBehaviour, Interface.IPlayerState
    {

        //------ IPlayerState
        [field: SerializeField] public SO_SimpleGun CurrentGun { get; set; }
        [field: SerializeField] public Transform GunSpawnPoint { get; set; }
        // [field: SerializeField] public Transform BulletSpawnPoint { get; set; }

        //------ Client data
        // [field: SerializeField] public GameObject BulletPrefab { get; set; }

        public static S_ScenePlayerState Instance { get; private set; }


        private void Awake()
        {
            if (null != Instance)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
            }
        }
    }

}