using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class buildingShooter : buildingbase {
    public enum ShooterType { threeway, aiming, guided };
    public ShooterType eShooterType;
    public float fShootingInterval;
    float fTimeFired;
    
	// Use this for initialization
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

    public void Fire()
    {
        if (eShooterType == ShooterType.threeway)
        {
            GameObject obj = (GameObject)Resources.Load("Prefabs/bullet0");
            Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);

            Vector3 axis = new Vector3(0.0f, 0.0f, 1.0f);
            float angle;
            gameObject.transform.rotation.ToAngleAxis(out angle, out axis);

            if (axis.z == 0.0f) axis = new Vector3(0.0f, 0.0f, 1.0f);

            angle += 30.0f;
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Instantiate(obj, this.gameObject.transform.position, q);

            angle -= 60.0f;
            q = Quaternion.AngleAxis(angle, axis);
            Instantiate(obj, this.gameObject.transform.position, q);
        }
        else if (eShooterType == ShooterType.aiming)
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
                }
            }
        }
        else if (eShooterType == ShooterType.guided)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                GameObject obj = (GameObject)Resources.Load("Prefabs/bullet1");
                Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
        }
    }
}
