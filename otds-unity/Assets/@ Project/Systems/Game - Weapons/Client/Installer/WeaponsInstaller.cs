using UnityEngine;
using Zenject;
using OTDS.Weapons.Interfaces;

namespace OTDS.Weapons.Client
{

    public class WeaponsInstaller : MonoInstaller
    {
        [SerializeField] private Data.SO_SimpleGunRelations gunsDatabase;

        public override void InstallBindings()
        {
            Container.Bind<Interfaces.IKnifeAttack>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Data.SO_SimpleGunRelations>()
                .FromInstance(gunsDatabase)
                .AsSingle();
        }
    }

}