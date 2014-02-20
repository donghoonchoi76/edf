using UnityEngine;
using System.Collections;

public class bulletbase : MonoBehaviour {
    public int atk = 50;

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
        /*
if (col.tag.Equals("Bullet"))
        {
            Damage(col.gameObject.GetComponent<bulletbase>().atk);
            Destroy(col.gameObject);
            GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
        }
*/
        if (col.tag == "Enemy")
        {
            float teki = col.gameObject.GetComponent<enemybase>().score;
            GameObject.Find("UIManager").GetComponent<uimgr>().UpdateScore(teki);

            col.gameObject.SendMessage("ApplyDamageByBullet", atk);
            Destroy(gameObject);
        }
    }
}
