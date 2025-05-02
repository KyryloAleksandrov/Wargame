using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HexPosition
{
    public int x;  //column
    public int z; //row

    public HexPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString() => $"Hex({x},{z})";
}
