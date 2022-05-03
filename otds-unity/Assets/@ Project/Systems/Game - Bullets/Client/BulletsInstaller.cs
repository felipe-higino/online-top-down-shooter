using Zenject;

namespace OTDS.Bullets.Client
{
    public class BulletsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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