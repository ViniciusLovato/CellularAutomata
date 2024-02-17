using System;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    public static event Action<int, int> OnCellClick;
    
    public void SetColor(Color color)
    {
        _renderer.color = color;
    }

    public void OnMouseDown()
    {
        OnCellClick?.Invoke((int)transform.position.x, (int)transform.position.y);
    }
}
