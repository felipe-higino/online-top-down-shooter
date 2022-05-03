#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Util.FolderStructure
{
    public class SetFolderStructure : MonoBehaviour
    {
        [MenuItem(itemName: "Assets/Create/Folder Structure", priority = 20)]
        static void CreateFolderStructure()
        {
            var selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            AssetDatabase.CreateFolder(selectedPath, "- Experimental");
            AssetDatabase.CreateFolder(selectedPath, "3D");
            AssetDatabase.CreateFolder(selectedPath, "Content");
            AssetDatabase.CreateFolder(selectedPath, "Scenes");
            AssetDatabase.CreateFolder(selectedPath, "Systems");
            AssetDatabase.CreateFolder(selectedPath, "Widgets");
        }
    }
}
#endif