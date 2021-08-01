using System.Collections.Generic;
using UnityEngine;
using Assets.Grid;
using System;

namespace Assets.Snake
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Dictionary<Vector2Int, GridTile> snakeDictionary = new Dictionary<Vector2Int, GridTile>(100);
        [SerializeField] private float movementSpeed = 5f;
        
        public Dictionary<Vector2Int, GridTile> SnakeDictionary { get => snakeDictionary; }
        public float MovementSpeed { get => movementSpeed; }

        public void KillMovementSpeed()
        {
            movementSpeed = 0;
        }
    }
}