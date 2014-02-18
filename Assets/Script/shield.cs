using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {
    public float currHP = 1000;              // Current HP
    public float maxHP = 1000;              // Max HP
    public float regNormalTime = 0.1f;
    public float regRecoveryTime = 0.03f;         // Regenerate HP speed
    private float regTimer;                    // timer for Regenerator

    public float atk = 10;                  // Attack (       
    public float def = 5;                   // Minimum damage is 1
    
    private bool isRecoveryMode = false;    // Shield disappears when HP become 0

    // objects
    SpriteRenderer sprRend;
    Collider2D col2D;
    

	// Use this for initialization
	void Start () {
        sprRend = this.GetComponent<SpriteRenderer>();
        col2D = this.GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update () {
        Regenerate(isRecoveryMode);
        Debug.Log(currHP);

        int maxStep = 10;
        float gradation = maxHP/maxStep;

        for( int i=1; i<=maxStep; i++ ) {
            if( currHP <= i *gradation) {
                float myColor = 0.1f * (float)i;

                if (!isRecoveryMode)
                {
                    Color currColor= sprRend.color;
                    currColor.a = myColor;
                    currColor.r = 0.0f;
                    currColor.g = 0.0f;
                    currColor.b = 1.0f;
                    sprRend.color = currColor;
                }
                else
                {
                    Color currColor = sprRend.color;
                    currColor.a = myColor;
                    currColor.r = 0.0f;
                    currColor.g = 1.0f;
                    currColor.b = (float)i;
                    sprRend.color = currColor;
                }
                
                break;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {            
            col.gameObject.SendMessage("ApplyDamageByShield", atk);
        }
    }

    void ApplyDamage(float _atk)
    {       
        // when it is recovery mode, the shield ignores enemy.
        if (isRecoveryMode)
        {
            return;
        }

        float damage = _atk - def;
        if (damage <= 0)
            damage = 1;

        currHP -= damage;
        if (currHP <= 0)
        {
            currHP = 0;
            isRecoveryMode = true;
            col2D.enabled = false;
        }         
    }    

    void Regenerate(bool _isRecoveryMode)
    {
        if (_isRecoveryMode)
        {
            regTimer -= Time.deltaTime;
            if (regTimer < 0.0f)
            {
                currHP += 1.0f;
                regTimer = regRecoveryTime;
            }
        }
        else
        {
            regTimer -= Time.deltaTime;
            if (regTimer < 0.0f)
            {
                currHP += 1.0f;
                regTimer = regNormalTime;
            }
        }
        if (currHP >= maxHP)
        {
            currHP = maxHP;
            isRecoveryMode = false;
            col2D.enabled = true;
        }        
    }
}
