using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{
    public class BulletSpawner : MonoBehaviour
    {
        [Inject] private Bullets.Interfaces.ISimpleBulletFactoryService simpleBulletFactory;

        private void TrySpawn()
        {
            simpleBulletFactory.TryFactoryContextBullet();
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(BulletSpawner))]
        public class SpawnBulletEditor : Editor
        {
            BulletSpawner script;
            private void OnEnable()
            {
                script = (BulletSpawner)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Try Spawn (OnlyPlayMode)" : "Try Spawn"))
                    {
                        script.TrySpawn();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}