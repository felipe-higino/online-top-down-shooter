using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Client.Subsystems;

namespace OTDS.Bullets.Client.Data
{
    [CreateAssetMenu(fileName = "SO_SimpleBullet", menuName = "ScriptableObject/Bullets/SO_SimpleBullet", order = 0)]
    public class SO_SimpleBullet : ScriptableObject, IAddForceOnSpawn, ILifetimeChronometer
    {
        [SerializeField]
        private float startVelocity;
        public float ForceScale => startVelocity;

        [Min(1)]
        [SerializeField]
        private float bulletLifetime;
        public float SecondsLifetime => bulletLifetime;

    }

}