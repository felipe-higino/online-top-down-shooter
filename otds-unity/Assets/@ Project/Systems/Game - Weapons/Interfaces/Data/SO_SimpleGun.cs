using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Data;
using UnityEngine;

namespace OTDS.Weapons.Data
{
    [System.Serializable]
    public class SimpleGunData
    {
        [SerializeField] private int maxBullets;
        [SerializeField] private float shootRate;
        [SerializeField] private Bullets.Data.SO_SimpleBullet bulletData;
        [SerializeField] private GameObject bulletPrefab;

        public int MaxBullets => maxBullets;
        public float ShootRate => shootRate;
        public SO_SimpleBullet BulletData => bulletData;
        public GameObject BulletPrefab => bulletPrefab;
    }

    [CreateAssetMenu(fileName = "SO_SimpleGun", menuName = "ScriptableObject/Weapons/SO_SimpleGun", order = 0)]
    public class SO_SimpleGun : ScriptableObject
    {
        [SerializeField]
        private SimpleGunData data;
        public SimpleGunData Data => data;
    }

}