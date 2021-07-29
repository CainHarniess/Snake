using System.Collections.Generic;
using UnityEngine;

namespace Assets.Grid
{
    public class GridManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private int distancBetweenNodes = 10;
        [SerializeField] private Vector3 startingGridPosition;
        #endregion

        #region Properties
        public Vector2Int GridSize { get => gridSize; }
        public float DistancBetweenNodes { get { return distancBetweenNodes; } }
        public Vector3 StartingGridPosition { get => startingGridPosition; }
        #endregion
    }
}