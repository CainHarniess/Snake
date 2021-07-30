using UnityEngine;
namespace Assets.Snake
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;

        public float MovementSpeed { get => movementSpeed; }
    }
}