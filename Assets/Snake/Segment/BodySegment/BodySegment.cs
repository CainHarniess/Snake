using UnityEngine;

namespace Assets.Snake
{
    public class BodySegment : Segment
    {
        [SerializeField] protected GameObject preceedingSegmentGameObject;

        [SerializeField] protected SegmentMovement segmentMovement;

        public GameObject PreceedingSegmentGameObject { get => preceedingSegmentGameObject; set => preceedingSegmentGameObject = value; }

        protected override void Awake()
        {
            base.Awake();
            segmentMovement = GetComponent<SegmentMovement>();
            UpdatePreceedingSegments();
        }

        private void UpdatePreceedingSegments()
        {
            preceedingSegmentGameObject = snakeLengthManager.SnakeTailSegment.PreceedingSegmentGameObject;
            snakeLengthManager.SnakeTailSegment.PreceedingSegmentGameObject = gameObject;
        }
    }
}