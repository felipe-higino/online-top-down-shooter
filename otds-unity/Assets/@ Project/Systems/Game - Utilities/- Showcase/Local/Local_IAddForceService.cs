using System.Collections;
using System.Collections.Generic;
using OTDS.Utilities.Interfaces;
using UnityEngine;

namespace OTDS.Utilities.Showcase
{
    public class Local_IAddForceService : MonoBehaviour, Interfaces.IAddForceService
    {
        public void AddForce(IAddForceServiceParams parameters)
        {
            var forceScale = parameters.ForceScale;
            var rigidbody = parameters.Rigidbody;
            rigidbody.AddForce(rigidbody.transform.right * forceScale);
        }
    }

}