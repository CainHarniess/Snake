using System.Collections;
using UnityEngine;

namespace Assets.RevisedSnake
{
    public abstract class SegmentMovement : MonoBehaviour
    {
        protected SnakeMovement snakeMovement;
        protected IEnumerator segmentMovementCoroutine;

        [SerializeField] protected Vector3 nextPosition;
        [SerializeField] protected GameObject nextGridTileGameObject;
        [SerializeField] protected GameObject previousGridTileGameObject;

        protected abstract GameObject NextGridTileGameObject { get; }
        protected abstract Vector3 NextPosition { get; }

        protected virtual void Awake()
        {
            snakeMovement = GetComponent<SnakeMovement>();
        }

        protected virtual void Start()
        {
            StartMovementCoroutine();
        }

        // Restarts the movement coroutine once the previous one has finished
        protected virtual void Update()
        {
            if (segmentMovementCoroutine == null)
            {
                previousGridTileGameObject = nextGridTileGameObject;
                StartMovementCoroutine();
            }
        }

        private void StartMovementCoroutine()
        {
            segmentMovementCoroutine = MoveSegment(previousGridTileGameObject, NextGridTileGameObject);
            StartCoroutine(segmentMovementCoroutine);
        }

        protected virtual IEnumerator MoveSegment(Vector3 startPosition, Vector3 endPosition)
        {
            float travelPct = 0f;

            // Start the current coroutine cycle
            while (travelPct < 1f)
            {
                travelPct += snakeMovement.MovementSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPct);
                yield return new WaitForEndOfFrame();
            }
        }

        protected virtual IEnumerator MoveSegment(GameObject startGridTile, GameObject endGridTile)
        {
            yield return MoveSegment(startGridTile.transform.position, endGridTile.transform.position);
        }
    }
}