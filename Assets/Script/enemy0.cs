using UnityEngine;
using System.Collections;

public class enemy0 : enemybase {
    private GameObject particle;
    private GameObject particleHit;
    private GameObject particleShield;
    private GameObject objShield;

    private float timer;

    public float killTimer;
    public float minDelay = 0.01f;
    public float maxDelay = 3.5f;
    public float minSpendTime = 5.0f;
    public float maxSpendTime = 10.0f;
    private float delay;
    private float spendTime;


	// Use this for initialization
	void Start () {
        eType = EnemyType.meteorS; 
        maxhp = hp = Random.Range(20,32);

        atk = 30;
        def = 10;
        killTimer = 1.0f;
        particle = (GameObject)Resources.Load("Prefabs/CFX_SmokeExplosion");
        particleHit = (GameObject)Resources.Load("Prefabs/CFX_Hit_A Red");
        particleShield = (GameObject)Resources.Load("Prefabs/CFX_ElectricityBall_Alt");
        objShield = GameObject.FindGameObjectWithTag("Shield");

        delay = Random.Range(minDelay, maxDelay);
        spendTime = Random.Range(minSpendTime, maxSpendTime);

        iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "y", 0,
                                                     "time", spendTime, "easeType", "linear",
                                                     "loopType", "none", "delay", delay));
        float rotSpeed = Random.Range(0.7f, 3.0f);
        iTween.RotateAdd(this.gameObject, iTween.Hash("z", 360, "easeType", "linear", "loopType", "loop", "time", rotSpeed ));
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            ApplyDamageByBullet(15);            
        }
	}

    // Enemy is got damage by bullet; thus, it becomes slower and destroy.
    void ApplyDamageByBullet(float _atk)
    {
        float damage = _atk - def;
        if (damage <= 0)
            damage = 1;
        hp -= damage;

        // make it slower
        spendTime *= 1.2f;
        if (spendTime > 20.0)
            spendTime = 20.0f;
      
        iTween.MoveTo(this.gameObject, iTween.Hash( "x", 0, "y", 0,
                                                     "time", spendTime, "easeType", "linear",
                                                     "loopType", "none"));
        if (hp <= 0)
        {
            hp = 0;
            iTween.Stop(this.gameObject);
            iTween.MoveTo(this.gameObject, iTween.Hash("x", transform.position.x * 1.1, "y", transform.position.y * 1.1,
                                                        "time", killTimer, "easeType", "linear",
                                                        "loopType", "once", "oncomplete", "DestroyInSpace"));
        }
        // Hit Effect
        GameObject hit = Instantiate(particleHit, transform.position, transform.rotation) as GameObject;
    }

    // when enemy touch the shield, atk and hp are decreased.
    // Shield ignores DEF
    void ApplyDamageByShield(float _atk)
    {
        hp = ((hp - _atk) <= 0) ? 0 : (hp - _atk);
        atk = ((atk - _atk) <= 0) ? 1 : (atk - _atk);
        
        if (hp == 0)
        {
            iTween.Stop(this.gameObject);
            DestroyInSpace();
        }
        else
        {
            // make it slower
            spendTime *= 1.5f;
            if (spendTime > 20.0)
                spendTime = 20.0f;

            iTween.MoveTo(this.gameObject, iTween.Hash("x", 0, "y", 0,
                                                        "time", spendTime, "easeType", "linear",
                                                        "loopType", "none"));
        }
        GameObject hit = Instantiate(particleShield, transform.position, transform.rotation) as GameObject;
        objShield.SendMessage("ApplyDamage", atk);
    }

    // When enemy touch Earth, destroy right now!
    void ApplyDamageByEarth()
    {
        Destroy();
    }


    // Destroy with Explosion 
    void DestroyInSpace()
    {
        GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }

    // Destroy with particle Righ now!
    void Destroy()
    {
        GameObject explosion = Instantiate(particle, transform.position, transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }
}


