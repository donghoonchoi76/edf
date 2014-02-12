using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingShooter : buildingbase {
    public float fShootingInterval;
    public float fBulletSpeed;
    public float fRadarDistance;
    public float fRadarAngle;
    public int iNumBulletPerFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () 
    {
        base.Update();
	}
}
