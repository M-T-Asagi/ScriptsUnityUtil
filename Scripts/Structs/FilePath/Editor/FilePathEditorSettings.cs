using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AsagiHandyScripts
{
    [CustomPropertyDrawer(typeof(FilePath))]
    public class FilePathDrawer : PropertyDrawer
    {
        private class PropertyData
        {
            public SerializedProperty path;
        }

        Dictionary<string, PropertyData> propertyDataPathes = new Dictionary<string, PropertyData>();
        PropertyData propertyData;
        float LineHeight { get { return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing; } }

        void Init(SerializedProperty _propertyData)
        {
            if (propertyDataPathes.TryGetValue(_propertyData.propertyPath, out propertyData))
                return;

            propertyData = new PropertyData();
            propertyData.path = _propertyData.FindPropertyRelative("path");
            propertyDataPathes.Add(_propertyData.propertyPath, propertyData);
        }

        string findExt = "*";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Init(property);
            Rect fieldRect = EditorGUI.IndentedRect(position);
            fieldRect.height = LineHeight;

            using (new EditorGUI.PropertyScope(fieldRect, label, property))
            {
                fieldRect = EditorGUI.PrefixLabel(fieldRect, GUIUtility.GetControlID(FocusType.Passive), label);

                int preIndent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                Rect firstRect = fieldRect;
                EditorGUI.PropertyField(firstRect, propertyData.path, GUIContent.none);


                EditorGUI.indentLevel = preIndent;
            }

            Rect secondRect = fieldRect;
            secondRect.x = 15;
            secondRect.width = fieldRect.x;
            secondRect.y += LineHeight;
            GUI.Label(secondRect, "ext");

            Rect secondTextRect = fieldRect;
            secondTextRect.y = secondRect.y;
            findExt = EditorGUI.TextField(secondTextRect, findExt);

            Rect thirdRect = fieldRect;
            thirdRect.y = secondRect.y + LineHeight;
            thirdRect.width += thirdRect.x - 15;
            thirdRect.x = 15;

            FilePath path = new FilePath(propertyData.path.stringValue);
            bool isWindows = (Application.platform == RuntimePlatform.WindowsEditor);
            if (GUI.Button(thirdRect, isWindows ? "Find on Explorer" : "Find on Finder"))
            {
                propertyData.path.stringValue = EditorUtility.OpenFilePanel("Open file", (path.path != null && path.path != "" ? path.Directory() : Application.persistentDataPath), findExt);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            Init(property);

            return LineHeight * 3;
        }
    }
}