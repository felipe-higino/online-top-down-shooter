using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{
    public class SpawnBullet : MonoBehaviour
    {

        [Inject] private Bullets.Interfaces.ISimpleBulletFactoryService simpleBulletFactory;
        // [Inject] private Interfaces.ISimpleGunsDatabaseGetter databaseGetter;

        private void TrySpawn()
        {
            simpleBulletFactory.FactoryContextBullet();
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(SpawnBullet))]
        public class SpawnBulletEditor : Editor
        {
            SpawnBullet script;
            private void OnEnable()
            {
                script = (SpawnBullet)target;
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