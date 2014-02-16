using UnityEngine;
using System.Collections;

public class uiMessage : MonoBehaviour {
    const float duration = 1.0f;
    float startTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > (startTime + duration))
        {
            gameObject.guiText.text = "";
        }
	}

    public void SetText(string str)
    {
        gameObject.guiText.text = str;
        startTime = Time.time;
    }
}
