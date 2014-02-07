using UnityEngine;
using System.Collections;


public class enemymgr : MonoBehaviour {
    private timer timerScript;
    private float stagetime;

	// Use this for initialization
	void Start () {
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
        Debug.Log(timerScript.currCounter);

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

        AddEnemy(0, 0);
     

        //for (int i = 0; i < 30; i++)
        //{
        //    int appeartime = Random.Range(0, 10);
        //    int enemytype = Random.Range(1,3);
        //    AddEnemy(appeartime, enemytype);
        //}

        //AddRush( 60, 75, 30, 50, 1 );    // start time(seconds), end time, min number of enemy, max number of enemy, type of enemy list
        //AddRush(120, 140, 50, 80, 2 );
    }
    void AddEnemy(float _appeartime, int _type)
    {        
        Vector3 pos = new Vector3(-1, -1, 0);
        Instantiate(GameObject.Find("stone"), pos, Quaternion.identity);       
    }



}
