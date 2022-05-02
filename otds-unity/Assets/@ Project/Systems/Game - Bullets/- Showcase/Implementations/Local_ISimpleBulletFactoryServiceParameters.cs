using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{
    public class Local_ISimpleBulletFactoryServiceParameters : MonoBehaviour, Interfaces.ISimpleBulletFactoryServiceParameters
    {
        public GameObject BulletPrefab => null;
        public Transform BulletSpawnLocation => null;
        public ILifetimeChronometerParams ChronometerParams => null;
        public IAddBulletImpulseServiceParams ImpulseParams => null;

    }

}