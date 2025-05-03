using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private LayerMask hexGridMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ProjectContext.Instance.UnitService.HandleUnitSelection();
        }
        if(Input.GetMouseButtonDown(1))
        {
            if(ProjectContext.Instance.UnitService.selectedUnit != null)
            {
                ProjectContext.Instance.UnitService.selectedUnit.GetComponent<MoveAction>().Move(ProjectContext.Instance.MapService.hexGridSystem.GetWorldPosition(ProjectContext.Instance.MapService.HandleTileSelection(hexGridMask)));   //gotta make it less ugly
            }
            else
            {
                Debug.Log(ProjectContext.Instance.MapService.HandleTileSelection(hexGridMask).ToString());
                return;
            }
        }
        else
        {
            return;
        }
    }
}
