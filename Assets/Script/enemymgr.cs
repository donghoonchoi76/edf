using UnityEngine;
using System.Collections;


public class enemymgr : MonoBehaviour {
    public int distance = 5;
    public int minEnemy = 5;
    public int maxEnemy = 10;

    public float interval = 0.0f;
    private float timer = 0.0f;

    private GameObject[] enemies = new GameObject[10];  
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
        //Debug.Log(timerScript.currCounter);

        //Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);

        int numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        timer -= Time.deltaTime;
        if (timer < 0)
        {

            int num = Random.Range(minEnemy, maxEnemy + 1 - numEnemies);

            for (int i = 0; i < num; i++)
                AddEnemy(0);

            timer = interval;
        }
        
        
        

        if ( numEnemies < minEnemy )
        {
            AddEnemy(0);
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

        Instantiate(enemies[_type].gameObject, new Vector3(x, y, 0), Quaternion.Euler(0,0,Random.Range(0, 360)));
    }
}
