using UnityEngine;

namespace Assets.Grid
{
    [System.Serializable]
    public class GridTile : MonoBehaviour
    {
        private GridManager gridManager;
        
        [SerializeField] private Vector2Int gridCoordinates;
        [SerializeField] private bool isInSnake = false;
        [SerializeField] private bool isObstacle = false;

        public Vector2Int GridCoordinates { get => gridCoordinates; }
        public bool IsInSnake { get => isInSnake; set => isInSnake = value; }
        public bool IsObstacle { get => isObstacle; }

        void Awake()
        {
            gridManager = GetComponentInParent<GridManager>();
            gridCoordinates = gridManager.GetGridCoordinateFromPosition(transform.position);
            gridManager.GridDictionary.Add(gridCoordinates, this);
        }
    }
}