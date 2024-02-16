public class Cell
{
    private bool _isAlive;
    
    public Cell(bool isAlive) => _isAlive = isAlive;

    public bool IsAlive() => _isAlive;

    public void SetStatus(bool isAlive) => _isAlive = isAlive;
}
