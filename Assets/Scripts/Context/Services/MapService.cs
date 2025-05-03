using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public interface IMapService
{
    HexGridSystem<HexGridObject> hexGridSystem {get; set;}
    void InitializeGrid();
    HexPosition HandleTileSelection(LayerMask layerMask);
    List<HexPosition> GetNeighbors(HexPosition hexPosition);
}
public class MapService : IMapService
{
    public HexGridSystem<HexGridObject> hexGridSystem {get; set;}

    private int width;
    private int height;
    private float hexSize;
    private Transform hexTilePrefab;
    private Transform gridCoordinatesPrefab;

    public MapService(IConfigService configService)
    {
        width = configService.MapData.width;
        height = configService.MapData.height;
        hexSize = configService.MapData.hexSize;
        hexTilePrefab = configService.MapData.hexTilePrefab;
        gridCoordinatesPrefab = configService.MapData.gridCoordinatesPrefab;
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

                Transform coordinatesTransform = GameObject.Instantiate(gridCoordinatesPrefab, hexGridSystem.GetWorldPosition(hexPosition), Quaternion.identity);
                GridCoordinates gridCoordinates = coordinatesTransform.GetComponent<GridCoordinates>();
                gridCoordinates.SetGridObject(hexGridSystem.GetGridObject(hexPosition));
            }
        }
    }

    public HexPosition HandleTileSelection(LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask);
        HexPosition currentPosition = hexGridSystem.GetHexGridPosition(raycastHit.point);
        //Debug.Log(currentPosition.ToString());
        return currentPosition;
    }

    public List<HexPosition> GetNeighbors(HexPosition hexPosition)
    {
        List<HexPosition> neighbors = new List<HexPosition>();

        bool isOddRow = hexPosition.z % 2 != 0;

        List<Vector3Int> oddNeighbors = new List<Vector3Int>
        {
            new Vector3Int(1, 0, 1),    //North-East
            new Vector3Int(1, 0, 0),    //East
            new Vector3Int(1, 0, -1),   //South-East
            new Vector3Int(0, 0, -1),   //South-West
            new Vector3Int(-1, 0, 0),   //West
            new Vector3Int(0, 0, 1),    //North-West
        };

        List<Vector3Int> evenNeighbors = new List<Vector3Int>
        {
            new Vector3Int(0, 0, 1),    //North-East
            new Vector3Int(1, 0, 0),    //East
            new Vector3Int(0, 0, -1),   //South-East
            new Vector3Int(-1, 0, -1),   //South-West
            new Vector3Int(-1, 0, 0),   //West
            new Vector3Int(-1, 0, 1),    //North-West
        };

        List<Vector3Int> trueNeighbors = isOddRow ? oddNeighbors : evenNeighbors;

        foreach(var neighbor in trueNeighbors)
        {
            neighbors.Add(new HexPosition(hexPosition.x + neighbor.x, hexPosition.z + neighbor.z));
        }

        /*foreach(var hexpos in neighbors)
        {
            Debug.Log(hexpos.ToString());
        }*/
        return neighbors;
    }
}
