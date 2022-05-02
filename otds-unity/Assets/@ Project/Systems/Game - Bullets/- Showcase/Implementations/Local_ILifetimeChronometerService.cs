using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Bullets.Interfaces;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Bullets.Showcase
{

    public class Local_ILifetimeChronometerService : MonoBehaviour, Interfaces.ILifetimeChronometerService
    {
        public void StartTimer(ILifetimeChronometerParams parameters, Action Start = null, EndCallback End = null)
        {
            var coroutine = Chronometer(parameters.Time, Start, End);
            StartCoroutine(coroutine);
        }

        private IEnumerator Chronometer(float lifetime, Action Start, EndCallback End)
        {
            Start?.Invoke();
            yield return new WaitForSeconds(lifetime);
            End?.Invoke(true);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(Local_ILifetimeChronometerService))]
        public class Local_ILifetimeChronometerServiceEditor : Editor
        {
            Local_ILifetimeChronometerService script;
            private void OnEnable()
            {
                script = (Local_ILifetimeChronometerService)target;
            }

            private class TestParameters : ILifetimeChronometerParams
            {
                public float Time => 3;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Start timer (OnlyPlayMode)" : "Start timer"))
                    {
                        var param = new TestParameters();
                        script.StartTimer(
                            param,
                            () => Debug.Log("started"),
                            (x) => Debug.Log("finished")
                        );
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}