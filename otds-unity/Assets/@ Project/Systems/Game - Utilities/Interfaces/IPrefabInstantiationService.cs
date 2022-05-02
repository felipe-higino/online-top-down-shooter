using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Utilities.Interfaces
{
    public interface IPrefabInstantiationService
    {
        GameObject TryInstantiate(GameObject prefab, Transform location);
        void TryDestroy(GameObject gameObject);
    }
}