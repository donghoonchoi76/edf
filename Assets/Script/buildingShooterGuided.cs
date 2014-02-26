using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooterGuided : buildingShooterBase {

    protected override void Fire()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            GameObject obj = (GameObject)Resources.Load("Prefabs/bullet1");
            Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
