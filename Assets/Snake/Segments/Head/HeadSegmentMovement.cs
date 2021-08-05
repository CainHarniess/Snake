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
            Vector3 nextPosition = currentGridTilePosition + (gridManager.TileSeparation * snakeDirection.MovementDirection);
            CheckForGridTileInSnakeAtPosition(nextPosition);
            return nextPosition;
        }

        private void CheckForGridTileInSnakeAtPosition(Vector3 position)
        {
            GridTile nextGridTile = gridManager.GridDictionary[gridManager.GetGridCoordinateFromPosition(position)];
            if (nextGridTile.IsInSnake)
            {
                Debug.Log("GridTile already in snake. Collision!?");
            }
        }

        public override void UpdateSegmentTilePositions()
        {
            base.UpdateSegmentTilePositions();
            gridManager.SetGridTileSnakeStatusAtPosition(nextGridTilePosition, true);
        }
    }
}