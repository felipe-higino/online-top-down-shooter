using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Utilities.Interfaces
{
    public interface IAddForceServiceParams
    {
        float ForceScale { get; }
        Rigidbody2D Rigidbody { get; set; }
    }

    public interface IAddForceService
    {
        void AddForce(IAddForceServiceParams parameters);
    }
}