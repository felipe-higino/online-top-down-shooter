using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Bullets.Client
{
    public class LifetimeChronometer : MonoBehaviour
    {
        [Inject] private Interfaces.ILifetimeChronometerParams parameters;
        [Inject] private Interfaces.ILifetimeChronometerService chronometer;

        [SerializeField] private bool UnityDestroy = false;
        [SerializeField] private UnityEvent OnTimeout;

        private void OnEnable()
        {
            StartChronometer();
        }

        private void StartChronometer()
        {
            chronometer.StartTimer(
                parameters: parameters,
                End: OnEnd
            );
        }

        private void OnEnd(bool didSuccess)
        {
            if (!didSuccess)
            {
                Debug.LogError("fail to start timer");
            }
            else
            {
                if (UnityDestroy)
                    Destroy(gameObject);
                OnTimeout.Invoke();
            }
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(LifetimeChronometer))]
        public class LifetimeChronometerEditor : Editor
        {
            LifetimeChronometer script;
            private void OnEnable()
            {
                script = (LifetimeChronometer)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Start Chronometer (OnlyPlayMode)" : "Start Chronometer"))
                    {
                        script.StartChronometer();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif

    }
}