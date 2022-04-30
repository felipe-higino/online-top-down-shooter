using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OTDS.Bullets.Client.Subsystems
{
    public class LifetimeChronometer : MonoBehaviour
    {
        [Inject] private Func<float> GetSecondsLifetime;

        private void Start()
        {
            StartCoroutine(Chronometer());
        }

        private IEnumerator Chronometer()
        {
            yield return new WaitForSeconds(GetSecondsLifetime());
            //TODO: networked destroy
            Destroy(gameObject);
        }
    }
}