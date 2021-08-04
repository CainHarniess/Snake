using System.Collections;
using UnityEngine;

namespace Assets.RevisedSnake
{
    public sealed class HeadSegmentMovement : SegmentMovement
    {
        // private SegmentRotation headRotation;

        protected override GameObject NextGridTileGameObject
        { get => snakeMovement.NextGridTileGameObject; }

        protected override Vector3 NextPosition
        { get => NextGridTileGameObject.transform.position; }

        protected override void Awake()
        {
            base.Awake();
            // headRotation = GetComponent<SegmentRotation>();
        }

        protected override IEnumerator MoveSegment(Vector3 startPosition, Vector3 endPosition)
        {
            // headRotation.RotateSegment(snakeMovement);
            yield return base.MoveSegment(startPosition, endPosition);
            snakeMovement.UpdateMovementGridTileGameObjects();
        }
    }
}