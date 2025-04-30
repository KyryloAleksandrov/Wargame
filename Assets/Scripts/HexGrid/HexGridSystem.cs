using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridSystem<TGridObject> where TGridObject : class
{
    private TGridObject[,] hexes;
    private int width;
    private int height;

    public HexGridSystem(int width, int height, Func<HexPosition, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        hexes = new TGridObject[width, height];

        for (int r = 0; r < height; r++)
        {
            for(int q = 0; q < width; q++)
            {
                hexes[q,r] = createGridObject(new HexPosition(q, r));
            }
        }
    }

    public TGridObject GetHex(HexPosition hexPosition)
    {
        if(hexPosition.Q < 0 || hexPosition.Q >= width || hexPosition.R < 0 || hexPosition.R >= height)
        {
            return null;
        }
        return hexes[hexPosition.Q, hexPosition.R];
    }
}
