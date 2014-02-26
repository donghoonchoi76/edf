using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooterMultiway : buildingShooterBase {
    public int numWays;
    
    protected override void Fire()
    {
        Vector3 axis = new Vector3(0.0f, 0.0f, 1.0f);
        float angle;
        gameObject.transform.rotation.ToAngleAxis(out angle, out axis);
        if (axis.z == 0.0f) axis = new Vector3(0.0f, 0.0f, 1.0f);
        angle -= 90.0f;
        
        if (numWays <= 0) numWays = 1;
        float angleFrag = 180.0f / (numWays + 1);

        GameObject obj = (GameObject)Resources.Load("Prefabs/bullet0");
        for (int i = 0; i < numWays; i++)
        {
            angle += angleFrag;
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Instantiate(obj, transform.position, q);
        }
    }
}
