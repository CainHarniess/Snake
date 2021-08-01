using UnityEngine;

namespace Assets.Grid
{
    [System.Serializable]
    public class GridTile : MonoBehaviour
    {
        private GridManager gridManager;
        
        [SerializeField] private Vector2Int gridCoordinates;

        public Vector2Int GridCoordinates { get => gridCoordinates; }

        void Awake()
        {
            gridManager = GetComponentInParent<GridManager>();
            gridCoordinates = gridManager.GetGridCoordinateFromPosition(transform.position);
            gridManager.GridDictionary.Add(gridCoordinates, this);
        }
    }
}