using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class Local_ISimpleBulletFactoryServiceParameters : MonoBehaviour, Bullets.Interfaces.ISimpleBulletFactoryServiceParameters
    {
        public GameObject BulletPrefab => S_GunPlayerState.Instance.BulletPrefab;
        public Transform BulletSpawnLocation => S_GunPlayerState.Instance.BulletSpawnLocation;
        public ILifetimeChronometerParams ChronometerParams => S_GunPlayerState.Instance.ChronometerParams;
    }

}