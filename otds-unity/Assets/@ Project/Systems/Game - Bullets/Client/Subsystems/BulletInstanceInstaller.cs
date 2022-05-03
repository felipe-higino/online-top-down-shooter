using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    public class BulletInstanceInstaller : MonoInstaller
    {
        [SerializeField] private Data.SO_SimpleBullet data;
        public override void InstallBindings()
        {
            Container.Bind<Data.SO_SimpleBullet>()
                .FromInstance(data)
                .AsSingle();
        }
    }
}