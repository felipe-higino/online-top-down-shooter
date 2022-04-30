using System;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client.Data
{
    public class SimpleBulletInstaller : MonoInstaller
    {
        [SerializeField] private SO_SimpleBullet data;

        public override void InstallBindings()
        {
            Container.Bind<Func<float>>()
                .FromInstance(() => data.BulletLifetime)
                .WhenInjectedInto<Subsystems.LifetimeChronometer>();

            Container.Bind<Func<float>>()
                .FromInstance(() => data.StartVelocity)
                .WhenInjectedInto<Subsystems.AddForceOnSpawn>();
        }
    }
}