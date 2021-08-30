using System.Collections.Generic;
using UnityEngine;

namespace Assets.Snake
{
    public class SnakeManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> snakeGameObjects;
       
        public List<GameObject> SnakeGameObjects { get => snakeGameObjects; }
        public GameObject SnakeTail { get => SnakeGameObjects[SnakeGameObjects.Count - 1]; }
        public GameObject SnakePreTail { get => SnakeGameObjects[SnakeGameObjects.Count - 2]; }

        public void AddSegmentGameObjectToSnake(GameObject segmentToAdd)
        {
            GameObject tail = SnakeTail;
            BodySegmentMovement.SetPreceedingSegmentMovementFromGameObjects(segmentToAdd, SnakePreTail);
            BodySegmentMovement.SetPreceedingSegmentMovementFromGameObjects(tail, segmentToAdd);
            snakeGameObjects.Add(segmentToAdd);
            snakeGameObjects.Add(tail);
        }
    }
}