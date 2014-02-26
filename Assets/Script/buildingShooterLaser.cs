using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooterLaser : buildingShooterBase
{
    GameObject laser;

    protected override void Fire()
    {
        DestroyImmediate(laser, true);
        GameObject obj = (GameObject)Resources.Load("Prefabs/laser0");
        laser = (GameObject)Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);
        laser.transform.parent = this.transform;
    }
}
