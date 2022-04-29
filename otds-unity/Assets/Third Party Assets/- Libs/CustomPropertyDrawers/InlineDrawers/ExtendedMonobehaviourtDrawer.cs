#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using Libs.InlineDrawer;

namespace Libs.InlineDrawer.MonoBehaviours
{
    [CustomPropertyDrawer(typeof(MonoBehaviour), true)]
    public class ExtendedMonoBehaviourDrawer : GenericInlineDrawer<MonoBehaviour> { }
}

#endif