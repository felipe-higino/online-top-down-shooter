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

            Container.Bind<Interfaces.A_BulletFactory>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Interfaces.IAddBulletImpulseService>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}