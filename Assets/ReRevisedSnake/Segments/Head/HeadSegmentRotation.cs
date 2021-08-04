using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class HeadSegmentRotation : SegmentRotation
    {
        private SnakeDirection snakeDirection;
        private SnakeMovement snakeMovement;

        [SerializeField] Transform spriteTransform;

        private void Awake()
        {
            snakeDirection = GetComponent<SnakeDirection>();
            snakeMovement = GetComponentInParent<SnakeMovement>();
        }

        private void OnEnable()
        {
            snakeMovement.OnCompletion += RotateSegment;
        }

        private void OnDisable()
        {
            snakeMovement.OnCompletion -= RotateSegment;
        }

        public override void RotateSegment()
        {
            spriteTransform.eulerAngles = new Vector3(0, 0, GetTargetEulerAngle());
        }

        private int GetTargetEulerAngle()
        {
            if (snakeDirection.MovementDirection == Vector3.up) return 0;
            else if (snakeDirection.MovementDirection == Vector3.down) return 180;
            else if (snakeDirection.MovementDirection == Vector3.left) return 90;
            else return -90;
        }
    }
}