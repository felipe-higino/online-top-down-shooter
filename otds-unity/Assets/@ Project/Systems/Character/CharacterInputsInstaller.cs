using System;
using UnityEngine;
using Zenject;

namespace OTDS.Character
{
    public class CharacterInputsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //shoot mechanic logic
            Container.Bind<ICharacterShoot>()
                .FromInstance(new NonAuthoritary.NonAut_ICharacterShoot())
                .AsSingle();

        }
    }
}