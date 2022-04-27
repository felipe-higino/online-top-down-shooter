using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Input
{
    public class SwitchMap : MonoBehaviour
    {
        public enum Maps
        {
            NoInput,
            Gameplay,
        }
        [SerializeField] public Maps selectedMap;
        [SerializeField] private PlayerInput playerInput;

        private void ChangeMap()
        {
            var mapName = selectedMap.ToString();
            playerInput.SwitchCurrentActionMap(mapName);
        }


#if UNITY_EDITOR
        [CustomEditor(typeof(SwitchMap))]
        public class SwitchMapEditor : Editor
        {
            SwitchMap script;
            private void OnEnable()
            {
                script = (SwitchMap)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Switch (OnlyPlayMode)" : "Switch"))
                    {
                        script.ChangeMap();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}