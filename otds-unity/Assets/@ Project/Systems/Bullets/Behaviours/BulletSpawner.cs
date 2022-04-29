using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Bullets
{

    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        private static GameObject _bulletContainer;
        private static GameObject BulletContainer
        {
            get
            {
                if (null == _bulletContainer)
                {
                    _bulletContainer = new GameObject("[Bullet Container]");
                }
                return _bulletContainer;
            }
        }

        //TODO: refactor to pool approach
        //TODO: networked instantiation
        //TODO: spawn in container networked
        public void SpawnNewBullet()
        {
            Transform spawnPoint = transform;

            var bullet = Instantiate(prefab, BulletContainer.transform);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;

        }

#if UNITY_EDITOR
        [CustomEditor(typeof(BulletSpawner))]
        public class BulletSpawnerEditor : Editor
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