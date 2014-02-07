using UnityEngine;
using System.Collections;

[System.Serializable]
public class earth : MonoBehaviour {
    public const int MAX_SLOT = 20;

    public int iMaxHP;
    public int iCurrentHP;
    public int iMoney;
    public int iMoneyPerSec;

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


        iCurrentHP = 100;
        iTween.RotateBy(gameObject, iTween.Hash("z", 90, "speed", 20, "loopType", "loop", "easeType", "linear", "delay", 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) ) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 1.0f;
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            Collider2D[] col = Physics2D.OverlapPointAll(v);
            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    Debug.Log("Obj: " + c.collider.gameObject.name);
                    if(c.collider2D.gameObject.name.Equals("buildingEmpty"))
                    {
                        Debug.Log("Collided with: " + c.collider2D.gameObject.name);
                        Debug.Log("parent name: " + c.collider2D.gameObject.transform.parent.name);
                        slot slotBuilding = (slot)c.collider2D.gameObject.transform.parent.GetComponent<slot>();
                        slotBuilding.AttachWeapon("weapon0");
                    }
                }
            }

            Debug.Log("===================================");
        }
	}
}
