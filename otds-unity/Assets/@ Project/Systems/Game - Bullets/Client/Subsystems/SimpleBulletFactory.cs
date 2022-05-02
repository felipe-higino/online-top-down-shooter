using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    // public class Local_A_BulletFactory : A_BulletFactory
    // public class Local_ISimpleBulletFactoryService : MonoBehaviour, ISimpleBulletFactoryService
    public class SimpleBulletFactory : MonoBehaviour, ISimpleBulletFactoryService
    {
        [Inject] public IPrefabInstantiationService prefabInstantiationService { get; }
        [Inject] public ILifetimeChronometerService lifetimeChronometerService { get; }
        [Inject] public IAddBulletImpulseService addBulletImpulseService { get; }

        [Inject] public ISimpleBulletFactoryServiceParameters simpleBulletFactoryParams { get; }

        private ILifetimeChronometerParams m_chronometerParams => simpleBulletFactoryParams.ChronometerParams;
        private IAddBulletImpulseServiceParams m_impulseParams => simpleBulletFactoryParams.ImpulseParams;
        private GameObject prefab => simpleBulletFactoryParams.Prefab;
        private Transform location => simpleBulletFactoryParams.Location;

        public void FactoryContextBullet()
        {
            //instantiation
            var instance = prefabInstantiationService.TryInstantiate(prefab, location);

            //timer 
            // lifetimeChronometerService.StartTimer(
            //     parameters: m_chronometerParams,
            //     End: (success) =>
            //     {
            //         prefabInstantiationService.Destroy(instance);
            //     }
            // );

            //impulse 
            // addBulletImpulseService.AddBulletImpulse(m_impulseParams);
        }
    }

}