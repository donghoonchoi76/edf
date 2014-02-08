using UnityEngine;
using System.Collections;

public class uimgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
                    //Debug.Log("Obj: " + c.collider2D.gameObject.name);
                    if(c.collider2D.gameObject.tag.Equals("slot"))
                    {
                        //Debug.Log("Collided with: " + c.collider2D.gameObject.name);
                        //Debug.Log("parent name: " + c.collider2D.gameObject.transform.parent.name);
                        slot slotBuilding = c.collider2D.gameObject.transform.GetComponent<slot>();
                        if(slotBuilding != null) slotBuilding.AttachWeapon("weapon0");
                    }
                }
            }
        }
	}
}
