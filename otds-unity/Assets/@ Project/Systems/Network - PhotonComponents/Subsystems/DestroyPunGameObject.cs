using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Network.PhotonComponents
{

    public class DestroyPunGameObject : MonoBehaviourPun
    {
        public void DestroyObject()
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Destroy(gameObject);
            // PhotonNetwork.view
        }


#if UNITY_EDITOR
        [CustomEditor(typeof(DestroyPunGameObject))]
        public class DestroyPunGameObjectEditor : Editor
        {
            DestroyPunGameObject script;
            private void OnEnable()
            {
                script = (DestroyPunGameObject)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    if (GUILayout.Button(disable ? "Destroy (OnlyPlayMode)" : "Destroy"))
                    {
                        script.DestroyObject();
                    }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}