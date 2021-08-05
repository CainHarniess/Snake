using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    [RequireComponent(typeof(SnakeMovement))]
    public class SnakeManager : MonoBehaviour
    {
        private List<GameObject> snakeGameObjects;
       
        public List<GameObject> SnakeGameObjects { get => snakeGameObjects; }
        public GameObject SnakeTail { get => SnakeGameObjects[SnakeGameObjects.Count - 1]; }
        public GameObject SnakePreTail { get => SnakeGameObjects[SnakeGameObjects.Count - 2]; }

        private void Awake()
        {
            snakeGameObjects = GetSnakeSegmentGameObjects();
        }

        public void AddSegmentGameObjectToSnake(GameObject segmentToAdd)
        {
            GameObject tail = SnakeTail;
            BodySegmentMovement.SetPreceedingSegmentMovementFromGameObjects(segmentToAdd, SnakePreTail);
            BodySegmentMovement.SetPreceedingSegmentMovementFromGameObjects(tail, segmentToAdd);
            snakeGameObjects.Add(segmentToAdd);
            snakeGameObjects.Add(tail);
        }

        private List<GameObject> GetSnakeSegmentGameObjects()
        {
            List<GameObject> output = new List<GameObject>(transform.childCount - 1);
            for (int i = 0; i < transform.childCount; i++)
            {
                output.Add(transform.GetChild(i).gameObject);
            }
            return output;
        }
    }
}