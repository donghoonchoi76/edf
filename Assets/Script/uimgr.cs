using UnityEngine;
using System.Collections;

public class uimgr : MonoBehaviour {
    public const int MAX_NEXT_BUILDING = 2;
    public const float MONEY_PER_SEC = 10.0f;
    public bool bGameOver = false;
    
    string selSlotName = "";
    float money = 100;
    float score = 0;
   
    bool bUpdateUIMoneyHP;

	// Use this for initialization
	void Start () {
        float minHalfBorderX = Camera.main.orthographicSize * Camera.main.aspect + 1.0f;
        float minHalfBorderY = Camera.main.orthographicSize + 1.0f;
        permanentvariable.rtCameraBorder = new UnityEngine.Rect(-minHalfBorderX, -minHalfBorderY, minHalfBorderX * 2.0f, minHalfBorderY * 2.0f);
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1.0f, 0.5f);

        GameStart();
        ShowUIBuild(false, null);
        bUpdateUIMoneyHP = true;
	}

    public void SetMessage(string str) 
    {
        Transform tr = transform.FindChild("UI_Message");
        tr.GetComponent<uiMessage>().SetText(str);
    }

    public void SetUpdateUIMoneyHP() { bUpdateUIMoneyHP = true; }
    public float GetMoney() { return money; }

    public void SetMoney(float _money)
    {
        money = _money;
        bUpdateUIMoneyHP = true;
    }

    public void UpdateScore(float _addScore)
    {
        score += _addScore;
        Transform tr = transform.FindChild("score");
        tr.guiText.text = "score:" + score;
    }

    void UpdateUIMoneyHP()
    {
        int iCurrMoney = 0;
        if (bGameOver)
        {
            transform.FindChild("UI_MoneyHP").guiText.text = "";
            bUpdateUIMoneyHP = false;
            return;
        }

        int iPrevMoney = (int)(money * 0.1f);
        money += (Time.deltaTime * MONEY_PER_SEC);
        iCurrMoney = (int)(money * 0.1f);
        if (iPrevMoney != iCurrMoney) bUpdateUIMoneyHP = true;

        if (bUpdateUIMoneyHP == false) return;
        iCurrMoney *= 10;
        
        GameObject obj = GameObject.Find("earth");
        earth e = obj.GetComponent<earth>();
        int _hp = e.GetHP();

        Transform tr = transform.FindChild("UI_MoneyHP");

        tr.guiText.text = "$:" + iCurrMoney + " HP:" + _hp + "%";

        bUpdateUIMoneyHP = false;
    }

	// Update is called once per frame
	void Update () {
        if (bGameOver)
        {

            return;
        }

        GameObject selSlot = null;
        if (selSlotName != null) selSlot = GameObject.Find(selSlotName);
        if(selSlot == null) ShowUIBuild(false, null);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            //Debug.Log("mouse position : " + mousePosition.x +" " + mousePosition.y +" " + mousePosition.z);
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);
            //Debug.Log("Camera Pos : " + v.x + " " + v.y);

            int layerMask = 1 << LayerMask.NameToLayer("UI");
            Collider2D[] col = Physics2D.OverlapPointAll(v, layerMask);
            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.collider2D.gameObject.tag.Equals("Slot"))
                    {
                        ShowUIBuild(true, c.collider2D.gameObject.name);
                        //Debug.Log("Collided with: " + c.collider2D.gameObject.name);
                        //Debug.Log("parent name: " + c.collider2D.gameObject.transform.parent.name);
                    }
                    else if(c.collider2D.gameObject.tag.Equals("BtnBuild"))
                    {
                        if (selSlot != null)
                        {
                            slot slotBuilding = selSlot.transform.GetComponent<slot>();
                            if (slotBuilding != null) c.collider2D.gameObject.GetComponent<uibuildbutton>().OnClick(slotBuilding);
                        }

                        ShowUIBuild(false, null);
                    }
                }
            }
            else ShowUIBuild(false, null);
        }

        UpdateUIMoneyHP();
        
	}

    void ShowUIBuild(bool bShow, string slotName)
    {
        if (slotName == null) bShow = false;

        Transform uiBuild = transform.FindChild("UI_BUILD");
        permanentvariable.ToggleVisibility(uiBuild, bShow);
        GameObject tagSlot = GameObject.Find("build_tag");
        if(tagSlot != null) tagSlot.renderer.enabled = bShow;

        if (bShow == false) selSlotName = null;
        else
        {
            selSlotName = slotName;

            GameObject obj = GameObject.Find(selSlotName);
            if(obj != null)
            {
                if(tagSlot != null) tagSlot.transform.rotation = obj.transform.rotation;

                Transform transCurrBuilding = null;
                for(int i=0; i<obj.transform.childCount; i++)
                {
                    Transform c = obj.transform.GetChild(i);
                    if(c.tag.Equals("Building"))
                    {
                        transCurrBuilding = c;
                        break;
                    }
                }

                buildingbase b = transCurrBuilding.GetComponent<buildingbase>();

                Transform btn = uiBuild.FindChild("build_discard");
                if(btn != null)
                {
                    btn.GetComponent<uibuildbutton>().Set(-b.iPrice, "buildingEmpty");
                }

                for(int i=0; i<MAX_NEXT_BUILDING;i++)
                {
                    btn = uiBuild.FindChild("build_" + i);
                    if(btn != null)
                    {
                        if (b.nextBuildingName[i] == null ||
                            b.nextBuildingName[i].Length <= 0)
                        {
                            btn.GetComponent<uibuildbutton>().Set(0, null);
                        }
                        else
                        {
                            GameObject objNext = (GameObject)Resources.Load("Prefabs/" + b.nextBuildingName[i]);
                            if (objNext != null)
                            {
                                btn.GetComponent<uibuildbutton>().Set(objNext.GetComponent<buildingbase>().iPrice, b.nextBuildingName[i]);
                            }
                            else
                            {
                                btn.GetComponent<uibuildbutton>().Set(0, null);
                            }
                        }
                    }
                }
            }
        }
    }

    public void GameStart()
    {
        bGameOver = false;
        transform.FindChild("Result").FindChild("result_score").guiText.text = "";
        //enabled = true;
    }
    public void GameOver()
    {
        bGameOver = true;
        UpdateUIMoneyHP();
        transform.FindChild("score").guiText.text = "";
        StartCoroutine(WaitCoroutine());
        
        //enabled = false;
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1.5f);     
        transform.FindChild("Result").FindChild("result_score").guiText.text = "Score : " + score;

        yield return new WaitForSeconds(1);
        transform.FindChild("Result").FindChild("result_score").guiText.text = "Click to Start";
        while (!Input.GetButtonDown("Fire1"))
        {
            yield return new WaitForFixedUpdate();
        }
        Application.LoadLevel("MainMenu");    
    }
}