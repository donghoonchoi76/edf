using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingbase : MonoBehaviour {
    public enum BuildingType { empty, shooter, defender };
    public BuildingType eType;
    public int iPrice;
    public int iMaxHP;
    public int iCurrentHP;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))

            Debug.Log("Mouse up");
	}
}
