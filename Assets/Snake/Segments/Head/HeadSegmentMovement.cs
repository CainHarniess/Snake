using System.Collections;
using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    sealed class HeadSegmentMovement : SegmentMovement
    {
        private SnakeDirection snakeDirection;

        protected override void Awake()
        {
            snakeDirection = GetComponent<SnakeDirection>();
            base.Awake();
            gridManager.SetGridTileSnakeStatusAtPosition(nextGridTilePosition, true);
        }

        protected override Vector3 GetNextGridTilePosition()
        {
            return currentGridTilePosition + (gridManager.TileSeparation * snakeDirection.MovementDirection);
        }

        public override void UpdateSegmentTilePositions()
        {
            base.UpdateSegmentTilePositions();
            gridManager.SetGridTileSnakeStatusAtPosition(nextGridTilePosition, true);
        }
    }
}