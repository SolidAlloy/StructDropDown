namespace DropDownStruct
{
    using System;
    using System.Linq;
    using System.Reflection;
    using UnityEngine;

    public class DropDownAttribute : PropertyAttribute
    {
        public DropDownAttribute(Type structType)
        {
            var fields = structType.GetFields(BindingFlags.Static | BindingFlags.Public);
            if (CheckFields(fields, structType))
            {
                Fields = fields;
            }
            else
            {
                Fields = new FieldInfo[] { };
            }
        }

        public FieldInfo[] Fields { get; private set; }

        private bool CheckFields(FieldInfo[] fields, Type structType)
        {
            Type[] fieldTypes = (from FieldInfo field in fields select field.FieldType).ToArray();
            if (fieldTypes.Skip(1).All(t => t.Equals(fieldTypes[0])))
            {
                return true;
            }
            else
            {
                Debug.LogErrorFormat(
                    "Public static fields of {0} have inconsistent types. Please make them all of one type.",
                    structType);

                return false;
            }
        }
    }
}