namespace DropDownStruct
{
    using System.Linq;
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(DropDownAttribute))]
    public class DropDownDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var dropDownAttribute = attribute as DropDownAttribute;
            var fields = dropDownAttribute.Fields;

            if (fields.Length != 0)
            {
                int index = FindByValue(fields, PropertyValueHandler.GetTargetObjectOfProperty(property));
                index = EditorGUI.Popup(position, fields[index].Name, index, GetFieldNames(fields));

                PropertyValueHandler.SetTargetObjectOfProperty(property, fields[index].GetValue(null));
            }
        }

        private static int FindByValue(FieldInfo[] fields, object value)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].GetValue(null).Equals(value))
                {
                    return i;
                }
            }

            return 0;
        }

        private static string[] GetFieldNames(FieldInfo[] fields)
        {
            return (from FieldInfo field in fields select field.Name).ToArray();
        }
    }
}
