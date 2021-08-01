using System.Collections.Generic;
using UnityEngine;

namespace Assets.Grid
{
    public class GridManager : MonoBehaviour
    {
        private Dictionary<Vector2Int, GridTile> gridDictionary = new Dictionary<Vector2Int, GridTile>(400);

        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private int distancBetweenNodes = 10;
        [SerializeField] private Vector3 startingGridPosition;

        public Vector2Int GridSize { get => gridSize; }
        public int DistancBetweenNodes { get => distancBetweenNodes; }
        public Vector3 StartingGridPosition { get => startingGridPosition; }
        public Dictionary<Vector2Int, GridTile> GridDictionary { get => gridDictionary; }

        public Vector2Int GetGridCoordinateFromPosition(Vector3 gridTilePosition)
        {
            Vector2 xyPosition = new Vector2(gridTilePosition.x, gridTilePosition.y);
            xyPosition /= distancBetweenNodes;
            return new Vector2Int(Mathf.RoundToInt(xyPosition.x), Mathf.RoundToInt(xyPosition.y));
        }
    }
}