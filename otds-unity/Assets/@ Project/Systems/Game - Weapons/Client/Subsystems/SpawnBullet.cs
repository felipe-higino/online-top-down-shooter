using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Client
{
    public class SpawnBullet : MonoBehaviour
    {
        [Inject] private Data.SO_SimpleGun data;
        [Inject(Id = "bullet spawn point")] private Transform bulletSpawnPoint;
        [Inject(Id = "bullet prefab")] private GameObject bulletPrefab;

        [Inject] private Interfaces.IBulletSpawnerService bulletSpawner;

        private void TrySpawn()
        {
            bulletSpawner.SpawnBullet(
                bulletPrefab: bulletPrefab,
                location: bulletSpawnPoint
            );
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