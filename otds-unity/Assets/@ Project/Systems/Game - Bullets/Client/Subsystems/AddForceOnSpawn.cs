using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace OTDS.Bullets.Client.Subsystems
{
    public class AddForceOnSpawn : MonoBehaviour
    {
        [Inject] private Func<float> GetForceScale;

        [SerializeField] private Rigidbody2D rigidBody;

        //TODO: networked add force?
        void Start()
        {
            rigidBody.AddForce(transform.right * GetForceScale());
        }
    }

}