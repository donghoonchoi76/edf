using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
    public float atk;    
    public float duration;
    float startTime;
    
	// Use this for initialization
	void Start () {
        Debug.Log("Laser!!!");
        iTween.ScaleTo(gameObject, new Vector3(1.0f, 30.0f, 1.0f), 2.0f);

        startTime = Time.time;
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (Time.time >= (startTime + duration))
        {
            Vector3 vTargetPos = (gameObject.transform.rotation * new Vector3(0.0f, 1.0f, 0.0f)) * 100.0f + gameObject.transform.position;
            iTween.MoveTo(gameObject, iTween.Hash("position", vTargetPos, "speed", 15.0f, "easeType", "linear"));
            duration = 100000.0f;
            transform.parent = null;
        }
        
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
            GameObject particleHitOrg = (GameObject)Resources.Load("Prefabs/CFX_Hit_A Red");

            Vector3 vTargetPos = (transform.rotation * new Vector3(0.0f, 1.0f, 0.0f)) * col.transform.position.magnitude;
            GameObject particleHit = (GameObject)Instantiate(particleHitOrg, vTargetPos, transform.rotation);
            
            float teki = col.gameObject.GetComponent<enemybase>().score;
            GameObject.Find("UIManager").GetComponent<uimgr>().UpdateScore(teki);

            col.gameObject.SendMessage("ApplyDamageByBullet", atk);
        }
    }
}
