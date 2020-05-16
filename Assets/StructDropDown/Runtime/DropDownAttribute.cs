namespace StructDropDown
{
    using System;
    using System.Linq;
    using System.Reflection;
    using UnityEngine;

    /// <summary>
    /// Attribute to create a drop-down list from a struct in the inspector.
    /// </summary>
    /// <example>
    /// [DropDown(typeof(Directions))]
    /// [SerializeField] private Vector2 _direction = Directions.Right;
    /// </example>
    public class DropDownAttribute : PropertyAttribute
    {
        private readonly Type _structType;
        private FieldInfo[] _fields;

        /// <summary>
        /// Attribute to create a drop-down list from a struct in the inspector.
        /// </summary>
        /// <param name="structType">Type of the struct or class that holds the options for a drop-down.</param>
        /// <example>
        /// [DropDown(typeof(Directions))]
        /// [SerializeField] private Vector2 _direction = Directions.Right;
        /// </example>
        public DropDownAttribute(Type structType)
        {
            _structType = structType;

            var fields = structType.GetFields(BindingFlags.Static | BindingFlags.Public);
            Fields = fields;
        }

        public FieldInfo[] Fields { get => _fields; private set => SetFields(value); }

        private void SetFields(FieldInfo[] fields)
        {
            Type[] fieldTypes = (from FieldInfo field in fields select field.FieldType).ToArray();
            if (fieldTypes.Skip(1).All(t => t.Equals(fieldTypes[0])))
            {
                _fields = fields;
            }
            else
            {
                Debug.LogErrorFormat(
                    "Public static fields of {0} have inconsistent types. Please make them all of one type.",
                    _structType);

                _fields = new FieldInfo[] { };
            }
        }
    }
}