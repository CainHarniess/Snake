using UnityEngine;
using Assets.Grid;

namespace Assets.Edibles
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Edible edible;
        [SerializeField] private GridManager gridManager;

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {
            edible.transform.position = GetRandomSpawnPosition(gridManager);
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