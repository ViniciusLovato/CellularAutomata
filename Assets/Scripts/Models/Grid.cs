using System.Linq; 
using UnityEngine;

public class Grid
{
    private Cell[,] _currentGrid;
    private readonly int _width;
    private readonly int _height;
        
    public Grid(int x, int y, int amountPercentageAlive)
    {
        _width = x;
        _height = y;
        _currentGrid = new Cell[_width, _height];
        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _height; j++)
            {
                _currentGrid[i, j] = new Cell(Random.Range(0, 100) < amountPercentageAlive);
            }
        }
    }

    public void ApplyRules()
    {
        var newGrid = new Cell[_width, _height];
        
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                var cell = _currentGrid[x, y];
                Cell[] neighbors =
                {
                    GetCellSafely(x - 1, y + 1),
                    GetCellSafely(x, y + 1),
                    GetCellSafely(x + 1, y + 1),
                    GetCellSafely(x - 1, y),
                    GetCellSafely(x + 1, y),
                    GetCellSafely(x - 1, y - 1),
                    GetCellSafely(x, y - 1),
                    GetCellSafely(x + 1, y - 1)
                };
                
                var aliveNeighbors = neighbors.Count(neighbor => neighbor?.IsAlive() ?? false);

                if (cell.IsAlive())
                {
                    newGrid[x, y] = new Cell(aliveNeighbors is 2 or 3);
                    
                }
                else if (!cell.IsAlive())
                {
                    newGrid[x, y] = new Cell(aliveNeighbors == 3);
                }
            }
        }

        _currentGrid = newGrid;
    }

    public void SetCellStatus(int x, int y, bool isAlive) => _currentGrid[x, y].SetStatus(isAlive);


    public Cell[,] GetCells() => _currentGrid;
    
    private Cell GetCellSafely(int x, int y)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _height)
        {
            return _currentGrid[x, y];
        }

        return null;
    }
}
