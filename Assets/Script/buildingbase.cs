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
	protected void Update () {
        
	}

    protected void Clicked()
    {
        Debug.Log("Building is clicked......");
    }
}
