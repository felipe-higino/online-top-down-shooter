using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Showcase
{

    public class Local_A_BulletFactory : A_BulletFactory
    {
        [Inject] Interfaces.ILifetimeChronometerService lifetimeChronometerService;

        public override void SetupBulletFactory(GameObject prefab, Transform location, Data.A_Bullet data)
        {
            m_bulletInstantiator = new BulletInstantiator
            {
                Lifetime = data.Lifetime,
                lifetimeChronometerService = lifetimeChronometerService,
                InstantiateCallback = () => Instantiate(prefab, location),
                DestroyCallback = (x) => Destroy(x),
            };
        }
    }

}