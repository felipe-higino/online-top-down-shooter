using UnityEngine;
using Zenject;

namespace OTDS.Weapons.Client
{
    public class KnifeInstaller : MonoInstaller
    {
        [SerializeField] Data.SO_Knife data;

        public override void InstallBindings()
        {
            Container.Bind<Data.SO_Knife>()
                .FromInstance(data)
                .AsSingle();
        }
    }
}