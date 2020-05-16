using UnityEngine;

namespace StructDropDown
{
    public class ExampleBehaviour : MonoBehaviour
    {
        // Specify the struct or class that will act as a drop-down list.
        // You can also set one of struct's static fields as a default value.
        [DropDown(typeof(Directions))]
        [SerializeField] private Vector2 _direction = Directions.Right;

        private void OnValidate()
        {
            Debug.Log(_direction.ToString());
        }

        // Only public static fields will be listed in a drop-down. They must have the same type.
        // You can have as many private fields and methods as you want. They won't be taken into account.
        private struct Directions
        {
            public static Vector2 Left = Vector2.left;
            public static Vector2 Right = Vector2.right;
            public static Vector2 Up = Vector2.up;
            public static Vector2 Down = Vector2.down;
        }
    }
}
