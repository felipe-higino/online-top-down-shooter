using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
// using OTDS.Bullets.Client.Subsystems;

namespace OTDS.Bullets.Data
{
    [System.Serializable]
    public class BulletData
    {
        [SerializeField]
        private float startVelocity;
        public float ForceScale => startVelocity;

        [Min(1)]
        [SerializeField]
        private float bulletLifetime;
        public float SecondsLifetime => bulletLifetime;
    }

    [CreateAssetMenu(fileName = "SO_SimpleBullet", menuName = "ScriptableObject/Bullets/SO_SimpleBullet", order = 0)]
    public class SO_SimpleBullet : ScriptableObject, Interfaces.ILifetimeChronometerParams
    {
        [SerializeField]
        private BulletData data;
        public BulletData Data => data;

        public float Time => data.SecondsLifetime;
    }

}