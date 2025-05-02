using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMapService
{
    HexGridSystem<HexGridObject> hexGridSystem {get; set;}
    void InitializeGrid();
}
public class MapService : IMapService
{
    public HexGridSystem<HexGridObject> hexGridSystem {get; set;}

    private int width;
    private int height;
    private float hexSize;
    private Transform hexTilePrefab;

    public MapService(IConfigService configService)
    {
        width = configService.MapData.width;
        height = configService.MapData.height;
        hexSize = configService.MapData.hexSize;
        hexTilePrefab = configService.MapData.hexTilePrefab;
    }

    public void InitializeGrid()
    {
        hexGridSystem = new HexGridSystem<HexGridObject>(width, height, hexSize, hexPosition => new HexGridObject(hexPosition));
        HexGridObject[,] hexGridObjects = hexGridSystem.GetGridObjectArray();
        for (int x = 0; x < hexGridObjects.GetLength(0); x++)
        {
            for (int z = 0; z < hexGridObjects.GetLength(1); z++)
            {
                HexPosition hexPosition = hexGridObjects[x,z].GetHexPosition();
                GameObject.Instantiate(hexTilePrefab, hexGridSystem.GetWorldPosition(hexPosition), Quaternion.identity);
            }
        }
    }
}
