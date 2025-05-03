using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private HexPosition hexPosition { get; set; }
    private HexOrientation currentOrientation {get; set;}
    private Dictionary<HexOrientation, HexPosition> orientationList;

    public Unit (HexPosition hexPosition)
    {
        this.hexPosition = hexPosition;
    }

    void Start()
    {

    }

    public void SetPosition(HexPosition hexPosition)
    {
        this.hexPosition = hexPosition;
    }
    public HexPosition GetHexPosition()
    {
        return hexPosition;
    }
    public void SetHexOrientation(HexOrientation hexOrientation)
    {
        this.currentOrientation = hexOrientation;
    }

    public void PopulateOrientations(HexPosition hexPosition)
    {
        orientationList = new Dictionary<HexOrientation, HexPosition>();
        List<HexPosition> neighbors = ProjectContext.Instance.MapService.GetNeighbors(hexPosition);
        foreach (HexOrientation orientation in Enum.GetValues(typeof(HexOrientation)))
        {
            int index = (int)orientation;
            orientationList.Add(orientation, neighbors[index]);
        }
    }

    public void showOrientations()
    {
        foreach(KeyValuePair<HexOrientation, HexPosition> kvp in orientationList)
        {
            Debug.Log($"Orientation = {kvp.Key}, Position = {kvp.Value}");
        }
    }
}
