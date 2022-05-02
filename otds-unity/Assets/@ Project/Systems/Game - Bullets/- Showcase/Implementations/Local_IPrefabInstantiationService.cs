using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Showcase
{
    public class Local_IPrefabInstantiationService : MonoBehaviour, Interfaces.IPrefabInstantiationService
    {
        public void TryDestroy(GameObject gameObject)
        {
            TryDestroy(gameObject);
        }

        public GameObject TryInstantiate(GameObject prefab, Transform location)
        {
            return Instantiate(prefab, location.position, location.rotation);
        }
    }

}