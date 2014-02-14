using UnityEngine;
using System.Collections;

[System.Serializable]
public class bullet0 : bulletbase
{
    public float fSpeed;

	// Use this for initialization
	void Start () {
        Vector3 vTargetPos = (gameObject.transform.rotation * new Vector3(0.0f, 1.0f, 0.0f)) * 100.0f + gameObject.transform.position;
        iTween.MoveTo(gameObject, iTween.Hash("position", vTargetPos, "speed", fSpeed, "easeType", "linear"));
	}
	
	// Update is called once per frame
	/*
    protected override void Update () {
        base.Update();
	}*/
}
