using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{
    public class Local_ISimpleBulletFactoryServiceParameters : MonoBehaviour, Interfaces.ISimpleBulletFactoryServiceParameters
    {
        [SerializeField] public Data.SO_SimpleBullet currentBullet;

        public GameObject Prefab => null;
        public Transform Location => null;
        public ILifetimeChronometerParams ChronometerParams => null;
        public IAddBulletImpulseServiceParams ImpulseParams => null;

    }

}