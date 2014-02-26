using UnityEngine;
using System.Collections;

[System.Serializable]
public class earth : MonoBehaviour {
    public const int MAX_SLOT = 20;
    
    int hp;
    public float def;
    
	// Use this for initialization
	void Start () {
        GameObject slot = GameObject.Find("slot0");
        Vector3 pos = slot.transform.position;

        for (int i = 1; i < MAX_SLOT; i++)
        {
            slot = GameObject.Find("slot" + i);
            slot.transform.position = pos;
            Vector3 axis = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 pibot = new Vector3(0.0f, 0.0f, 0.0f);
            slot.transform.RotateAround(pibot, axis, i * 18.0f);
        }


        hp = 100;
        def = 3;
        iTween.RotateBy(gameObject, iTween.Hash("z", 90, "speed", 20, "loopType", "loop", "easeType", "linear"));
	}

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int _hp)
    {
        hp = _hp;

        GameObject obj = GameObject.Find("UIManager");
        uimgr ui = obj.GetComponent<uimgr>();
        ui.SetUpdateUIMoneyHP();
    }
	
	// Update is called once per frame
	void Update () 
    {       
    }

    public void ApplyDamage(float _atk)
    {
        float dmg = _atk - def;
        if( dmg <= 0 ) {
            dmg = 1;
        }
        hp -= (int)dmg;

        // Game Over
        if (hp <= 0)
        {
            hp = 0;
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.SendMessage("ApplyDamageByEarth", 100000);
        }
    }

    void GameStart()
    {
        enabled = true;
    }

    void GameOver()
    {
        return;

        GameObject[] lstBuild = GameObject.FindGameObjectsWithTag("Building");
        for (int i = 0; i < lstBuild.Length; i++)
        {
            lstBuild[i].SendMessage("GameOver");
        }
        GameObject[] lst = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < lst.Length; i++)
        {
            lst[i].SendMessage("GameOver");
        }
        GameObject.FindGameObjectWithTag("Shield").SendMessage("GameOver");
        iTween.Stop(this.gameObject);

        hp = 0;
        GameObject.Find("UIManager").SendMessage("GameOver");
        


        enabled = false;    // Stop working of Script
        

        //GameObject.FindGameObjectWithTag("Enemy").SendMessage("GameOver");
        //GameObject.FindGameObjectWithTag("Shield").SendMessage("GameOver");
        //iTween.Stop(this.gameObject);
    }

}
