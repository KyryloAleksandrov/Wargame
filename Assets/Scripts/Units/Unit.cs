using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private HexPosition hexPosition { get; set; }
    private HexOrientation hexOrientation {get; set;}

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
        this.hexOrientation = hexOrientation;
    }
}
