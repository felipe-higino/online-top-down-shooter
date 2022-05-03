using UnityEngine;
using Zenject;

namespace OTDS.Utilities.Client
{
    public class UtilitiesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Interfaces.IPrefabInstantiationService>()
                .FromComponentInHierarchy()
                .AsSingle();


            Container.Bind<Interfaces.IAddForceService>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}