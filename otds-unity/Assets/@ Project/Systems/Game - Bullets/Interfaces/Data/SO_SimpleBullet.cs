using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
// using OTDS.Bullets.Client.Subsystems;

namespace OTDS.Bullets.Data
{
    [System.Serializable]
    public class BulletData : A_Bullet
    {
        [SerializeField] private float startVelocity;
        [Min(1)]
        [SerializeField] private float bulletLifetime;

        public float ForceScale => startVelocity;
        public float SecondsLifetime => bulletLifetime;
    }

    [CreateAssetMenu(fileName = "SO_SimpleBullet", menuName = "ScriptableObject/Bullets/SO_SimpleBullet", order = 0)]
    public class SO_SimpleBullet : ScriptableObject
    {
        [SerializeField]
        private BulletData data;
        public BulletData Data => data;
    }

}