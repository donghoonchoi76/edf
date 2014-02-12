using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {
    protected const int MAX_STAGE = 6;
    protected int nextStage;

	// Use this for initialization
	void Start () {
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1.0f, 0.5f);

        nextStage = PlayerPrefs.GetInt("nextStage", 0);

        for (int i = 0; i < MAX_STAGE; i++)
        {
            GameObject stage = GameObject.Find("stage"+i);
            SpriteRenderer r = stage.GetComponent<SpriteRenderer>();

            if (i <= nextStage) r.color = Color.white;
            else r.color = Color.gray;
        }
	}

    // Update is called once per frame
    void Update()
    {
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
                    if (c.collider2D.gameObject.name.Equals("ui_back"))
                    {
                        iTween.CameraFadeTo(iTween.Hash("amount", 1.0f, "time", 0.5f, "oncomplete", "GoStage", "oncompleteparams", -1, "oncompletetarget", gameObject));
                    }
                    else
                    {
                        string selectedStage = c.collider2D.gameObject.name.Substring(5);
                        Debug.Log("Seletected Stage : " + selectedStage);
                        int iSel = int.Parse(selectedStage);

                        if (iSel <= nextStage)
                        {
                            iTween.CameraFadeTo(iTween.Hash("amount", 1.0f, "time", 0.5f, "oncomplete", "GoStage", "oncompleteparams", iSel, "oncompletetarget", gameObject));
                        }
                    }
                }
            }
        }
	}

    void GoStage(int stage)
    {
        if (stage < 0) Application.LoadLevel("Title");
        else {
            permanentvariable.currentStage = stage;
            Application.LoadLevel("Play");
        }
    }
}
