using System.Collections;
using UnityEngine;

namespace Assets.Snake
{
    public class TailSegmentMovement : BodySegmentMovement
    {
        public override void UpdateSegmentTilePositions()
        {
            gridManager.SetGridTileSnakeStatusAtPosition(currentGridTilePosition, false, true);
            base.UpdateSegmentTilePositions();
        }
    }
}