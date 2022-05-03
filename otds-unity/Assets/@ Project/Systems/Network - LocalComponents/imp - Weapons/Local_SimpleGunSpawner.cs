using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{
    public class Local_SimpleGunSpawner : MonoBehaviour, Interfaces.ISimpleGunSpawner
    {
        [Inject] private PlayerState.Interfaces.IPlayerState playerState;
        [Inject] private Interfaces.ISimpleGunsDatabaseGetter databaseGetter;
        [Inject] private Utilities.Interfaces.IPrefabInstantiationService prefabInstantiationService;

        public void GivePlayerSimpleGun(Data.SO_SimpleGun simpleGun)
        {
            var gunToSpawn = databaseGetter.database.Find(simpleGun);
            if (null == gunToSpawn)
            {
                Debug.LogError("failed to get gun from db");
                return;
            }

            var gunSpawnPoint = playerState.GunSpawnPoint;
            var instance = prefabInstantiationService.TryInstantiate(gunToSpawn.GunPrefab, gunSpawnPoint);
            instance.transform.SetParent(gunSpawnPoint);

            //setup GunState 
            var bulletPrefab = gunToSpawn.BulletPrefab;
            var bulletSpawnPoint = instance.transform.Find("<p> BulletSpawnPoint");

            OTDS.PlayerState.Showcase.S_ScenePlayerState.Instance.CurrentGun = simpleGun;

            S_GunPlayerState.Instance.BulletPrefab = bulletPrefab;
            S_GunPlayerState.Instance.BulletSpawnLocation = bulletSpawnPoint;
        }

#if UNITY_EDITOR
        [Header("---- editor only ----")]
        [SerializeField] Data.SO_SimpleGun gunToSpawn;
        private void GiveSerializedGun()
        {
            GivePlayerSimpleGun(gunToSpawn);
        }

        [CustomEditor(typeof(Local_SimpleGunSpawner))]
        public class Local_WeaponSpawnerEditor : Editor
        {
            Local_SimpleGunSpawner script;
            private void OnEnable()
            {
                script = (Local_SimpleGunSpawner)target;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Give Serialized Gun (OnlyPlayMode)" : "Give Serialized Gun"))
                    {
                        script.GiveSerializedGun();
                    }
                }
            }
        }
#endif
    }

}