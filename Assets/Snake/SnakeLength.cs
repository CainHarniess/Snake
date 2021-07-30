using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class SnakeLength : MonoBehaviour
    {
        [SerializeField] private GameObject snakeTailSegmentGameObject;
        [SerializeField] private GameObject snakeHeadSegmentGameObject;
        [SerializeField] private GameObject snakeSegmentPrefab;

        public GameObject SnakeSegmentPrefab { get => snakeSegmentPrefab; }
        public GameObject SnakeHeadSegment { get => snakeHeadSegmentGameObject; }
        public GameObject SnakeTailSegmentGameObject { get => snakeTailSegmentGameObject; }
        public TailSegment SnakeTailSegment { get => SnakeTailSegmentGameObject.GetComponent<TailSegment>(); } 

        public void IncreaseSnakeLength()
        {
            Instantiate(snakeSegmentPrefab, snakeTailSegmentGameObject.transform.position, snakeTailSegmentGameObject.transform.rotation, transform);
        }
    }
}