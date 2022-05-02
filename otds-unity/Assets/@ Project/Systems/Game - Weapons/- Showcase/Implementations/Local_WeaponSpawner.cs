using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Showcase
{
    public class Local_WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private Data.SO_SimpleGunRelations simpleGunDb;

        public void RequestSpawn(Data.SO_SimpleGun gunID)
        {
            var dataToSpawn = simpleGunDb.Find(gunID);
            if (null == dataToSpawn)
            {
                Debug.LogError($"fail to find {gunID} in schema");
                return;
            }

            var gunPrefab = dataToSpawn.GunPrefab;
            //TODO: setup context in interfaces
            Instantiate(gunPrefab, transform);
        }

        private IEnumerable<string> QueryNames()
        {
            return simpleGunDb.Table.List.Select(x =>
            {
                Debug.Log("iae");
                return x.Data.name;
            });
        }

#if UNITY_EDITOR
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
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    var list = script.simpleGunDb.Table.List.ToList();
                    foreach (var obj in list)
                    {
                        if (GUILayout.Button(disable ? $"{obj.Data.name} (OnlyPlayMode)" : $"{obj.Data.name}"))
                        {
                            script.RequestSpawn(obj.Data);
                        }
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif

    }
}