using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingEmpty : buildingbase
{
    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnMouseUp()
    {
        Debug.Log("Drag ended!");
    }
}