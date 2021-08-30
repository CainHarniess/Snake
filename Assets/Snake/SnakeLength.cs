using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class SnakeLength : MonoBehaviour
    {
        private SnakeManager snakeManager;

        [SerializeField] private GameObject snakeBodySegmentPrefab;

        private Vector3 GridInstantiationPosition
        { get => snakeManager.SnakePreTail.GetComponent<BodySegmentMovement>().PreceedingSegmentMovementPosition; }

        private void Awake()
        {
            snakeManager = GetComponent<SnakeManager>();
        }  

        public void IncreaseSnakeLength()
        {
            GameObject newSegment = Instantiate(snakeBodySegmentPrefab,
                                                GridInstantiationPosition,
                                                snakeManager.SnakePreTail.transform.rotation//,
                                                //transform
                                               );
            snakeManager.AddSegmentGameObjectToSnake(newSegment);
        }
    }
}