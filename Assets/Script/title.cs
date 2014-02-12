using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);
            
            int layerMask = 1 << LayerMask.NameToLayer("UI");
            Collider2D[] col = Physics2D.OverlapPointAll(v, layerMask);
            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.collider2D.gameObject.name.Equals("ui_start"))
                    {
                        iTween.CameraFadeTo(iTween.Hash("amount", 1.0f, "time", 0.5f, "oncomplete", "OnButton", "oncompleteparams", true, "oncompletetarget", gameObject));
                    }

                    if (c.collider2D.gameObject.name.Equals("ui_exit"))
                    {
                        iTween.CameraFadeTo(iTween.Hash("amount", 1.0f, "time", 0.5f, "oncomplete", "OnButton", "oncompleteparams", false, "oncompletetarget", gameObject));
                    }
                }
            }
        }
	}

    void OnButton(bool bGameStart)
    {
        if (bGameStart) Application.LoadLevel("MainMenu");
        else Application.Quit();
    }
}
