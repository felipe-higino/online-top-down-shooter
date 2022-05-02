using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;

namespace OTDS.PlayerState.Showcase
{
    public class S_ScenePlayerState : MonoBehaviour
    {
        [field: SerializeField] public GameObject PlayerRoot { get; set; }
        [field: SerializeField] public Transform GunSpawnPoint { get; set; }

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