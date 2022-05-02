using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{

    public class Local_IAddForceOnSpawn : MonoBehaviour, Interfaces.IAddBulletImpulseService
    {
        public void AddBulletImpulse(float forceScale, Rigidbody2D rigidbody)
        {
            rigidbody.AddForce(transform.right * forceScale);
        }
    }

}