using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoardHandler : MonoBehaviour
{

    [SerializeField] int gridSize;
    public Transform boardParent;

    private float _maxGridSize = 11.52f;

    [SerializeField] GameObject _cellPrefab;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    [ContextMenu("Create Grid")]
    void CreateGrid()
    {
        Debug.Log("Creating Grid");
        var sizeOffset = 1.75f;
        var topMargin = 0.5f;
        _maxGridSize = (FindObjectOfType<Camera>().orthographicSize * 2) - sizeOffset;


        DestroyGrid();
        Debug.Log($"Max grid size: {_maxGridSize}");
        float cellSize = _maxGridSize / gridSize;
        float startYPos = -(_maxGridSize / 2) + (cellSize / 2) - topMargin;
        float startXPos = -(_maxGridSize / 2) + (cellSize / 2);

        for (int row = 0; row < gridSize; row++)
        {
            for (var col = 0; col < gridSize; col++)
            {
                var cell = Instantiate(_cellPrefab).transform;
                cell.parent = boardParent;
                cell.localScale = Vector2.one * (cellSize);

                cell.localPosition = new Vector2(startXPos + col * cellSize, startYPos + row * cellSize);
            }
        }
    }

    void DestroyGrid()
    {
        while (boardParent.childCount > 0)
        {
            DestroyImmediate(boardParent.GetChild(0).gameObject);
        }

    }
}
