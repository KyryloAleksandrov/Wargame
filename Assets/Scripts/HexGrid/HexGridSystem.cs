using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HexGridSystem<TGridObject> where TGridObject : class
{
    private const float HEX_X_OFFSET_MULTIPLIER = .5f;
    private const float HEX_Z_OFFSET_MULTIPLIER = .75f;

    private TGridObject[,] gridObjects;
    private List<Vector3Int> neighborHexesList;
    private int width;
    private int height;
    private float hexSize;

    public HexGridSystem(int width, int height, float hexSize, Func<HexPosition, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.hexSize = hexSize;

        gridObjects = new TGridObject[width, height];

        for(int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                HexPosition hexPosition = new HexPosition(x, z);
                gridObjects[x,z] = createGridObject(hexPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(HexPosition hexPosition)
    {
        return
            new Vector3(hexPosition.x, 0, 0) * hexSize +
            new Vector3(0, 0, hexPosition.z) * hexSize * HEX_Z_OFFSET_MULTIPLIER +
            ((hexPosition.z % 2) == 1 ? new Vector3(1, 0, 0) * hexSize * HEX_X_OFFSET_MULTIPLIER : Vector3.zero);
    }

    public HexPosition GetHexGridPosition(Vector3 worldPosition)
    {
        int roughX = Mathf.RoundToInt(worldPosition.x / hexSize);
        int roughZ = Mathf.RoundToInt(worldPosition.z / hexSize / HEX_Z_OFFSET_MULTIPLIER);

        Vector3Int roughXZ = new Vector3Int(roughX, 0, roughZ);


        bool isOddRow = roughZ % 2 == 1;
        neighborHexesList = new List<Vector3Int>
        {
            roughXZ + new Vector3Int(-1, 0, 0),
            roughXZ + new Vector3Int(+1, 0, 0),

            roughXZ + new Vector3Int(isOddRow ? +1 : -1, 0, +1),
            roughXZ + new Vector3Int(+0, 0, +1),

            roughXZ + new Vector3Int(isOddRow ? +1 : -1, 0, -1),
            roughXZ + new Vector3Int(+0, 0, -1),    
        };

        Vector3Int closestGridPosition = roughXZ;

        foreach (Vector3Int neighborHex in neighborHexesList)
        {
            if(Vector3.Distance(worldPosition, GetWorldPosition(new HexPosition(neighborHex.x, neighborHex.z))) < 
               Vector3.Distance(worldPosition, GetWorldPosition(new HexPosition(closestGridPosition.x, closestGridPosition.z))))
               {
                    closestGridPosition = neighborHex;
               }
        }
        return new HexPosition(closestGridPosition.x, closestGridPosition.z);
    }

    public TGridObject[,] GetGridObjectArray()
    {
        return gridObjects;
    }
}
