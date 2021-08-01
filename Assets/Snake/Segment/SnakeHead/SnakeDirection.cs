using System.Collections;
using UnityEngine;

namespace Assets.Snake
{
    public class SnakeDirection : MonoBehaviour
    {
        [SerializeField] private Vector3 movementDirection = Vector3.up;
        private Vector3 currentMovementDirection;
        private Vector3 requestedMovementDirection;

        public Vector3 MovementDirection { get => movementDirection; }
        private bool IsMovingInYDirection
        { 
            get => movementDirection == Vector3.up || movementDirection == Vector3.down;
        }
        private bool IsMovingInXDirection
        {
            get => movementDirection == Vector3.left && movementDirection == Vector3.right;
        }

        private void Awake()
        {
            currentMovementDirection = movementDirection;
        }

        void Update()
        {
            requestedMovementDirection = RequestMovementDirection();
            UpdateMovementDirection();
        }

        private void UpdateMovementDirection()
        {
            if (requestedMovementDirection == currentMovementDirection || requestedMovementDirection == -currentMovementDirection)
            {
                return;
            }
            else
            {
                movementDirection = requestedMovementDirection;
            }
        }

        public void ResetCurrentDirection()
        {
            currentMovementDirection = movementDirection;
        }

        private Vector3 RequestMovementDirection()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector3.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector3.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector3.right;
            else return this.movementDirection;
        }
    }
}