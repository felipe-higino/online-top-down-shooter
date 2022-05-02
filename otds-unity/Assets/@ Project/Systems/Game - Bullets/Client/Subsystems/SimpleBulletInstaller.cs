using System;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    public class SimpleBulletInstaller : MonoInstaller
    {
        // [SerializeField] private Data.SO_SimpleBullet data;

        public override void InstallBindings()
        {
            // Container.Bind<Interfaces.ILifetimeChronometerParams>()
            //     .FromInstance(data)
            //     .AsSingle();
        }
    }
}