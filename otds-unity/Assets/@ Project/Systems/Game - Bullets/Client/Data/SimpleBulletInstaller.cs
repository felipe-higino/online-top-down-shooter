using System;
using UnityEngine;
using Zenject;
using OTDS.Bullets.Client.Subsystems;

namespace OTDS.Bullets.Client.Data
{
    public class SimpleBulletInstaller : MonoInstaller
    {
        [SerializeField] private SO_SimpleBullet data;

        public override void InstallBindings()
        {
            Container.Bind<ILifetimeChronometer>()
                .FromInstance(data);

            Container.Bind<IAddForceOnSpawn>()
                .FromInstance(data);
        }
    }
}