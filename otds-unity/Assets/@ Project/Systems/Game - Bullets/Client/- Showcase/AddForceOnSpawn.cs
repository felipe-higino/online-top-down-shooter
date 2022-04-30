using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Client.Showcase
{
    public class AddForceOnSpawn : MonoBehaviour
    {
        //TODO: extract to ScriptableObject data
        [SerializeField] private float forceScale;

        [SerializeField] private Rigidbody2D rigidBody;

        //TODO: networked add force?
        void Start()
        {
            rigidBody.AddForce(transform.right * forceScale);
        }
    }

}