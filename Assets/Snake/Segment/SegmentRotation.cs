using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class SegmentRotation : MonoBehaviour
    {
        public void RotateSegment(IDirectionManager snakeDirection)
        {
            transform.eulerAngles = new Vector3(0, 0, GetTargetEulerAngle(snakeDirection));
        }

        private int GetTargetEulerAngle(IDirectionManager snakeDirection)
        {
            if (snakeDirection.MovementDirection == Vector3.up) return 0;
            else if (snakeDirection.MovementDirection == Vector3.down) return 180;
            else if (snakeDirection.MovementDirection == Vector3.left) return 90;
            else return -90;
        }
    }
}