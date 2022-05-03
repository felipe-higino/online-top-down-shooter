using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace OTDS.Collisions
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Object[] collisionTags;

        [System.Serializable] public class UnityEvent_GameObject : UnityEvent<GameObject> { }
        [SerializeField] private UnityEvent_GameObject OnEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var trigger = other.GetComponent<CollisionTrigger>();
            if (trigger.collisionTags.Any(x => collisionTags.Contains(x)))
            {
                OnEnter.Invoke(this.gameObject);
            }
        }

        // private void OnTriggerExit(Collider other)
        // {
        //     var trigger = other.GetComponent<CollisionTrigger>();
        //     if (trigger.collisionTag == collisionTag)
        //     {

        //     }
        // }
    }
}