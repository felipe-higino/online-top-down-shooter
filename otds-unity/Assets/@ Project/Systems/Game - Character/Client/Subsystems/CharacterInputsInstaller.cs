using UnityEngine;
using Zenject;
using OTDS.Character.Interfaces;

namespace OTDS.Character.Client
{
    /// <summary>
    /// this is localized in project context
    /// </summary>
    public class CharacterInputsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICharacterShoot>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<ICharacterAim>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<ICharacterMove>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}