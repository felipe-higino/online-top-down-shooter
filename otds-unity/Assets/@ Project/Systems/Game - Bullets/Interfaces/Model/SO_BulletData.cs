using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    [CreateAssetMenu(fileName = "SO_BulletData", menuName = "otds-unity/SO_BulletData", order = 0)]
    public class SO_BulletData : ScriptableObject
    {
        [Header("--- Balancing data ---")]
        [SerializeField]
        private float startVelocity;
        public float StartVelocity => startVelocity;

        [Range(0, 5)]
        [SerializeField]
        private float bulletSpawnOffset;
        public float BulletSpawnOffset => bulletSpawnOffset;

        [Min(1)]
        [SerializeField]
        private float bulletLifetime;
        public float BulletLifetime => bulletLifetime;

        [Space(15)]
        [Header("---- Client data ----")]

        [SerializeField]
        private GameObject bulletVisualPrefab;
        public GameObject BulletVisualPrefab => bulletVisualPrefab;


    }
}