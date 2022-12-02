using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoardHandler : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] Vector2Int gridSize;
    public Transform boardParent;

    private float _maxGridSize = 11.52f;

    [SerializeField] GameObject _cellPrefab;

    private void Awake()
    {
        _maxGridSize = _camera.orthographicSize * 2;
    }

    private void Start()
    {

    }

    [ContextMenu("Create Grid")]
    void CreateGrid()
    {
        Debug.Log("Create Grid");
        _maxGridSize = 11.52f;
        DestroyGrid();
        Debug.Log($"Max grid size: {_maxGridSize}");
        float cellSize = _maxGridSize / gridSize.x;
        float startYPos = -(_maxGridSize / 2) + (cellSize / 2);
        float startXPos = -(_maxGridSize / 2) + (cellSize / 2);

        for (int row = 0; row < gridSize.x; row++)
        {
            for (var col = 0; col < gridSize.x; col++)
            {
                var cell = Instantiate(_cellPrefab).transform;
                cell.parent = boardParent;
                cell.localScale = Vector2.one * (cellSize);

                cell.localPosition = new Vector2(startYPos + col * cellSize, startYPos + row * cellSize);
            }

        }
    }

    void DestroyGrid()
    {
        while (boardParent.childCount > 0)
        {
            Debug.Log(boardParent.childCount);
            DestroyImmediate(boardParent.GetChild(0).gameObject);
        }

    }
}
