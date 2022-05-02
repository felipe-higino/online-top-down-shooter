using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class S_GunPlayerState : MonoBehaviour, Bullets.Interfaces.ISimpleBulletFactoryServiceParameters
    {
        [field: SerializeField] public GameObject BulletPrefab { set; get; }
        [field: SerializeField] public Transform BulletSpawnLocation { set; get; }
        public ILifetimeChronometerParams ChronometerParams { set; get; }
        public IAddBulletImpulseServiceParams ImpulseParams { set; get; }

        public static S_GunPlayerState Instance { get; private set; }
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