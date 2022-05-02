using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client
{
    public class AddForceOnSpawn : MonoBehaviour
    {
        [SerializeField] Bullets.Data.SO_SimpleBullet bulletData;
        [SerializeField] private Rigidbody2D rigidBody;

        void Start()
        {
            rigidBody.AddForce(transform.right * bulletData.Data.ForceScale);
        }
    }

}