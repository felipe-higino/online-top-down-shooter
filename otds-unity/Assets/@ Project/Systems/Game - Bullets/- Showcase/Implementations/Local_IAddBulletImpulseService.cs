using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{

    public class Local_IAddBulletImpulseService : MonoBehaviour, Interfaces.IAddBulletImpulseService
    {
        public void AddBulletImpulse(IAddBulletImpulseServiceParams parameters)
        {
            AddBulletImpulse(parameters.ForceScale, parameters.Rigidbody);
        }

        private void AddBulletImpulse(float forceScale, Rigidbody2D rigidbody)
        {
            //no verifications, client-authority
            rigidbody.AddForce(transform.right * forceScale);
        }
    }

}