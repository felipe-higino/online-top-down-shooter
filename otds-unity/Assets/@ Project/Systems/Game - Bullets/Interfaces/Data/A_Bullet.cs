using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Data
{
    [System.Serializable]
    public class A_Bullet
    {
        [SerializeField]
        private float lifetime;
        public float Lifetime => lifetime;
    }

}