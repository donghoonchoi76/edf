using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class bullet1 : bulletbase
{
    const float GUIDE_READY_TIME = 0.2f;
    const float ROTATION_SPEED = 60.0f;
    bool bChase = false;
    public float fSpeed;
    float fTimeFired; 
    
    // Use this for initialization
    void Start()
    {
        Vector3 vTargetPos = (gameObject.transform.rotation * new Vector3(0.0f, 1.0f, 0.0f)) * 100.0f + gameObject.transform.position;
        iTween.MoveTo(gameObject, iTween.Hash("position", vTargetPos, "speed", fSpeed, "easeType", "linear"));

        fTimeFired = Time.time;
        bChase = false;
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (bChase) Chase();

        if (!bChase && (Time.time - fTimeFired) > GUIDE_READY_TIME) 
        {
            bChase = true;
            iTween.Stop(gameObject);
        }
    }

    void Chase()
    {
        float fDist = fSpeed * Time.deltaTime;

        GameObject[] objList = GameObject.FindGameObjectsWithTag("Enemy");

        Vector3 p = - gameObject.transform.position;

        if (objList.Length > 0)
        {
            GameObject objTarget = objList[0];
            p = objTarget.transform.position - gameObject.transform.position;
            Vector3 currDir = gameObject.transform.rotation * new Vector3(0, 1, 0);

            float d = Vector3.Dot(currDir, p.normalized);
            float angle_dist = ROTATION_SPEED * fDist;
            if (d < Mathf.Cos(Mathf.Deg2Rad * angle_dist))
            {
                float angle;
                Vector3 axis;
                gameObject.transform.rotation.ToAngleAxis(out angle, out axis);
                if (axis.z == 0.0f) axis = new Vector3(0.0f, 0.0f, 1.0f);

                Vector3 vC = Vector3.Cross(currDir, p.normalized);
                if ((vC.z * axis.z) > 0.0f) angle += angle_dist;
                else angle -= angle_dist;
        
                Quaternion q = Quaternion.AngleAxis(angle, axis);
                p = q * new Vector3(0, 1, 0);
            }

            Vector3 nextPos = gameObject.transform.position + (p.normalized * fDist);
            if(nextPos.sqrMagnitude < 4.0f) 
            {
                p = Vector3.Cross(p.normalized, -gameObject.transform.position.normalized);
                if (p.z >= 0.0f) p = new Vector3(0.0f, 0.0f, 1.0f);
                else p = new Vector3(0.0f, 0.0f, -1.0f);

                p = Vector3.Cross(p.normalized, gameObject.transform.position.normalized);
            }

            gameObject.transform.rotation = Quaternion.FromToRotation(new Vector3(0, 1, 0), p.normalized);
            gameObject.transform.position += (p.normalized * fDist);
        }
    }
}

