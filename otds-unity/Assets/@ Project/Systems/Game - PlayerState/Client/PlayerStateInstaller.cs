using UnityEngine;
using Zenject;

namespace OTDS.PlayerState.Client
{

    public class PlayerStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Interfaces.IPlayerState>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}