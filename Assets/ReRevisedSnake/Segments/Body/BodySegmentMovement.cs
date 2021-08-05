using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class BodySegmentMovement : SegmentMovement
    {
        [SerializeField] private SegmentMovement preceedingSegmentMovement;

        public SegmentMovement PreceedingSegmentMovement
        { 
            get => preceedingSegmentMovement;
            set => preceedingSegmentMovement = value;
        }

        protected override Vector3 GetNextGridTilePosition()
        {
            try { return preceedingSegmentMovement.CurrentGridTilePosition; }
            catch { return currentGridTilePosition; }
        }
    }
}