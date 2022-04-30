using UnityEngine;
using Zenject;
using OTDS.Bullets.Interfaces;

namespace OTDS.Bullets.Client
{
    public class BulletsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBulletSpawner>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}