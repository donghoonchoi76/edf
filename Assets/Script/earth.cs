using UnityEngine;
using System.Collections;

public class earth : MonoBehaviour {
    private int iHP;

	// Use this for initialization
	void Start () {
        iHP = 100;
        iTween.RotateBy(gameObject, iTween.Hash("z", 90, "speed", 20, "loopType", "loop", "easeType", "linear", "delay", 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
