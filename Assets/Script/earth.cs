using UnityEngine;
using System.Collections;

public class earth : MonoBehaviour {
    public const int MAX_SLOT = 20;

    private int iHP;

	// Use this for initialization
	void Start () {
        GameObject slot = GameObject.Find("slot0");
        Vector3 pos = slot.transform.position;

        for (int i = 1; i < MAX_SLOT; i++)
        {
            slot = GameObject.Find("slot" + i);
            slot.transform.position = pos;
            Vector3 axis = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 pibot = new Vector3(0.0f, 0.0f, 0.0f);
            slot.transform.RotateAround(pibot, axis, i * 18.0f);
        }


        iHP = 100;
        iTween.RotateBy(gameObject, iTween.Hash("z", 90, "speed", 20, "loopType", "loop", "easeType", "linear", "delay", 0));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
