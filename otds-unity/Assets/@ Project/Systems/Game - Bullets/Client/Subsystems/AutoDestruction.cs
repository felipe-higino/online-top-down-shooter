using System.Collections;
using System.Collections.Generic;
using OTDS.Utilities.Interfaces;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    /// <summary>
    /// this class is client-authoritative (bullet data injection in chronometer)
    /// </summary>
    public class AutoDestruction : MonoBehaviour
    {
        [Inject] private Utilities.Interfaces.ILifetimeChronometerService chronometerService;
        [Inject] private Utilities.Interfaces.IPrefabInstantiationService prefabInstantiationService;
        [Inject] private Data.SO_SimpleBullet bulletData;

        private void Start()
        {
            var parameters = new Parameters { Time = bulletData.Data.SecondsLifetime };

            chronometerService.StartTimer(
                parameters: parameters,
                End: (x) =>
                {
                    prefabInstantiationService.TryDestroy(this.gameObject);
                }
            );
        }

        private struct Parameters : ILifetimeChronometerParams
        {
            public float Time { get; set; }
        }

    }

}