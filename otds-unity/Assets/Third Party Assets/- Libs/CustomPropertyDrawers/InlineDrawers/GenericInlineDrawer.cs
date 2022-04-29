#if UNITY_EDITOR

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Libs.InlineDrawer
{
    public static class ColorBuild
    {
        public static Color RGBColor(float r, float g, float b)
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }
    }
    public abstract class GenericInlineDrawer<INLINE> : PropertyDrawer where INLINE : UnityEngine.Object
    {
        // private Color propertyColor = ColorBuild.RGBColor(40, 55, 97);
        private static Color propertyColor = ColorBuild.RGBColor(41, 49, 71);
        private static Color inlinePropertiesColor = ColorBuild.RGBColor(199, 222, 255);
        private static Color inlineBackgroundColor = ColorBuild.RGBColor(32, 33, 43);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;
            if (property.objectReferenceValue == null || !AreAnySubPropertiesVisible(property))
            {
                return totalHeight;
            }
            if (property.isExpanded)
            {
                var data = property.objectReferenceValue as INLINE;
                if (data == null) return EditorGUIUtility.singleLineHeight;
                SerializedObject serializedObject = new SerializedObject(data);
                SerializedProperty prop = serializedObject.GetIterator();
                if (prop.NextVisible(true))
                {
                    do
                    {
                        if (prop.name == "m_Script") continue;
                        var subProp = serializedObject.FindProperty(prop.name);
                        float height = EditorGUI.GetPropertyHeight(subProp, null, true) + EditorGUIUtility.standardVerticalSpacing;
                        totalHeight += height;
                    }
                    while (prop.NextVisible(false));
                }
                totalHeight += EditorGUIUtility.standardVerticalSpacing;
            }
            return totalHeight;
        }

        const int buttonWidth = 0;

        static readonly List<string> ignoreClassFullNames = new List<string> { "TMPro.TMP_FontAsset" };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.objectReferenceValue == null)
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.red;
            }
            else
            {
                GUI.backgroundColor = inlinePropertiesColor;
                GUI.contentColor = inlinePropertiesColor;
            }

            EditorGUI.BeginProperty(position, label, property);
            {
                var type = GetFieldType();

                if (type == null || ignoreClassFullNames.Contains(type.FullName))
                {
                    EditorGUI.PropertyField(position, property, label);
                    EditorGUI.EndProperty();
                    return;
                }

                INLINE propertyOBJ = null;
                if (!property.hasMultipleDifferentValues && property.serializedObject.targetObject != null && property.serializedObject.targetObject is INLINE)
                {
                    propertyOBJ = (INLINE)property.serializedObject.targetObject;
                }

                var propertyRect = Rect.zero;
                var guiContent = new GUIContent(property.displayName);
                var foldoutRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);

                var contentRect = new Rect(position.x - 12, position.y, position.width + 16, position.height - 2);
                EditorGUI.DrawRect(contentRect, inlineBackgroundColor);

                var titleRect = new Rect(position.x - 12, position.y, position.width + 16, EditorGUIUtility.singleLineHeight);
                EditorGUI.DrawRect(titleRect, propertyColor);

                if (property.objectReferenceValue != null && AreAnySubPropertiesVisible(property))
                {
                    property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, guiContent, true);
                }
                else
                {
                    foldoutRect.x += 10;
                    EditorGUI.Foldout(foldoutRect, property.isExpanded, guiContent, true, EditorStyles.label);
                }

                var indentedPosition = EditorGUI.IndentedRect(position);
                var indentOffset = indentedPosition.x - position.x;
                propertyRect = new Rect(position.x + (EditorGUIUtility.labelWidth - indentOffset), position.y, position.width - (EditorGUIUtility.labelWidth - indentOffset), EditorGUIUtility.singleLineHeight);

                if (propertyOBJ != null || property.objectReferenceValue == null)
                {
                    propertyRect.width -= buttonWidth;
                }

                EditorGUI.ObjectField(propertyRect, property, type, GUIContent.none);

                if (GUI.changed)
                {
                    property.serializedObject.ApplyModifiedProperties();
                }

                if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue != null)
                {
                    var data = (INLINE)property.objectReferenceValue;

                    if (property.isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        SerializedObject serializedObject = new SerializedObject(data);

                        SerializedProperty prop = serializedObject.GetIterator();
                        float y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                        if (prop.NextVisible(true))
                        {
                            do
                            {
                                GUI.color = inlinePropertiesColor;
                                // Don't bother drawing the class file
                                if (prop.name == "m_Script") continue;
                                float height = EditorGUI.GetPropertyHeight(prop, new GUIContent(prop.displayName), true);
                                EditorGUI.PropertyField(new Rect(position.x, y, position.width - buttonWidth, height), prop, true);
                                y += height + EditorGUIUtility.standardVerticalSpacing;
                            }
                            while (prop.NextVisible(false));
                        }
                        if (GUI.changed)
                            serializedObject.ApplyModifiedProperties();

                        EditorGUI.indentLevel--;

                    }
                }
                property.serializedObject.ApplyModifiedProperties();
            }
            EditorGUI.EndProperty();

            GUI.color = Color.white;
            GUI.contentColor = Color.white;
            GUI.backgroundColor = Color.white;
        }

        public static T _GUILayout<T>(string label, T objectReferenceValue, ref bool isExpanded) where T : INLINE
        {
            return _GUILayout<T>(new GUIContent(label), objectReferenceValue, ref isExpanded);
        }

        public static T _GUILayout<T>(GUIContent label, T objectReferenceValue, ref bool isExpanded) where T : INLINE
        {
            Rect position = EditorGUILayout.BeginVertical();

            var propertyRect = Rect.zero;
            var guiContent = label;
            var foldoutRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);
            if (objectReferenceValue != null)
            {
                isExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, guiContent, true);

                var indentedPosition = EditorGUI.IndentedRect(position);
                var indentOffset = indentedPosition.x - position.x;
                propertyRect = new Rect(position.x + EditorGUIUtility.labelWidth - indentOffset, position.y, position.width - EditorGUIUtility.labelWidth - indentOffset, EditorGUIUtility.singleLineHeight);
            }
            else
            {
                foldoutRect.x += 12;
                EditorGUI.Foldout(foldoutRect, isExpanded, guiContent, true, EditorStyles.label);

                var indentedPosition = EditorGUI.IndentedRect(position);
                var indentOffset = indentedPosition.x - position.x;
                propertyRect = new Rect(position.x + EditorGUIUtility.labelWidth - indentOffset, position.y, position.width - EditorGUIUtility.labelWidth - indentOffset - 60, EditorGUIUtility.singleLineHeight);
            }

            EditorGUILayout.BeginHorizontal();
            objectReferenceValue = EditorGUILayout.ObjectField(new GUIContent(" "), objectReferenceValue, typeof(T), false) as T;

            if (objectReferenceValue != null)
            {

                EditorGUILayout.EndHorizontal();
                if (isExpanded)
                {
                    DrawINLINEChildFields(objectReferenceValue);
                }
            }
            else
            {
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            return objectReferenceValue;
        }

        static void DrawINLINEChildFields<T>(T objectReferenceValue) where T : INLINE
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical(GUI.skin.box);

            var serializedObject = new SerializedObject(objectReferenceValue);
            // Iterate over all the values and draw them
            SerializedProperty prop = serializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    // Don't bother drawing the class file
                    if (prop.name == "m_Script") continue;
                    EditorGUILayout.PropertyField(prop, true);
                }
                while (prop.NextVisible(false));
            }
            if (GUI.changed)
                serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel--;
        }

        public static T DrawINLINEField<T>(GUIContent label, T objectReferenceValue, ref bool isExpanded) where T : INLINE
        {
            Rect position = EditorGUILayout.BeginVertical();

            var propertyRect = Rect.zero;
            var guiContent = label;
            var foldoutRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);
            if (objectReferenceValue != null)
            {
                isExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, guiContent, true);

                var indentedPosition = EditorGUI.IndentedRect(position);
                var indentOffset = indentedPosition.x - position.x;
                propertyRect = new Rect(position.x + EditorGUIUtility.labelWidth - indentOffset, position.y, position.width - EditorGUIUtility.labelWidth - indentOffset, EditorGUIUtility.singleLineHeight);
            }
            else
            {
                // So yeah having a foldout look like a label is a weird hack 
                // but both code paths seem to need to be a foldout or 
                // the object field control goes weird when the codepath changes.
                // I guess because foldout is an interactable control of its own and throws off the controlID?
                foldoutRect.x += 12;
                EditorGUI.Foldout(foldoutRect, isExpanded, guiContent, true, EditorStyles.label);

                var indentedPosition = EditorGUI.IndentedRect(position);
                var indentOffset = indentedPosition.x - position.x;
                propertyRect = new Rect(position.x + EditorGUIUtility.labelWidth - indentOffset, position.y, position.width - EditorGUIUtility.labelWidth - indentOffset - 60, EditorGUIUtility.singleLineHeight);
            }

            EditorGUILayout.BeginHorizontal();
            objectReferenceValue = EditorGUILayout.ObjectField(new GUIContent(" "), objectReferenceValue, typeof(T), false) as T;

            if (objectReferenceValue != null)
            {
                EditorGUILayout.EndHorizontal();
                if (isExpanded)
                {

                }
            }
            else
            {
                // if (GUILayout.Button("Create", GUILayout.Width(buttonWidth)))
                // {
                //     string selectedAssetPath = "Assets";
                //     var newAsset = CreateAssetWithSavePrompt(typeof(T), selectedAssetPath);
                //     if (newAsset != null)
                //     {
                //         objectReferenceValue = (T)newAsset;
                //     }
                // }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            return objectReferenceValue;
        }

        // Creates a new ScriptableObject via the default Save File panel
        // static ScriptableObject CreateAssetWithSavePrompt(Type type, string path)
        // {
        //     path = EditorUtility.SaveFilePanelInProject("Save ScriptableObject", type.Name + ".asset", "asset", "Enter a file name for the ScriptableObject.", path);
        //     if (path == "") return null;
        //     ScriptableObject asset = ScriptableObject.CreateInstance(type);
        //     AssetDatabase.CreateAsset(asset, path);
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
        //     AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        //     EditorGUIUtility.PingObject(asset);
        //     return asset;
        // }

        Type GetFieldType()
        {
            Type type = fieldInfo.FieldType;
            if (type.IsArray) type = type.GetElementType();
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)) type = type.GetGenericArguments()[0];
            return type;
        }

        static bool AreAnySubPropertiesVisible(SerializedProperty property)
        {
            var data = (INLINE)property.objectReferenceValue;
            SerializedObject serializedObject = new SerializedObject(data);
            SerializedProperty prop = serializedObject.GetIterator();
            while (prop.NextVisible(true))
            {
                if (prop.name == "m_Script") continue;
                return true; //if theres any visible property other than m_script
            }
            return false;
        }
    }
}

#endif