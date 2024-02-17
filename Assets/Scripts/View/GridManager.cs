using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid _grid;

    [SerializeField] private int width, height;
    [SerializeField] private CellView _cellViewPrefab;
    [SerializeField] private int amountPercentageAlive = 10;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float _time = 1f;
    [SerializeField] private Transform _camera;
   
    // Change to jagged array
    private CellView[,] _cellViews;
    
    private void OnEnable()
    {
        CellView.OnCellClick += SetCellAlive;
    }
    
    void Start()
    {
        _grid = new Grid(width, height, amountPercentageAlive);
        _cellViews = new CellView[width, height]; // Initialize the array with dimensions
        _camera.transform.position = new Vector3(width / 2 - 0.5f, height / 2 - 0.5f, _camera.transform.position.z);
        InitializeViewGrid();
    }

    public void RunSimulation()
    {
      
        StartCoroutine(SimulationCoroutine());
    }

    IEnumerator SimulationCoroutine()
    {
        while (true)
        {
            _grid.ApplyRules();
            RefreshView();
            yield return new WaitForSeconds(_time);
        }
    }
    
    private void InitializeViewGrid()
    {
        var cells = _grid.GetCells();
        for (var i = 0; i < cells.GetLength(0); i++)
        {
            for (var j = 0; j < cells.GetLength(1); j++)
            {
                var cell = cells[i, j];
                var spawnedTile = Instantiate(_cellViewPrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.transform.localScale = new Vector3(1, 1, 1);
                spawnedTile.SetColor(cell.IsAlive() ? Color.black : Color.blue);

                _cellViews[i, j] = spawnedTile;
            }
        }
    }
    
    private void RefreshView()
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

    private void SetCellAlive(int x, int y)
    {
        _grid.SetCellStatus(x, y, true);
        RefreshView();
    }
}
