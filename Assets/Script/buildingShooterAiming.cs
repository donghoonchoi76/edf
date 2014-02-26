using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooterAiming : buildingShooterBase {
    
    protected override void Fire()
    {
        GameObject[] objList = GameObject.FindGameObjectsWithTag("Enemy");
        Array.Sort(objList, delegate(GameObject obj1, GameObject obj2) {
            return (int)((obj1.transform.position.sqrMagnitude * 10.0f) - (obj2.transform.position.sqrMagnitude * 10.0f));
        });

        foreach (GameObject obj in objList)
        {
            Vector3 vObjDir = obj.transform.position - gameObject.transform.position;
            vObjDir.z = 0.0f;
            vObjDir.Normalize();
            Vector3 vShooterForward = gameObject.transform.position;
            vShooterForward.z = 0.0f;
            vShooterForward.Normalize();
            if (Vector3.Dot(vObjDir.normalized, vShooterForward.normalized) > 0.0f)
            {
                    
                Quaternion q = new Quaternion();
                q.SetFromToRotation(vShooterForward.normalized, vObjDir.normalized);

                GameObject bullet = (GameObject)Resources.Load("Prefabs/bullet0");
                Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation * q);
                break;
            }
        }
    }
}
