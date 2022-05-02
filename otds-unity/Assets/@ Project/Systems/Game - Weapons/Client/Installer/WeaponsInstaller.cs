using UnityEngine;
using Zenject;
using OTDS.Weapons.Interfaces;

namespace OTDS.Weapons.Client
{

    public class WeaponsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Interfaces.IBulletSpawnerService>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Interfaces.IKnifeAttack>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }

}