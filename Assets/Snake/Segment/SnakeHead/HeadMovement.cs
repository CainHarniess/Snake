using System.Collections;
using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    public class HeadMovement : MonoBehaviour
    {
        private Snake snake;
        private SegmentRotation headRotation;

        [SerializeField] private IDirectionManager snakeDirection;
        [SerializeField] private GridManager gridManager;
       
        private void Awake()
        {
            snake = GetComponentInParent<Snake>();
            snakeDirection = GetComponent<IDirectionManager>();
            headRotation = GetComponentInChildren<SegmentRotation>();
        }

        private void OnEnable()
        {
            StartCoroutine(MoveToNextGridNode(gridManager.StartingGridPosition));
        }

        private IEnumerator MoveToNextGridNode(Vector3 startPosition)
        {
            float travelPct = 0f;

            Vector3 movementVector = gridManager.DistancBetweenNodes * snakeDirection.MovementDirection;
            Vector3 endPosition = startPosition + movementVector;

            headRotation.RotateSegment(snakeDirection);

            while (travelPct < 1f)
            {
                travelPct += snake.MovementSpeed * Time.deltaTime;
                transform.parent.position = Vector3.Lerp(startPosition, endPosition, travelPct);
                yield return new WaitForEndOfFrame();
            }

            StopCoroutine(nameof(MoveToNextGridNode));

            Vector3 newStartPosition = endPosition;
            StartCoroutine(MoveToNextGridNode(newStartPosition));
        }
    }
}
