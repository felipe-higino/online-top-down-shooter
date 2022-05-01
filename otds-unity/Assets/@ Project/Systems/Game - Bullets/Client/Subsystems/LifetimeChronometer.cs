using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace OTDS.Bullets.Client.Subsystems
{
    public interface ILifetimeChronometer
    {
        float SecondsLifetime { get; }
    }

    public class LifetimeChronometer : MonoBehaviour
    {
        [Inject] private ILifetimeChronometer values;

        [SerializeField] private bool UnityDestroy = false;
        [SerializeField] private UnityEvent OnTimeout;

        private void Start()
        {
            StartCoroutine(Chronometer());
        }

        private IEnumerator Chronometer()
        {
            yield return new WaitForSeconds(values.SecondsLifetime);
            if (UnityDestroy)
                Destroy(gameObject);

            OnTimeout.Invoke();
        }
    }
}