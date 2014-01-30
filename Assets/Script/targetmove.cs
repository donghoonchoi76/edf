using UnityEngine;
using System.Collections;

public class targetmove : MonoBehaviour {

    public Vector2  startpos;
	public float	spendtime;
    public float    delay;
	
	// Use this for initialization
	void Start () {
        iTween.MoveFrom(this.gameObject, iTween.Hash("x", startpos.x, "y", startpos.y, 
                                                     "time", spendtime, "easeType", "easeOutExpo", 
                                                     "loopType", "once", "delay", delay));
	}
	
	// Update is called once per frame
	void Update () {        
	}
}
