#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;

namespace Libs.CustomPropertyDrawers
{

    [CustomPropertyDrawer(typeof(UnityEventBase), true)]
    public class BaseCustomUnityEventDrawer : UnityEventDrawer
    {
        protected override void SetupReorderableList(ReorderableList list)
        {
            base.SetupReorderableList(list);

            list.draggable = true;
        }
    }
}
#endif