using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class BodySegmentMovement : SegmentMovement
    {
        [SerializeField] private SegmentMovement preceedingSegmentMovement;
        
        public Vector3 PreceedingSegmentMovementPosition { get => preceedingSegmentMovement.CurrentGridTilePosition; }

        protected override Vector3 GetNextGridTilePosition()
        {
            try 
            {
                // Debug.Log("Try block: " + preceedingSegmentMovement.CurrentGridTilePosition);
                return preceedingSegmentMovement.CurrentGridTilePosition; }
            catch
            {
                // Debug.Log("Catch block; " + currentGridTilePosition);
                return currentGridTilePosition;
            }
        }

        public static void SetPreceedingSegmentMovementFromGameObjects(GameObject gameObject, GameObject preceedingGameObject)
        {
            BodySegmentMovement bodySegmentMovement = gameObject.GetComponent<BodySegmentMovement>();
            BodySegmentMovement preceedingBodySegmentMovement = preceedingGameObject.GetComponent<BodySegmentMovement>();

            bodySegmentMovement.preceedingSegmentMovement = preceedingBodySegmentMovement;
        }
    }
}