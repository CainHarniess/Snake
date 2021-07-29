using System.Collections;
using UnityEngine;
using Assets.Grid;

namespace Assets.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        #region Fields
        [SerializeField] private IDirectionManager snakeDirection;
        [SerializeField] private HeadRotation headRotation;
        [SerializeField] private GridManager gridManager;
        [SerializeField] private float movementSpeed = 5f;
        #endregion

        #region Unity Event Functions
        private void Awake()
        {
            snakeDirection = GetComponent<SnakeDirection>();
            headRotation = GetComponentInChildren<HeadRotation>();
        }

        private void OnEnable()
        {
            StartCoroutine(MoveToNextGridNode(gridManager.StartingGridPosition, this.snakeDirection));
        }
        #endregion

        #region Private Methods
        private IEnumerator MoveToNextGridNode(Vector3 startPosition, IDirectionManager snakeDirection)
        {
            float travelPct = 0f;
            Vector3 endPosition = startPosition + this.gridManager.DistancBetweenNodes * snakeDirection.MovementDirection;

            headRotation.RotateHead(snakeDirection);

            while (travelPct < 1f)
            {
                travelPct += this.movementSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPct);
                yield return new WaitForEndOfFrame();
            }
            StopCoroutine(nameof(MoveToNextGridNode));
            StartCoroutine(MoveToNextGridNode(endPosition, snakeDirection));
        }
        #endregion
    }
}
