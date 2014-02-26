using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingEmpty : buildingbase {
    public buildingEmpty() : base()
    {
        eType = BuildingType.shooter;
    }
    
    void Start()
    {
    }

    protected override void Update()
    {
         base.Update();
    }
}