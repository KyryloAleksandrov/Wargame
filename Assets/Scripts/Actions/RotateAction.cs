using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : BaseAction
{
    float rotateSpeed = 10f;
    public override string GetActionName()
    {
        return "Rotate";
    }

    public override List<HexPosition> GetValidActionGridPositionList()
    {
        throw new NotImplementedException();
    }

    public override void TakeAction(HexPosition hexPosition, Action onActionComplete)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
