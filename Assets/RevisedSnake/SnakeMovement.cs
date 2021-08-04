using System.Collections.Generic;
using UnityEngine;
using Assets.Grid;

namespace Assets.RevisedSnake
{
    public class SnakeMovement : MonoBehaviour
    {
        private GridManager gridManager;
        private SnakeDirection snakeDirection;
        private Queue<GameObject> snakeGridTilePath;

        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private GameObject currentGridTileGameObject;
        [SerializeField] private GameObject nextGridTileGameObject;

        public float MovementSpeed { get => movementSpeed; }
        public GameObject NextGridTileGameObject { get => nextGridTileGameObject;}

        private void Awake()
        {
            gridManager = GameObject.FindWithTag("Grid").GetComponent<GridManager>();
            snakeDirection = GetComponent<SnakeDirection>();

            currentGridTileGameObject = gridManager.GetGridTileGameObjectFromPosition(transform.position);

            Vector3 nextGridTilePosition = currentGridTileGameObject.transform.position + (gridManager.TileSeparation * snakeDirection.MovementDirection);

            nextGridTileGameObject = gridManager.GetGridTileGameObjectFromPosition(nextGridTilePosition);
            snakeGridTilePath.Enqueue(currentGridTileGameObject);
        }


        public void UpdateMovementGridTileGameObjects()
        {
            Vector3 currentPosition = currentGridTileGameObject.transform.position;
            Vector3 nextPosition = currentPosition + snakeDirection.MovementDirection;

            currentGridTileGameObject = nextGridTileGameObject;

            nextGridTileGameObject = GetNextGridTileGameObjectFromPosition(nextPosition);
        }

        private GameObject GetNextGridTileGameObjectFromPosition(Vector3 nextPosition)
        {
            Vector2Int nextGridTileCoordinates = gridManager.GetGridCoordinateFromPosition(nextPosition);
            return gridManager.GridDictionary[nextGridTileCoordinates].gameObject;
        }
    }
}