using UnityEngine;

namespace Assets.RevisedSnake
{
    public class SnakeDirection : MonoBehaviour
    {
        [SerializeField] private Vector3 movementDirection = Vector3.up;
        private Vector3 currentMovementDirection;
        private Vector3 requestedMovementDirection;

        public Vector3 MovementDirection
        {
            get
            {
                //if (MovementAxisChanged)
                //{
                //    movementDirection = requestedMovementDirection;
                //    currentMovementDirection = requestedMovementDirection;
                //}
                return movementDirection;
            }
        }

        private bool MovementAxisChanged
        { get => !(requestedMovementDirection == currentMovementDirection || requestedMovementDirection == -currentMovementDirection); }

        private void Awake()
        {
            currentMovementDirection = movementDirection;
        }

        private void Update()
        {
            requestedMovementDirection = RequestMovementDirection();
        }

        private Vector3 RequestMovementDirection()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector3.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector3.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector3.right;
            else return currentMovementDirection;
        }
    }
}