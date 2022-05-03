using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Utilities.Showcase
{
    public class Local_IPrefabInstantiationService : MonoBehaviour, Interfaces.IPrefabInstantiationService
    {
        public void TryDestroy(GameObject gameObject)
        {
            Destroy(gameObject);
        }

        public GameObject TryInstantiate(GameObject prefab, Transform location)
        {
            return Instantiate(prefab, location.position, location.rotation);
        }
    }

}