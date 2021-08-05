using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class SnakeMovement : MonoBehaviour
    {
        private bool snakeMovementCoroutineRunning;
        private SnakeManager snakeManager;

        [SerializeField] private float movementSpeed = 5f;

        public delegate void CompletionAction();
        public event CompletionAction OnCompletion;

        public bool SnakeMovementCoroutineRunning { get => snakeMovementCoroutineRunning; }

        private void Awake()
        {
            snakeManager = GetComponent<SnakeManager>();
        }

        private void Start()
        {
            StartCoroutine(MoveSnake());
        }

        private void Update()
        {
            if (!SnakeMovementCoroutineRunning)
            {
                StartCoroutine(MoveSnake());
            }
        }

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
            foreach (GameObject segmentGameObject in snakeManager.SnakeGameObjects)
            {
                segmentGameObject.GetComponent<SegmentMovement>().UpdateSegmentTilePositions();
            }
        }

        private void MoveSegments(float travelPercentage)
        {
            foreach (GameObject SegmentGameObject in snakeManager.SnakeGameObjects)
            {
                SegmentGameObject.GetComponent<SegmentMovement>().MoveSegment(travelPercentage);
            }
        }
    }
}