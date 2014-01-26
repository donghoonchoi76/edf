using UnityEngine;
using System.Collections;

public class targetmove : MonoBehaviour {

	public Vector3 	startpos;
	public Vector3 	endpos;
	public float	speed;
	
	// Use this for initialization
	void Start () {
		transform.position = startpos;
	}
	
	// Update is called once per frame
	void Update () {	
		transform.position = Vector3.Lerp( transform.position, endpos, Time.deltaTime * speed );
	}
}
