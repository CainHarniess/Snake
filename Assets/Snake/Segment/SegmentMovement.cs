using System.Collections;
using UnityEngine;

namespace Assets.Snake
{
    public class SegmentMovement : MonoBehaviour
    {
        private BodySegment segment;
        private Snake snake;
        private void Awake()
        {
            segment = GetComponentInParent<BodySegment>();
            snake = GetComponentInParent<Snake>();
        }

        private void OnEnable()
        {
            StartCoroutine(FollowPreceedingSegment());
        }

        public IEnumerator FollowPreceedingSegment()
        {
            float travelPct = 0f;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = segment.PreceedingSegmentGameObject.transform.position;

            while (travelPct < 1f)
            {
                travelPct += snake.MovementSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPct);
                yield return new WaitForEndOfFrame();
            }

            StopCoroutine(nameof(FollowPreceedingSegment));
            StartCoroutine(FollowPreceedingSegment());
        }
    }
}