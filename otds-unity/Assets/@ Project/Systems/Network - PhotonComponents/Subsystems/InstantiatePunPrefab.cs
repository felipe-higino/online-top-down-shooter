using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace OTDS.Network.PhotonComponents
{

    public class InstantiatePunPrefab : MonoBehaviourPun
    {
        [SerializeField] private GameObject prefab;

        public void SpawnPrefab()
        {
            photonView.RPC(RPC_SpawnObjectOnMasterClient.rpcName, RpcTarget.MasterClient, prefab.name);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(InstantiatePunPrefab))]
        public class SpawnPunPrefabEditor : Editor
        {
            InstantiatePunPrefab script;
            private void OnEnable()
            {
                script = (InstantiatePunPrefab)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Spawn (OnlyPlayMode)" : "Spawn"))
                    {
                        script.SpawnPrefab();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}