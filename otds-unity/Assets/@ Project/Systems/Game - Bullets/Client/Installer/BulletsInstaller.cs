using Zenject;

namespace OTDS.Bullets.Client
{
    public class BulletsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Interfaces.ILifetimeChronometerService>()
                .FromComponentInHierarchy()
                .AsSingle();

            // --------- bullet factory
            Container.Bind<Interfaces.ISimpleBulletFactoryService>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Interfaces.ISimpleBulletFactoryServiceParameters>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}