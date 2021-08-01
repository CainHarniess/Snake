using System.Collections;
using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    public class HeadMovement : MonoBehaviour
    {
        private Snake snake;
        private SegmentRotation headRotation;
        private SnakeDirection snakeDirection;
        
        [SerializeField] private GridManager gridManager;
       
        private void Awake()
        {
            snake = GetComponentInParent<Snake>();
            snakeDirection = GetComponent<SnakeDirection>();
            headRotation = GetComponentInChildren<SegmentRotation>();
        }

        private void OnEnable()
        {
            StartCoroutine(MoveToNextGridNode(gridManager.StartingGridPosition));
        }

        private IEnumerator MoveToNextGridNode(Vector3 startPosition)
        {
            float travelPct = 0f;
            Vector3 endPosition = GetEndPosition(startPosition);
            
            AddEndCoordinateToSnakeDictionaryFromPosition(endPosition);
            
            headRotation.RotateSegment(snakeDirection);

            while (travelPct < 1f)
            {
                travelPct += snake.MovementSpeed * Time.deltaTime;
                transform.parent.position = Vector3.Lerp(startPosition, endPosition, travelPct);
                yield return new WaitForEndOfFrame();
            }

            StopCoroutine(nameof(MoveToNextGridNode));
            snakeDirection.ResetCurrentDirection();
            Vector3 newStartPosition = endPosition;
            StartCoroutine(MoveToNextGridNode(newStartPosition));
        }

        private Vector3 GetEndPosition(Vector3 startPosition)
        {
            return startPosition + gridManager.DistancBetweenNodes * snakeDirection.MovementDirection;
        }

        private void AddEndCoordinateToSnakeDictionaryFromPosition(Vector3 endPosition)
        {
            Vector2Int endCoordindate = gridManager.GetGridCoordinateFromPosition(endPosition);

            if (!snake.SnakeDictionary.ContainsKey(endCoordindate))
            {
                snake.SnakeDictionary.Add(endCoordindate, gridManager.GridDictionary[endCoordindate]);
            }
            else
            {
                Debug.Log("Mate, you crashed the snake into itself.");
                snake.KillMovementSpeed();
            }
        }
    }
}
