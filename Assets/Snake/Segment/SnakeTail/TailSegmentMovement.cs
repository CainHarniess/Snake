using System.Collections;
using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    public class TailSegmentMovement : SegmentMovement
    {
        [SerializeField] private GridManager gridManager;

        private void OnEnable()
        {
            StartCoroutine(FollowPreceedingSegment());
        }

        protected override IEnumerator FollowPreceedingSegment()
        {
            RemoveGridTileFromSnakeDictionary(transform.position);
            return base.FollowPreceedingSegment();
        }

        private void RemoveGridTileFromSnakeDictionary(Vector3 position)
        {
            Vector2Int coordinates = gridManager.GetGridCoordinateFromPosition(position);

            if (snake.SnakeDictionary.ContainsKey(coordinates))
            {
                snake.SnakeDictionary.Remove(coordinates);
            }
        }
    }
}