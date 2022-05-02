using UnityEngine;
using Zenject;
using OTDS.Weapons.Interfaces;

namespace OTDS.Weapons.Client
{

    public class SimpleGunInstaller : MonoInstaller
    {
        [SerializeField] private Data.SO_SimpleGun data;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GameObject bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Data.SO_SimpleGun>()
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
        }
    }
}