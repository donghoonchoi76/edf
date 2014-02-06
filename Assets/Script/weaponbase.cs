using UnityEngine;
using System.Collections;

public class weaponbase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int cnt = Input.touchCount;
        if (cnt != 0) Debug.Log("Touched");
	}
}
