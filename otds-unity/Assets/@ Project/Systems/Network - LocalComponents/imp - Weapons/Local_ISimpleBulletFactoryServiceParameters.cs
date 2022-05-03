using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class Local_ISimpleBulletFactoryServiceParameters : MonoBehaviour, Bullets.Interfaces.ISimpleBulletFactoryServiceParameters
    {
        public GameObject BulletPrefab => S_BulletFactoryParameters.Instance.BulletPrefab;
        public Transform BulletSpawnLocation => S_BulletFactoryParameters.Instance.BulletSpawnLocation;
    }

}