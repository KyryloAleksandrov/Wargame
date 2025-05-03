using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    public static GameMaster Instance
    {
        get{
            if(instance == null)
            instance = new GameMaster();
            return instance;
        }
    }

    void Awake()
    {
        ProjectContext.Instance.MapService.InitializeGrid();
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform newUnitTransform = ProjectContext.Instance.ConfigService.UnitData[0].unit;
        ProjectContext.Instance.UnitService.SpawnUnit(newUnitTransform, new HexPosition(1,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
