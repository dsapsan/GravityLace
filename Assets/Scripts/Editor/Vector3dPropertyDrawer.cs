using UnityEngine;

namespace UnityEditor
{
    [CustomPropertyDrawer(typeof(Vector3d))]
    class Vector3dPropertyDrawer : PropertyDrawer
    {
        private const float LabelWidth = 10f;
        private const float LabelOffset = 4f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            position.width = (position.width - 2f * LabelOffset) / 3f;
            EditorGUIUtility.labelWidth = LabelWidth;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("x"));
            position.x += position.width + LabelOffset;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("y"));
            position.x += position.width + LabelOffset;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("z"));

            EditorGUI.EndProperty();
        }
    }
}
