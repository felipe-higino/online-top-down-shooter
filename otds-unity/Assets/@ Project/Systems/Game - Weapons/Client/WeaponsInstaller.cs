using UnityEngine;
using Zenject;
using OTDS.Weapon.Interfaces;

namespace OTDS.Weapon.Client
{
    public class WeaponsInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<IWeaponChange>()
                .FromComponentInHierarchy()
                .AsSingle();

        }

    }
}