using UnityEngine;
using System.Collections;

[System.Serializable]
public class slot : MonoBehaviour {
    public GameObject weapon;

	// Use this for initialization
	void Start () {
        AttachWeapon("buildingEmpty");
	}
	
	// Update is called once per frame
	void Update () {
          
	}

    public void AttachWeapon(string objName) {
        Destroy(weapon);
        Debug.Log("AttachWeapon as : " + objName);
        GameObject obj = (GameObject)Resources.Load("Prefabs/" + objName);
        weapon = (GameObject)Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);
        weapon.transform.parent = this.transform;
        weapon.name = obj.name;
    }
}
