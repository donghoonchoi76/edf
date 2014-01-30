using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

    // Minimum setting of Timer is 0.01 second.
    private float myCounter = 0;
    private bool isPause = false;
    public float currCounter = 0;

	// Use this for initialization
	void Start () {
        myCounter = 0;
        isPause = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPause != false)
        {
            myCounter += 0.01f;
            currCounter = (int)(myCounter * 100) / 100.0f;
        }
	}
    public void StartCounter()
    {
        isPause = false;
    }
    public void StopCounter()
    {
        isPause = true;
    }
    public void ResetCounter()
    {
        myCounter = 0;
        currCounter = 0;
        StopCounter();
    }
}
