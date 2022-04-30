using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Client
{
    public class LifetimeChronometer : MonoBehaviour
    {
        //TODO: extract to scriptable object 
        [SerializeField] private float secondsLifetime;

        private void Start()
        {
            StartCoroutine(Chronometer());
        }

        private IEnumerator Chronometer()
        {
            yield return new WaitForSeconds(secondsLifetime);
            //TODO: networked destroy
            Destroy(gameObject);
        }
    }
}