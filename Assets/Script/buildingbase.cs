using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingbase : MonoBehaviour {
    public enum BuildingType { empty, shooter, miner };
    public BuildingType eType;
    public int iPrice;
    public int iHP;
    public int iDef;
    public string[] nextBuildingName = new string[uimgr.MAX_NEXT_BUILDING];
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        
	}

    public virtual void GameOver()
    {
        Debug.Log("Building Base Gameover");
        enabled = false;        
    }
}
