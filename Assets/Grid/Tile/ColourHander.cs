using UnityEngine;
using Assets.Grid;

[ExecuteAlways]
public class ColourHander : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GridTile gridTile;

    [SerializeField] private Material obstacleMaterial;
    [SerializeField] private Material nonObstacleMaterial;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        gridTile = GetComponent<GridTile>();
    }

    private void Update()
    {
        if (gridTile.IsObstacle) spriteRenderer.material = obstacleMaterial;
        else spriteRenderer.material = nonObstacleMaterial;
    }

}
