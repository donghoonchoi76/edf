using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooterBase : buildingbase {
    public float fShootingInterval;
    float fTimeFired;

    public buildingShooterBase() : base()
    {
        eType = BuildingType.shooter;
    }

    void Start () {
        fTimeFired = Time.time;
        Fire();
	}
	
	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();

        if ((fTimeFired + fShootingInterval) <= Time.time)
        {
            fTimeFired = Time.time;
            Fire();
        }
	}

    protected virtual void Fire() {}
}
