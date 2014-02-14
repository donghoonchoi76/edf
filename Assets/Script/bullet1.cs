using UnityEngine;
using System;
//using System.Collections;

[System.Serializable]
public class bullet1 : bulletbase
{
    const float GUIDE_READY_TIME = 0.2f;
    bool bChase = false;
    public float fSpeed;
    float fPrevTime;
    
    // Use this for initialization
    void Start()
    {
        Vector3 vTargetPos = (gameObject.transform.rotation * new Vector3(0.0f, 1.0f, 0.0f)) * 100.0f + gameObject.transform.position;
        iTween.MoveTo(gameObject, iTween.Hash("position", vTargetPos, "speed", fSpeed, "easeType", "linear"));

        fPrevTime = Time.time;
        bChase = false;
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (bChase) Chase();

        if (!bChase && (Time.time - fPrevTime) > GUIDE_READY_TIME) 
        {
            bChase = true;
            fPrevTime = Time.time;
            iTween.Stop(gameObject);
        }
    }

    void Chase()
    {
        float fSecPerFrame = Time.time - fPrevTime;
        float fDist = fSpeed * fSecPerFrame;

        GameObject[] objList = GameObject.FindGameObjectsWithTag("Enemy");

        Vector3 p = - gameObject.transform.position;

        if (objList.Length > 0)
        {
            GameObject objTarget = objList[0];
            p = objTarget.transform.position - gameObject.transform.position;
            Vector3 currDir = gameObject.transform.rotation * new Vector3(0, 1, 0);

            float d = Vector3.Dot(currDir, p.normalized);
            if(d < Mathf.Cos(3.14f * fSecPerFrame))
            {
                float angle;
                Vector3 axis;
                gameObject.transform.rotation.ToAngleAxis(out angle, out axis);
                if (axis.z == 0.0f) axis = new Vector3(0.0f, 0.0f, 1.0f);

        
                float angle_delta = 180.0f * fSecPerFrame;
                Vector3 vC = Vector3.Cross(currDir, p.normalized);
                if((vC.z * axis.z) > 0.0f) angle += angle_delta;
                else angle -= angle_delta;
        
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
       
        fPrevTime = Time.time;
    }
}

