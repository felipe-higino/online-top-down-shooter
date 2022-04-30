using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Client.Data
{
    [CreateAssetMenu(fileName = "SO_SimpleBullet", menuName = "ScriptableObject/Bullets/SO_SimpleBullet", order = 0)]
    public class SO_SimpleBullet : ScriptableObject
    {
        [SerializeField]
        private float startVelocity;
        public float StartVelocity => startVelocity;
        [Min(1)]
        [SerializeField]
        private float bulletLifetime;
        public float BulletLifetime => bulletLifetime;
    }

}