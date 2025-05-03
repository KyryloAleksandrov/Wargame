using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitService
{
    Unit selectedUnit {get; set;}
    List<Unit> currentUnits {get;}
    void SpawnUnit(Transform unitTransform, HexPosition hexPosition);
    void HandleUnitSelection();

}
public class UnitService : IUnitService
{
    public List<Unit> currentUnits {get;}

    public Unit selectedUnit {get; set;}

    private Vector3 verticalOffset = new Vector3(0, .25f, 0);

    public UnitService(IConfigService configService)
    {
        currentUnits = new List<Unit>();
    }

    public void SpawnUnit(Transform unitTransform, HexPosition hexPosition)
    {
        Transform newUnitTransform = GameObject.Instantiate(unitTransform, ProjectContext.Instance.MapService.hexGridSystem.GetWorldPosition(hexPosition) + verticalOffset, Quaternion.identity);
        Unit newUnit = newUnitTransform.GetComponent<Unit>();
        newUnit.SetPosition(hexPosition);
        newUnit.PopulateOrientations(hexPosition);
        currentUnits.Add(newUnit);
    }

    public void HandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Unit unit = hit.collider.GetComponent<Unit>();
                if(unit != null)
                {
                    SelectUnit(unit);
                    selectedUnit.showOrientations();
                    return;
                }
            }
            DeselectUnit();
    }

    public void SelectUnit(Unit unit)
    {
        selectedUnit = unit;
        Debug.Log($"Selected unit at {unit.GetHexPosition()}");
    }

    public void DeselectUnit()
    {
        selectedUnit = null;
        Debug.Log("Selection cleared");
    }
}
