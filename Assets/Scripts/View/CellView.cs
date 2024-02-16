using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
 
    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
