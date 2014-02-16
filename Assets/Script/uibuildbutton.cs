using UnityEngine;
using System.Collections;

public class uibuildbutton : MonoBehaviour {
    public const string NO_BUILDING_NAME = "N/A";
    string buildName = NO_BUILDING_NAME;
    int cost = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        
	}

    public void Set(int _cost, string _buildname)
    {
        cost = _cost;
        if (_buildname == null) buildName = NO_BUILDING_NAME;
        else buildName = _buildname;

        Transform trImage = gameObject.transform.FindChild("image");
        if(trImage) 
        {
            if (buildName.Equals(NO_BUILDING_NAME))
            {
                trImage.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("images/build_ui/nobuilding", typeof(Sprite));
            }
            else
            {
                GameObject obj = (GameObject)Resources.Load("Prefabs/" + buildName);
                if (obj) trImage.gameObject.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
            }
        }

        Transform trPrice = gameObject.transform.FindChild("price");
        if(trPrice) 
        {
            if(buildName.Equals(NO_BUILDING_NAME)) trPrice.GetComponent<GUIText>().text = "";
            else trPrice.GetComponent<GUIText>().text = "$" + cost;
        }
    }

    public void OnClick(slot selSlot)
    {
        if (buildName.Equals(NO_BUILDING_NAME)) return;

        uimgr uiMgr = GameObject.Find("UIManager").GetComponent<uimgr>();
        float currMoney = uiMgr.GetMoney();

        if (cost > currMoney)
        {
            uiMgr.SetMessage("Lack of money"); 
            return;
        }

        selSlot.AttachWeapon(buildName);
        uiMgr.SetMoney(currMoney - (float)cost);
    }
}
