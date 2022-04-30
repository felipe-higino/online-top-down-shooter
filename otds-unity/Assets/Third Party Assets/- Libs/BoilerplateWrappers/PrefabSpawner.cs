using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Libs.BoilerplateWrappers
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

#if UNITY_EDITOR
        [CustomEditor(typeof(PrefabSpawner))]
        public class PrefabSpawnerEditor : Editor
        {
            PrefabSpawner script;
            private void OnEnable()
            {
                script = (PrefabSpawner)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    for (int i = 0; i < script.prefabs.Count; i++)
                    {
                        var prefab = script.prefabs[i];
                        if (null == prefab)
                            continue;

                        var prefabName = prefab.name;
                        if (GUILayout.Button(disable ? $"{prefabName} (OnlyPlayMode)" : $"{prefabName}"))
                        {
                            Instantiate(prefab, script.transform.position, script.transform.rotation);
                        }
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }
}