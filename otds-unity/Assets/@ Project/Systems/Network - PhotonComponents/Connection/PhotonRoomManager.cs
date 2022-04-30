using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Network.PhotonComponents
{
    public class PhotonRoomManager : MonoBehaviourPunCallbacks
    {
        public bool autoJoinRoomOnConnect = false;

        public void JoinDefaultRoom()
        {
            //TODO: customize room Options
            var roomOptions = new RoomOptions
            {
                IsVisible = true,
                IsOpen = true,
                PublishUserId = true,
                MaxPlayers = 9,
            };
            PhotonNetwork.JoinOrCreateRoom("room1", roomOptions, TypedLobby.Default);
        }

        public override void OnConnectedToMaster()
        {
            if (autoJoinRoomOnConnect)
                JoinDefaultRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(PhotonRoomManager))]
        public class PhotonRoomManagerEditor : Editor
        {
            PhotonRoomManager script;
            bool foldout;

            private void OnEnable()
            {
                script = (PhotonRoomManager)target;
            }

            public override bool RequiresConstantRepaint()
            {
                return Application.isPlaying;
            }

            public override void OnInspectorGUI()
            {
                if (Application.isPlaying)
                {
                    EditorGUILayout.LabelField($"room: {PhotonNetwork.CurrentRoom?.Name}");
                    EditorGUILayout.LabelField($"ping: {PhotonNetwork.GetPing()}");
                    if (GUILayout.Button("Join Default Room"))
                    {
                        script.JoinDefaultRoom();
                    }

                    foldout = EditorGUILayout.Foldout(foldout, $"Players ({PhotonNetwork.PlayerList.Length})");
                    if (foldout)
                    {
                        foreach (var player in PhotonNetwork.PlayerList)
                        {
                            EditorGUILayout.LabelField(player.ToString());
                        }
                    }
                }

                base.OnInspectorGUI();
            }
        }
#endif
    }

}