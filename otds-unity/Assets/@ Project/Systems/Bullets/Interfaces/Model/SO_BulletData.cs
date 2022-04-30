using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    [CreateAssetMenu(fileName = "SO_BulletData", menuName = "otds-unity/SO_BulletData", order = 0)]
    public class SO_BulletData : ScriptableObject
    {
        #region -------- BALANCING DATA --------

        [SerializeField]
        private float startVelocity;
        public float StartVelocity => startVelocity;

        [Range(0, 5)]
        [SerializeField]
        private float bulletSpawnOffset;
        public float BulletSpawnOffset => bulletSpawnOffset;

        #endregion -------- BALANCING DATA --------


        #region -------- CLIENT DATA --------

        //client data
        [SerializeField]
        private GameObject bulletVisualPrefab;
        public GameObject BulletVisualPrefab => bulletVisualPrefab;

        #endregion -------- CLIENT DATA --------

    }
}