using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    /// <summary>
    /// this class is not client-safe. delegates to game add force to a serialized rigidbody2D
    /// </summary>
    public class AddForceOnSpawn : MonoBehaviour
    {
        [Inject] Interfaces.IAddForceService addForceService;
        [SerializeField] Bullets.Data.SO_SimpleBullet bulletData;
        [SerializeField] private Rigidbody2D rigidBody;

        void Start()
        {
            var parameters = new Parameters()
            {
                ForceScale = bulletData.Data.ForceScale,
                Rigidbody = rigidBody
            };
            addForceService.AddForce(parameters);
        }

        private class Parameters : IAddForceServiceParams
        {
            public float ForceScale { get; set; }
            public Rigidbody2D Rigidbody { get; set; }
        }
    }

}