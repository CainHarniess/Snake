using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    [RequireComponent(typeof(SnakeMovement))]
    public class SnakeManager : MonoBehaviour
    {
        private SnakeMovement snakeMovement;
        
        private void Awake()
        {
            snakeMovement = GetComponent<SnakeMovement>();
        }

        private void Start()
        {
            StartCoroutine(snakeMovement.MoveSnake());
        }

        private void Update()
        {
            if (!snakeMovement.SnakeMovementCoroutineRunning)
            {
                StartCoroutine(snakeMovement.MoveSnake());
            }
        }
    }
}