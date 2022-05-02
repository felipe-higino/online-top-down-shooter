using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Showcase
{

    public class Local_ISimpleBulletFactory : MonoBehaviour, ISimpleBulletFactoryService
    {
        [Inject] public Utilities.Interfaces.IPrefabInstantiationService prefabInstantiationService { get; }
        [Inject] public ISimpleBulletFactoryServiceParameters simpleBulletFactoryParams { get; }

        // [Inject]
        // public ILifetimeChronometerService lifetimeChronometerService { get; }
        // private ILifetimeChronometerParams m_chronometerParams => simpleBulletFactoryParams.ChronometerParams;

        // [Inject] 
        // public IAddBulletImpulseService addBulletImpulseService { get; }
        // private IAddBulletImpulseServiceParams m_impulseParams => simpleBulletFactoryParams.ImpulseParams;

        private GameObject prefab => simpleBulletFactoryParams.BulletPrefab;
        private Transform location => simpleBulletFactoryParams.BulletSpawnLocation;

        public void FactoryContextBullet()
        {
            //instantiation
            var instance = prefabInstantiationService.TryInstantiate(prefab, location);

            //timer 
            // lifetimeChronometerService.StartTimer(
            //     parameters: m_chronometerParams,
            //     End: (success) =>
            //     {
            //         prefabInstantiationService.TryDestroy(instance);
            //     }
            // );

            //impulse 
            // addBulletImpulseService.AddBulletImpulse(m_impulseParams);
        }
    }

}