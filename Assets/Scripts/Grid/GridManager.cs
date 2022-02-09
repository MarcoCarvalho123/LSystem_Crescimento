using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public float x_Position, y_Position, z_Position;
    public int ColumnLength, RowLength;
    public int x_Space, y_Space, z_Space;
    public GameObject prefab;
    public GameObject parent;

    void Start()
    {
        for (int i = 0; i < ColumnLength * RowLength; i++)
        {  
            Instantiate(prefab, new Vector3(x_Position + (x_Space * (i % ColumnLength)), y_Position + (-y_Space * (i / ColumnLength)), z_Position + (z_Space * (i / ColumnLength))), Quaternion.identity, prefab.transform.parent = parent.transform);
           

        }

    }
}

