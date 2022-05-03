using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    /// <summary>
    /// this class is not client-safe. delegates to game add force to a serialized rigidbody2D
    /// </summary>
    public class AddForceOnSpawn : MonoBehaviour
    {
        [Inject] Utilities.Interfaces.IAddForceService addForceService;
        [Inject] Bullets.Data.SO_SimpleBullet bulletData;

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

        private class Parameters : Utilities.Interfaces.IAddForceServiceParams
        {
            public float ForceScale { get; set; }
            public Rigidbody2D Rigidbody { get; set; }
        }
    }

}