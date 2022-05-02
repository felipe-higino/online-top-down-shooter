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
        }
    }
}