using UnityEngine;

public class Grid
{
    private readonly Cell[,] _currentGrid;
        
    public Grid(int x, int y)
    {
        _currentGrid = new Cell[x, y];
        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j <y; j++)
            {
                _currentGrid[i, j] = new Cell(Random.Range(0, 10) % 2 == 0);
            }
        }
        
    }

    public void PrintGrid()
    {
        for (var i = 0; i < _currentGrid.GetLength(0); i++)
        {
            for (var j = 0; j < _currentGrid.GetLength(1); j++)
            {
                var cell = _currentGrid[i, j];
                Debug.Log(cell.IsAlive());
            }
        }
    }
}
