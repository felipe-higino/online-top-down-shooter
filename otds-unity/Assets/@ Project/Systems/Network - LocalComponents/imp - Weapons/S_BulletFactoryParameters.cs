using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class S_BulletFactoryParameters : MonoBehaviour, Bullets.Interfaces.ISimpleBulletFactoryServiceParameters
    {
        [field: SerializeField] public GameObject BulletPrefab { set; get; }
        [field: SerializeField] public Transform BulletSpawnLocation { set; get; }

        public static S_BulletFactoryParameters Instance { get; private set; }
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