using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridObject
{
    private HexPosition hexPosition;

    public HexGridObject(HexPosition hexPosition)
    {
        this.hexPosition = hexPosition;
    }

    public HexPosition GetHexPosition()
    {
        return hexPosition;
    }

    public override string ToString() => $"HexObject @ {hexPosition}";
}
