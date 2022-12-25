using System;
using System.Collections;
using System.Collections.Generic;
using Board;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    [SerializeField] private GameObject gridObject;
    [SerializeField] private float Rows;
    [SerializeField] private float Columns;
    public Transform BoardObject;
    public Color gridColor;
    private int index;

    private void Start()
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                GameObject grid = Instantiate(gridObject);
                grid.transform.SetParent(BoardObject);
                grid.transform.position = new Vector3(x, y, 0);
                grid.GetComponent<GridObject>().GridID = index;
                grid.GetComponent<SpriteRenderer>().color = gridColor;
                index++;
            }
        }
    }
}
