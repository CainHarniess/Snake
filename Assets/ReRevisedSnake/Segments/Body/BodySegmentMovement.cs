using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class BodySegmentMovement : SegmentMovement
    {
        [SerializeField] protected SegmentMovement preceedingSegmentMovement;

        protected override Vector3 GetNextGridTilePosition()
        {
            return preceedingSegmentMovement.CurrentGridTilePosition;
        }
    }
}