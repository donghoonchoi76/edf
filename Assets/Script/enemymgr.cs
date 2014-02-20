using UnityEngine;
using System.Collections;


public class enemymgr : MonoBehaviour {
    public int distance = 5;
    public int minEnemy = 5;
    public int maxEnemy = 10;

    public float interval = 0.0f;
    private float timer = 0.0f;

    private GameObject[] enemies = new GameObject[10];          // Each type of Enemies
    private timer timerScript;
    private float stagetime;

	// Use this for initialization
	void Start () {
        enemies[0] = Resources.Load("Prefabs/enemy0") as GameObject;

        //---------------------------------------------------------
        // Initialize External Script
        //---------------------------------------------------------
        timerScript = this.GetComponent<timer>();
        timerScript.StartCounter();

        //---------------------------------------------------------
        // Initialize Object
        //---------------------------------------------------------
        InitStage(10.0f);
	}
	
	// Update is called once per frame
	void Update () {
        int numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int minRange = minEnemy;
            int maxRange = maxEnemy;

            if (numEnemies < minEnemy)
            {
                minRange = minEnemy - numEnemies;
                int num = Random.Range(minRange, maxRange + 1);
                for (int i = 0; i < num; i++)
                    AddEnemy(0);
            }            

            timer = interval;
        }        

        if (timerScript.currCounter >= stagetime)
        {
            Debug.Log("Game is Over");
            timerScript.StopCounter();
        }
        else
        {

        }

	}

    //-------------------------------------------------------------------
    // 
    //-------------------------------------------------------------------
    void InitStage(float _lastAtkTime)
    {
        stagetime = _lastAtkTime;                      // Last Attack time

        for (int i = 0; i < minEnemy; i++)
        {            
            AddEnemy(0);
        }

        timer = interval;
    }

    //-------------------------------------------------------------------
    // 
    //-------------------------------------------------------------------
    void AddEnemy(int _type)
    {
        float theta = Random.Range(0, 181);
        theta *= (Mathf.PI / 180);

        float x = Mathf.Cos(theta) * distance;       // 1 ~ -1
        float y = Mathf.Sin(theta) * distance;       // 0 ~ 1
        y = (Random.Range(0, 2) == 0) ?  -y : y;

        GameObject obj = Instantiate(enemies[_type].gameObject, new Vector3(x, y, 0), Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
        obj.transform.parent = this.transform;
    }

    public void GameStart()
    {
        enabled = true;
    }

    public void GameOver()
    {
        Debug.Log("EnemyMGR : Game Over");

        enabled = false;        
    }

}
