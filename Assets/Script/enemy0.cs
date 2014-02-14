using UnityEngine;
using System.Collections;

public class enemy0 : MonoBehaviour {

    public int hp = 30;
    public int atk = 100;
    public int def = 30;

    public float killTimer = 0.0f;  // When the enemy collides with Shield
    private bool isDead = false;

    private GameObject particle;

	// Use this for initialization
	void Start () {
        particle = (GameObject)Resources.Load("Prefabs/smoke");
	}
	
	// Update is called once per frame
	void Update () {        
        if (!isDead)
            return;

        killTimer -= Time.deltaTime;
        if (killTimer < 0.0f)
        {
            GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
            Destroy(this.gameObject);
        }
	}

    void Damage(int _atkOfOther)
    {
        int damage = _atkOfOther - def;
        if (damage < 0)
            damage = 0;

        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
            isDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Earth")
        {
            GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
            Destroy(this.gameObject);
        }
        if (col.tag.Equals("Bullet"))
        {
            Damage(col.gameObject.GetComponent<bulletbase>().atk);
            Destroy(col.gameObject);
            GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
        }
    }
}
