public class Cell
{
    private readonly bool _isAlive;
    
    public Cell(bool isAlive) => _isAlive = isAlive;

    public bool IsAlive() => _isAlive;
}
