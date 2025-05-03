using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAction : BaseAction
{
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;
    [SerializeField] private int maxMoveDistance = 4;
    
    private List<Vector3> positionList;
    private int currentPositionIndex;
    
    float moveSpeed = 4f;
    float stoppingDistance = 0.1f;
    float rotateSpeed = 10f;

    Vector3 verticalOffset = new Vector3(0, 0.5f, 0);
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        Vector3 targetPosition = destination + verticalOffset;
        Vector3 moveDirection = (targetPosition - transform.position).normalized; 

        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        if(Vector3.Distance(transform.position, targetPosition) > stoppingDistance){
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
        
        else
        {
            Debug.Log("Reached destination at: " + ProjectContext.Instance.MapService.hexGridSystem.GetHexGridPosition(targetPosition));
            unit.PopulateOrientations(ProjectContext.Instance.MapService.hexGridSystem.GetHexGridPosition(targetPosition));
            unit.showOrientations();
            isActive = false;
        }
        
    }

    public override void TakeAction (HexPosition hexPosition, Action onActionComplete)
    {
        /*List<GridPosition> pathGridPositionList = Pathfinding.Instance.FindPath(unit.GetGridPosition(), hexPosition, out int pathLength);
        currentPositionIndex = 0;
        positionList = new List<Vector3>();

        foreach(GridPosition pathGridPosition in pathGridPositionList)
        {
            positionList.Add(LevelGrid.Instance.GetWorldPosition(pathGridPosition));
        }
        
        OnStartMoving?.Invoke(this, EventArgs.Empty);
        ActionStart(onActionComplete);*/
    }

    public override List<HexPosition> GetValidActionGridPositionList()
    {
        List<HexPosition> validHexPosition = new List<HexPosition>();
        
        /*GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxMoveDistance; x<= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z<= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if (unitGridPosition == testGridPosition)
                {
                    //position where unit is in already
                    continue;
                }

                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    //grid position is already occupied with another unit
                    continue;
                }

                if(!Pathfinding.Instance.IsWalkableGridPosition(testGridPosition))
                {
                    //Not walkable
                    continue;
                }

                if(!Pathfinding.Instance.HasPath(unitGridPosition, testGridPosition))
                {
                    //No Path
                    continue;
                }
                int pathFindingDistanceMultiplier = 10;
                if(Pathfinding.Instance.GetPathLength(unitGridPosition, testGridPosition) > maxMoveDistance * pathFindingDistanceMultiplier)
                {
                    //Too far
                    continue;
                }

                validHexPosition.Add(testGridPosition);
                //Debug.Log(testGridPosition);
            }
        }*/

        return validHexPosition;
    }

    public override string GetActionName()
    {
        return "Move";
    }

    public void Move(Vector3 destination)
    {
        this.destination = destination;
        isActive = true;
    }

    /*public override EnemyAIAction GetBestEnemyAIAction(GridPosition gridPosition)
    {
        int targetCountAtGridPosition = unit.GetAction<ShootAction>().GetTargetCountAtPosition(gridPosition);
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = targetCountAtGridPosition * 10,
        };
    }*/

    

}
