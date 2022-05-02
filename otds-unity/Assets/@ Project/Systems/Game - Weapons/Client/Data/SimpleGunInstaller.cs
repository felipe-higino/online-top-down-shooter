using UnityEngine;
using Zenject;

namespace OTDS.Weapons.Client
{

    public class SimpleGunInstaller : MonoInstaller
    {
        [SerializeField] private Data.SO_SimpleGun data;
        [SerializeField] private Transform bulletSpawnPoint;

        public override void InstallBindings()
        {
            Container.Bind<Data.SO_SimpleGun>()
                .FromInstance(data)
                .AsSingle();

            Container.Bind<Transform>()
                .WithId("bullet spawn point")
                .FromInstance(bulletSpawnPoint)
                .AsSingle();

            Container.Bind<Bullets.Data.SO_SimpleBullet>()
                .FromInstance(data.Data.BulletData)
                .AsSingle();
        }
    }
}