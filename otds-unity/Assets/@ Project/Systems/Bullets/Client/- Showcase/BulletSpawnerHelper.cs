using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Interfaces;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Bullets.Client.Showcase
{
    public class BulletSpawnerHelper : MonoBehaviour
    {
        [Inject] private IBulletSpawner bulletSpawner;

        public void SpawnNewBullet()
        {
            bulletSpawner.SpawnNewBullet();
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(BulletSpawnerHelper))]
        public class BulletSpawnerEditor : Editor
        {
            BulletSpawnerHelper script;
            private void OnEnable()
            {
                script = (BulletSpawnerHelper)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Spawn New (OnlyPlayMode)" : "Spawn New"))
                    {
                        script.SpawnNewBullet();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}