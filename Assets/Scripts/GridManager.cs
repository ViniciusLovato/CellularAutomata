using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initializing GridManager");
        var grid = new Grid(10, 10);
        grid.PrintGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
