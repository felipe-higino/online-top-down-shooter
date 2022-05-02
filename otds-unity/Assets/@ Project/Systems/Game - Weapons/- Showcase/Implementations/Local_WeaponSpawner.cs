using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{
    public class Local_WeaponSpawner : MonoBehaviour//,Interfaces.IKnifeAttack
    {
        [Inject] private PlayerState.Interface.IPlayerState playerState;
        [Inject] private Data.SO_SimpleGunRelations database;
        [Inject] private Utilities.Interfaces.IPrefabInstantiationService prefabInstantiationService;

        public void GivePlayerSimpleGun(Data.SO_SimpleGun simpleGun)
        {
            var gunToSpawn = database.Find(simpleGun);
            if (null == gunToSpawn)
            {
                Debug.LogError("failed to get gun from db");
                return;
            }

            var gunSpawnPoint = playerState.GunSpawnPoint;
            var instance = prefabInstantiationService.TryInstantiate(gunToSpawn.GunPrefab, gunSpawnPoint);
            instance.transform.SetParent(gunSpawnPoint);
        }

#if UNITY_EDITOR
        [Header("---- editor only ----")]
        [SerializeField] Data.SO_SimpleGun gunToSpawn;
        private void GiveSerializedGun()
        {
            GivePlayerSimpleGun(gunToSpawn);
        }

        [CustomEditor(typeof(Local_WeaponSpawner))]
        public class Local_WeaponSpawnerEditor : Editor
        {
            Local_WeaponSpawner script;
            private void OnEnable()
            {
                script = (Local_WeaponSpawner)target;
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