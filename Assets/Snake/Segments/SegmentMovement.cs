using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    public abstract class SegmentMovement : MonoBehaviour
    {
        protected GridManager gridManager;
        protected Vector3 currentGridTilePosition;
        protected Vector3 nextGridTilePosition;

        public Vector3 CurrentGridTilePosition { get => currentGridTilePosition; }
        public Vector3 NextGridTilePosition { get => nextGridTilePosition; }

        protected virtual void Awake()
        {
            gridManager = GameObject.FindWithTag(Tags.Grid).GetComponent<GridManager>();
            currentGridTilePosition = transform.position;
            gridManager.SetGridTileSnakeStatusAtPosition(currentGridTilePosition, true, true);
            nextGridTilePosition = GetNextGridTilePosition();
        }

        public void MoveSegment(float travelPercentage)
        {
            transform.position = Vector3.Lerp(CurrentGridTilePosition, NextGridTilePosition, travelPercentage);
        }

        public virtual void UpdateSegmentTilePositions()
        {
            currentGridTilePosition = nextGridTilePosition;
            nextGridTilePosition = GetNextGridTilePosition();
        }

        protected abstract Vector3 GetNextGridTilePosition();
    }
}