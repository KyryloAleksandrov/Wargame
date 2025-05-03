using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridCoordinates : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    private object gridObject;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = gridObject.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetGridObject(object gridObject)
    {
        this.gridObject = gridObject;
    }
}
