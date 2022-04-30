using System;
using UnityEngine;
using Zenject;
using OTDS.Character.Interfaces;

namespace OTDS.Character
{
    public class CharacterInputsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //shoot mechanic logic
            Container.Bind<ICharacterShoot>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}