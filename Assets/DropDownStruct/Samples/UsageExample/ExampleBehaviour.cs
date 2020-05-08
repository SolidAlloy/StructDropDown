using UnityEngine;

public class ExampleBehaviour : MonoBehaviour
{
    [DropDown(typeof(Directions))]
    [SerializeField] private Vector2 _direction = Directions.Right;

    private void OnValidate()
    {
        Debug.Log(_direction.ToString());
    }

    private struct Directions
    {
        public static Vector2 Left = Vector2.left;
        public static Vector2 Right = Vector2.right;
        public static Vector2 Up = Vector2.up;
        public static Vector2 Down = Vector2.down;
    }
}
