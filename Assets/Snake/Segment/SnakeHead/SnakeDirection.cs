using System.Collections;
using UnityEngine;

namespace Assets.Snake
{
    public class SnakeDirection : MonoBehaviour, IDirectionManager
    {
        [SerializeField] private Vector3 movementDirection = Vector3.up;

        public Vector3 MovementDirection { get => movementDirection; }
        private bool IsMovingInYDirection
        { 
            get => movementDirection == Vector3.up || movementDirection == Vector3.down;
        }
        private bool IsMovingInXDirection
        {
            get => movementDirection == Vector3.left && movementDirection == Vector3.right;
        }

        void Update()
        {
            this.movementDirection = GetSnakeDirection();
        }

        private Vector3 GetSnakeDirection()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !IsMovingInYDirection) return Vector3.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !IsMovingInYDirection) return Vector3.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !IsMovingInXDirection) return Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !IsMovingInXDirection) return Vector3.right;
            else return this.movementDirection;
        }
    }
}