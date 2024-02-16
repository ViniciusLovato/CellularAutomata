using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid _grid;

    [SerializeField] private int width, height;
    [SerializeField] private CellView _cellViewPrefab;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float _time = 1f;
    [SerializeField] private Transform _camera;
   
    // Change to jagged array
    private CellView[,] _cellViews;
    
    void Start()
    {
        _grid = new Grid(width, height);
        _cellViews = new CellView[width, height]; // Initialize the array with dimensions
        _camera.transform.position = new Vector3(width / 2 - 0.5f, height / 2 - 0.5f, _camera.transform.position.z);
       InitializeGrid();
       StartCoroutine(RunRefreshGrid());
    }

    IEnumerator RunRefreshGrid()
    {
        while (true)
        {
            _grid.ApplyRules();
            RefreshGrid();
            yield return new WaitForSeconds(_time);
        }
    }
    

    void RefreshGrid()
    {
        var cells = _grid.GetCells();
        for (var i = 0; i < cells.GetLength(0); i++)
        {
            for (var j = 0; j < cells.GetLength(1); j++)
            {
                var cell = cells[i, j];

                _cellViews[i, j].SetColor(cell.IsAlive() ? Color.black : Color.blue);
            }
        }
    }
    
    void InitializeGrid()
    {
        var cells = _grid.GetCells();
        for (var i = 0; i < cells.GetLength(0); i++)
        {
            for (var j = 0; j < cells.GetLength(1); j++)
            {
                var cell = cells[i, j];
                var spawnedTile = Instantiate(_cellViewPrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.transform.localScale = new Vector3(1, 1, 1);
                spawnedTile.SetColor(cell.IsAlive() ? Color.black : Color.white);

                _cellViews[i, j] = spawnedTile;
            }
        }
    }
}
