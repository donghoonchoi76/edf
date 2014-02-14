using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingbase : MonoBehaviour {
    public enum BuildingType { empty, shooter, miner };
    public BuildingType eType;
    public int iPrice;
    public int iHP;
    public int iDef;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        
	}

    void Clicked()
    {
        Debug.Log("Building is clicked......");
    }
}
