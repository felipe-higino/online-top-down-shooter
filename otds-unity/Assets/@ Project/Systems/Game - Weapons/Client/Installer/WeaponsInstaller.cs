using UnityEngine;
using Zenject;

namespace OTDS.Weapons.Client
{

    public class WeaponsInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<Interfaces.IKnifeAttack>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Interfaces.ISimpleGunSpawner>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Interfaces.ISimpleGunsDatabaseGetter>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }

}