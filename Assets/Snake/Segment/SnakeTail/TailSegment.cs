namespace Assets.Snake
{
    public class TailSegment : BodySegment
    {
        protected override void Awake()
        {
            snakeLengthManager = GetComponentInParent<SnakeLength>();
            segmentMovement = GetComponent<SegmentMovement>();
        }
    }
}