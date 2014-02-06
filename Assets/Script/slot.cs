using UnityEngine;
using System.Collections;

public class slot : MonoBehaviour {
    public GameObject weapon;

	// Use this for initialization
	void Start () {
        AttachWeapon("weapon0");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void AttachWeapon(string objName) {
        GameObject obj = (GameObject)Resources.Load("Prefabs/" + objName);
        weapon = (GameObject)Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.localRotation);
        weapon.transform.parent = this.transform;
    }
}
