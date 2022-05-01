using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{

    public class Local_IBulletSpawner : MonoBehaviour, Interfaces.IBulletSpawnerService
    {
        public void SpawnBullet(Transform location, GameObject bulletPrefab)
        {
            Instantiate(bulletPrefab, location.position, location.rotation);
        }

        //         [Inject(Id = "bullet prefab")] private GameObject bulletPrefab;
        //         [Inject(Id = "bullet spawn point")] private Transform spawnPoint;

        //         [Inject] private Interfaces.IBulletSpawnerService bulletSpawner;

        //         private void TrySpawn()
        //         {
        //         }

        // #if UNITY_EDITOR
        //         [CustomEditor(typeof(Local_IBulletSpawner))]
        //         public class Local_IBulletSpawnerEditor : Editor
        //         {
        //             Local_IBulletSpawner script;
        //             private void OnEnable()
        //             {
        //                 script = (Local_IBulletSpawner)target;
        //             }

        //             public override void OnInspectorGUI()
        //             {
        //                 var disable = !Application.isPlaying;
        //                 using (new EditorGUI.DisabledGroupScope(disable))
        //                 {
        //                     if (GUILayout.Button(disable ? "Try Spawn (OnlyPlayMode)" : "Try Spawn"))
        //                     {
        //                         script.TrySpawn();
        //                     }
        //                 }
        //                 base.OnInspectorGUI();
        //             }
        //         }
        // #endif
    }
}