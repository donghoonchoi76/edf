using UnityEngine;
using System.Collections;

public class targetmove : MonoBehaviour {

    public Vector2  endpos;	
	
	// Use this for initialization
	void Start () {
        float delay = Random.Range(0.01f, 3.5f);
        float spendtime = Random.Range(5.0f, 10.0f);
        iTween.MoveTo(this.gameObject, iTween.Hash("x", endpos.x, "y", endpos.y, 
                                                     "time", spendtime, "easeType", "linear", 
                                                     "loopType", "once", "delay", delay));

        iTween.RotateAdd(this.gameObject, iTween.Hash("z", 360, "easeType", "linear", "loopType", "loop", "time", 1));
	}
	
	// Update is called once per frame
	void Update () {        
        
	}
}
