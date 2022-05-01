using UnityEngine;
using Zenject;
using OTDS.Weapons.Interfaces;

namespace OTDS.Weapons.Client
{

    public class SimpleGunInstaller : MonoInstaller
    {
        [SerializeField] private SO_SimpleGun data;
        [SerializeField] Transform bulletSpawnPoint;
        [SerializeField] GameObject bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SO_SimpleGun>()
                .FromInstance(data)
                .AsSingle();

            Container.Bind<Transform>()
                .WithId("bullet spawn point")
                .FromInstance(bulletSpawnPoint)
                .AsSingle();

            Container.Bind<GameObject>()
                .WithId("bullet prefab")
                .FromInstance(bulletPrefab)
                .AsSingle();

            Container.Bind<IShootSimpleGun>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}