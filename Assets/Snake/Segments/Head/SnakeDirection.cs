using UnityEngine;

namespace Assets.Snake
{
    public class SnakeDirection : MonoBehaviour
    {
        private SnakeMovement snakeMovement;

        private Vector3 movementDirection = Vector3.up;
        private Vector3 currentDirection;

        public Vector3 MovementDirection { get => movementDirection; }
        private bool MovingInYDirection { get => (currentDirection == Vector3.up) || (currentDirection == Vector3.down); }
        private bool MovingInXDirection { get => (currentDirection == Vector3.left) || (currentDirection == Vector3.right); }

        private void Awake()
        {
            snakeMovement = GameObject.FindGameObjectWithTag(Tags.SnakeManager).GetComponentInParent<SnakeMovement>();
            RefreshCurrentDirection();
        }

        private void OnEnable()
        {
            snakeMovement.OnCompletion += RefreshCurrentDirection;
        }

        private void Update()
        {
            RequestMovementDirection();
        }

        private void OnDisable()
        {
            snakeMovement.OnCompletion -= RefreshCurrentDirection;
        }

        private void RequestMovementDirection()
        {
            if (MovingInYDirection)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow)) movementDirection = Vector3.left;
                else if (Input.GetKeyDown(KeyCode.RightArrow)) movementDirection = Vector3.right;
            }
            else if (MovingInXDirection)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)) movementDirection = Vector3.up;
                else if (Input.GetKeyDown(KeyCode.DownArrow)) movementDirection = Vector3.down;
            }
        }

        private void RefreshCurrentDirection()
        {
            currentDirection = movementDirection;
        }
    }
}
