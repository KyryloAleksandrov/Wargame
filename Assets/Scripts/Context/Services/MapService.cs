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

    public MapService(IConfigService configService)
    {
        width = configService.MapData.width;
        height = configService.MapData.height;
        hexSize = configService.MapData.hexSize;
    }

    public void InitializeGrid()
    {
        hexGridSystem = new HexGridSystem<HexGridObject>(width, height, hexPosition => new HexGridObject(hexPosition));
    }
}
