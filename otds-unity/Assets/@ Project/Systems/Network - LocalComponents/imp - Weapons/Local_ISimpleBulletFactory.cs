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
        [Inject] private Utilities.Interfaces.IPrefabInstantiationService prefabInstantiationService { get; }
        [Inject] private ISimpleBulletFactoryServiceParameters simpleBulletFactoryParams { get; }

        private GameObject prefab => simpleBulletFactoryParams.BulletPrefab;
        private Transform location => simpleBulletFactoryParams.BulletSpawnLocation;

        public void TryFactoryContextBullet()
        {
            //instantiation
            var instance = prefabInstantiationService.TryInstantiate(prefab, location);
        }
    }

}