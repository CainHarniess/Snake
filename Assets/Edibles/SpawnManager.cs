using System.Collections.Generic;
using UnityEngine;
using Assets.Grid;

namespace Assets.Edibles
{
    public class SpawnManager : MonoBehaviour
    {
        private List<Vector3> validSpawnPositions;
        private GridManager gridManager;

        [SerializeField] private Edible edible;

        private void Awake()
        {
            gridManager = GameObject.FindGameObjectWithTag(Tags.Grid).GetComponent<GridManager>();
            validSpawnPositions = new List<Vector3>(gridManager.GridDictionary.Count);
        }

        private void Start()
        {
            ConfigureValidSpawnPositions();
            Spawn();
        }

        private void ConfigureValidSpawnPositions()
        {
            foreach (GridTile gridTile in gridManager.GridDictionary.Values)
            {
                if (!gridTile.IsInSnake && !gridTile.IsObstacle)
                {
                    validSpawnPositions.Add(gridTile.transform.position);
                }
            }
        }

        public void Spawn()
        {
            edible.transform.position = validSpawnPositions[Random.Range(0, validSpawnPositions.Count)];
            edible.gameObject.SetActive(true);
        }

        private Vector3 GetRandomSpawnPosition(GridManager gridManager)
        {
            Vector3 spawnPosition = Vector3.zero;
            spawnPosition.x = gridManager.TileSeparation * Random.Range(0, gridManager.GridSize.x);
            spawnPosition.y = gridManager.TileSeparation * Random.Range(0, gridManager.GridSize.y);
            return spawnPosition;
        }
    }
}