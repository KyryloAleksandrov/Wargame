using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HexPosition
{
    public int Q;  //column
    public int R; //row

    public HexPosition(int column, int row)
    {
        this.Q = column;
        this.R = row;
    }

    public Vector3 ToWorld(float hexSize)
    {
        float x = hexSize * (Mathf.Sqrt(3f) * Q + Mathf.Sqrt(3f)/2f * R);
        float z = hexSize * (3f/2f * R);
        return new Vector3(x, 0, z);
    }
}
