using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Bullets.Interfaces
{
    public abstract class A_BulletFactory : MonoBehaviour
    {
        protected BulletInstantiator m_bulletInstantiator;

        public abstract void SetupBulletFactory(GameObject prefab, Transform location, Data.A_Bullet data);

        public void SpawnBullet()
        {
            if (null == m_bulletInstantiator)
                return;

            m_bulletInstantiator.Instantiate();
        }

        protected class Parameters : ILifetimeChronometerParams
        {
            public float Time { get; set; }
        }

        protected class BulletInstantiator
        {
            public float Lifetime { get; set; }
            public Action<GameObject> Init { get; set; }
            public Func<GameObject> InstantiateCallback { get; set; }
            public Action<GameObject> DestroyCallback { get; set; }
            public Interfaces.ILifetimeChronometerService lifetimeChronometerService;

            private GameObject m_bulletInstance;

            public void Instantiate()
            {
                m_bulletInstance = InstantiateCallback?.Invoke();

                //timer setup
                lifetimeChronometerService.StartTimer(
                    parameters: new Parameters { Time = Lifetime },
                    End: Destroy);
            }

            private void Destroy(bool didSuccess)
            {
                DestroyCallback?.Invoke(m_bulletInstance);
            }
        }

#if UNITY_EDITOR
        [Space(15)]
        [Header("--- Editor only ---")]
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform location;
        [SerializeField] private Data.A_Bullet data;

        [ContextMenu("Factory")]
        private void _SpawnBullet()
        {
            SetupBulletFactory(prefab, location, data);
            SpawnBullet();
        }

        [CustomEditor(typeof(A_BulletFactory), true)]
        public class A_BulletFactoryEditor : Editor
        {
            A_BulletFactory script;
            private void OnEnable()
            {
                script = (A_BulletFactory)target;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Spawn Bullet (OnlyPlayMode)" : "Spawn Bullet"))
                    {
                        script._SpawnBullet();
                    }
                }
            }
        }
#endif

    }

}