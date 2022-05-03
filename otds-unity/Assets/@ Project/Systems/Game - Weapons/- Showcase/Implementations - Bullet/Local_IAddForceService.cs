using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{

    public class Local_IAddForceService : MonoBehaviour, Interfaces.IAddForceService
    {
        public void AddForce(IAddForceServiceParams parameters)
        {
            AddForce(parameters.ForceScale, parameters.Rigidbody);
        }

        private void AddForce(float forceScale, Rigidbody2D rigidbody)
        {
            rigidbody.AddForce(rigidbody.transform.right * forceScale);
        }
    }

}