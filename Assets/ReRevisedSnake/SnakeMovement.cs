using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class SnakeMovement : MonoBehaviour
    {
        private bool snakeMovementCoroutineRunning;

        [SerializeField] private List<SegmentMovement> segmentMovements;
        [SerializeField] private float movementSpeed = 5f;

        public delegate void CompletionAction();
        public event CompletionAction OnCompletion;

        public List<SegmentMovement> SegmentMovements { get => segmentMovements; }
        public bool SnakeMovementCoroutineRunning { get => snakeMovementCoroutineRunning; }

        public IEnumerator MoveSnake()
        {
            snakeMovementCoroutineRunning = true;
            float travelPercentage = 0f;
            while (travelPercentage < 1f)
            {
                travelPercentage += movementSpeed * Time.deltaTime;
                MoveSegments(travelPercentage);
                yield return new WaitForEndOfFrame();
            }
            snakeMovementCoroutineRunning = false;
            UpdateSegmentTilePositions();
            if (OnCompletion != null) OnCompletion();
        }

        private void UpdateSegmentTilePositions()
        {
            foreach (SegmentMovement segementMovement in segmentMovements)
            {
                segementMovement.UpdateSegmentTilePositions();
            }
        }

        private void MoveSegments(float travelPercentage)
        {
            foreach (SegmentMovement segementMovement in segmentMovements)
            {
                segementMovement.MoveSegment(travelPercentage);
            }
        }
    }
}