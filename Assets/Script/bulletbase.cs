using UnityEngine;
using System.Collections;

public class bulletbase : MonoBehaviour {
    public int atk = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (!permanentvariable.rtCameraBorder.Contains(gameObject.transform.position))
        {
            Destroy(gameObject);
        }
	}
}
