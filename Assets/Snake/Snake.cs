using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private List<GameObject> snakeSegmentGameObjects;
        [SerializeField] private GameObject snakeHeadGameObject;
        [SerializeField] private GameObject snakeTailGameObject;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private GameObject snakeSegmentPrefab;

        public float MovementSpeed { get => movementSpeed; }

        public void IncreaseSnakeLength()
        {
            GameObject preceedingSegmentGameObject = GetPreceedingSnakeSegmentGameObject();
            GameObject newSegmentGameObject = Instantiate(snakeSegmentPrefab, preceedingSegmentGameObject.transform);
            AppendNewSnakeSegmentGameObject(newSegmentGameObject, preceedingSegmentGameObject);
        }

        private GameObject GetPreceedingSnakeSegmentGameObject()
        {
            if (snakeSegmentGameObjects.Count == 0) return snakeHeadGameObject;
            else return snakeSegmentGameObjects[snakeSegmentGameObjects.Count - 1];
        }

        private void AppendNewSnakeSegmentGameObject(GameObject newGameObject, GameObject preceedingGameObject)
        {
            newGameObject.GetComponent<Segment>().PreceedingSegment = preceedingGameObject;
            snakeTailGameObject.GetComponent<Segment>().PreceedingSegment = newGameObject;
        }
    }
}