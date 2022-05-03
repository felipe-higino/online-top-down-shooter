using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapons.Client
{

    public class KnifeAttack : MonoBehaviour
    {
        [Inject] private Interfaces.IKnifeAttack knifeAttack;
        [Inject] private Data.SO_Knife knifeData;
        [SerializeField] private GameObject slashVisual;

        public void Slash()
        {
            knifeAttack.SingleAttack(knifeData.Data, OnStartAttack, OnEndAttack);
        }

        private void OnStartAttack()
        {
            slashVisual.SetActive(true);
        }

        private void OnEndAttack()
        {
            slashVisual.SetActive(false);
        }


#if UNITY_EDITOR
        [CustomEditor(typeof(KnifeAttack))]
        public class MeleeSlashEditor : Editor
        {
            KnifeAttack script;
            private void OnEnable()
            {
                script = (KnifeAttack)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Slash (OnlyPlayMode)" : "Slash"))
                    {
                        script.Slash();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}