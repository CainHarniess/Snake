using System.Collections.Generic;
using UnityEngine;

namespace Assets.Grid
{
    public class GridManager : MonoBehaviour
    {
        private Dictionary<Vector2Int, GridTile> gridDictionary = new Dictionary<Vector2Int, GridTile>(400);

        [SerializeField] private Vector2Int gridSize;

        [SerializeField] private int tileSeparation = 10;

        public Vector2Int GridSize { get => gridSize; }
        public int TileSeparation { get => tileSeparation; }
        public Dictionary<Vector2Int, GridTile> GridDictionary { get => gridDictionary; }

        public Vector2Int GetGridCoordinateFromPosition(Vector3 gridTilePosition)
        {
            Vector2 xyPosition = new Vector2(gridTilePosition.x, gridTilePosition.y);
            xyPosition /= tileSeparation;
            return new Vector2Int(Mathf.RoundToInt(xyPosition.x), Mathf.RoundToInt(xyPosition.y));
        }

        public GameObject GetGridTileGameObjectFromPosition(Vector3 position)
        {
            return gridDictionary[GetGridCoordinateFromPosition(position)].gameObject;
        }

        public void SetGridTileSnakeStatusAtPosition(Vector3 position, bool status)
        {
            Vector2Int currentCoordinates = GetGridCoordinateFromPosition(position);
            if (GridDictionary.ContainsKey(currentCoordinates)) GridDictionary[currentCoordinates].IsInSnake = status;
        }
    }
}