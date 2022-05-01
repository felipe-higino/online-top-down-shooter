using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client.Subsystems
{
    public interface IAddForceOnSpawn
    {
        float ForceScale { get; }
    }

    public class AddForceOnSpawn : MonoBehaviour
    {
        [Inject] IAddForceOnSpawn values;
        [SerializeField] private Rigidbody2D rigidBody;

        void Start()
        {
            rigidBody.AddForce(transform.right * values.ForceScale);
        }
    }

}