using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Weapon.Interfaces
{
    [CreateAssetMenu(fileName = "SO_Weapon", menuName = "otds-unity/SO_Weapon", order = 0)]
    public class SO_Weapon : ScriptableObject
    {
        [SerializeField]
        private Bullets.Interfaces.SO_BulletData bullet;
        public SO_BulletData Bullet => bullet;

        [Space(15)]
        [Header("--- Balancing data ---")]
        [SerializeField]
        private int maxBulletsCount;
        public int MaxBulletsCount => maxBulletsCount;

        [Space(15)]
        [Header("---- Client data ----")]
        //client side data
        [SerializeField] private GameObject gunVisual;
        public GameObject GunVisual => gunVisual;

    }
}