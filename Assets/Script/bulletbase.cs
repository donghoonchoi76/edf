using UnityEngine;
using System.Collections;

public class bulletbase : MonoBehaviour {
    public int atk = 50;
    public AudioClip sndExpl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (!permanentvariable.rtCameraBorder.Contains(gameObject.transform.position))
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            // Hit Effect
            GameObject particleHit = (GameObject)Resources.Load("Prefabs/CFX_Hit_A Red");
            Instantiate(particleHit, transform.position, transform.rotation);

            permanentvariable.PlaySound(sndExpl);

            float teki = col.gameObject.GetComponent<enemybase>().score;
            GameObject.Find("UIManager").GetComponent<uimgr>().UpdateScore(teki);

            col.gameObject.SendMessage("ApplyDamageByBullet", atk);
            Destroy(gameObject);
        }
    }
}
