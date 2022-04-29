#if UNITY_EDITOR

using UnityEditor;
using Libs.InlineDrawer;

namespace Libs.InlineScriptableObject.Showcase
{
    [CustomPropertyDrawer(typeof(MonoMyInline), true)]
    public class DrawerForMyInline : GenericInlineDrawer<MonoMyInline> { }

}

#endif