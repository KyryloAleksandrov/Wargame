using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        ProjectContext.Instance.MapService.InitializeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
