using UnityEngine;
using System.Collections;


public class enemymgr : MonoBehaviour {
    public float distance;
    private float timer;
    private float interval;
    private int nGenerateEnemyAtOnce;
    private GameObject[] enemies = new GameObject[10];          // Each type of Enemies

    public void GameStart()
    {
        enabled = true;
    }
    public void GameStop()
    {
        enabled = false;
    }

	// Use this for initialization
	void Start () {        
        distance = 20.0f;
        timer = 0.0f;

        SetGenerateInterval(3.0f);
        SetGenerateRate(5);
        enemies[0] = Resources.Load("Prefabs/enemy0") as GameObject;
	}

    bool flag = false;

	// Update is called once per frame
	void Update () {       
        GenerateEnemy();        
	}

    void AddEnemy(int _type)
    {
        float theta = Random.Range(0, 181);
        theta *= (Mathf.PI / 180);

        float x = Mathf.Cos(theta) * distance;       // 1 ~ -1
        float y = Mathf.Sin(theta) * distance;       // 0 ~ 1
        y = (Random.Range(0, 2) == 0) ?  -y : y;

        GameObject obj = Instantiate(   enemies[_type].gameObject, new Vector3(x, y, 0), 
                                        Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
        obj.transform.parent = this.transform;
    }

    // 
    public void SetGenerateRate(int _n)
    {
        nGenerateEnemyAtOnce = _n;
    }
    public void SetGenerateInterval(float _interval)
    {
        interval = _interval;
    }
    void GenerateEnemy()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            for (int i = 0; i < nGenerateEnemyAtOnce; i++)
            {
                AddEnemy(0);
            }
            timer = 0.0f;
        }
    }
    public int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
