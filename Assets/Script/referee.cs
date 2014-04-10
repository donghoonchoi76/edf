using UnityEngine;
using System.Collections;
using System.Collections.Generic;       // List

// Count from 3
// announce game start
// decide rush or normal
// decide final rush
// decide game is over or clear

public class referee : MonoBehaviour {
    public enum GameState { 
        ready, 
        normal, 
        rush,
        final_rush, 
        gameover, 
        gameclear 
    };
    private GameState gameState;            
    private float timerReady;               // Timer for Count
    private float timerRushDuration;        // Timer for Rush Mode
    private float duration;                 // Rush mode duration

    List<float> lstRush = new List<float>();

    private float timer;                    // Game Progress timer
    private int nCountRush;                 // Total number of Rush
    private int nCurrRush;                  
        
    private earth m_earth;
    private enemymgr m_enemyMgr;

    void GameStart()
    {
        enabled = true;
    }
    void GameStop()
    {
        enabled = false;
    }

	// Use this for initialization
	void Start () {        
        timerReady = 3.5f;
        timer = 0.0f;
        gameState = GameState.ready;
        duration = 15.0f;
        timerRushDuration = duration;

        lstRush.Add(5.0f);
        lstRush.Add(15.0f);
        lstRush.Sort();

        nCountRush = lstRush.Count;    
        nCurrRush = 0;                 
        m_earth = GameObject.FindGameObjectWithTag("Earth").GetComponent<earth>();
        m_enemyMgr = GameObject.FindGameObjectWithTag("EnemyMgr").GetComponent<enemymgr>();
        m_enemyMgr.GameStop();
	}
	
	// Update is called once per frame
	void Update () {

        bool bPlaying = false;

        if (gameState == GameState.ready)                   // Countdown
        {
            timerReady -= Time.deltaTime;
            if (timerReady <= 0)
            {
                gameState = GameState.normal;
                m_enemyMgr.GameStart();
            }
            return;
        }
        if( gameState == GameState.normal )             // Change State from normal to rush modes
        {
            bPlaying = true;
            int idx = nCurrRush;

            if (idx < nCountRush)
            {
                timer += Time.deltaTime;
                if (timer >= lstRush[idx])              // becomes rush or final rush mode
                {
                    if (idx == nCountRush - 1)
                        SetFinalRushMode();
                    else
                        SetRushMode();
                }
            }
            else { 
                // This is close mode
            }
        }
        else if (gameState == GameState.rush || gameState == GameState.final_rush)
        {
            bPlaying = true;
            timerRushDuration -= Time.deltaTime;

            if (timerRushDuration <= 0)
            {
                timerRushDuration = duration;

                if (gameState == GameState.rush)
                    SetNormalMode();
                else
                    SetCloseMode();
            }
        }

        if (bPlaying)
        {
            // Game Clear Check
            if (m_enemyMgr.GetEnemyCount() == 0 && gameState == GameState.final_rush)
            {
                gameState = GameState.gameclear;
                m_earth.SendMessage("GameOver");
                m_enemyMgr.SendMessage("GameStop");
            }

            if (m_earth.GetHP() <= 0)
            {
                gameState = GameState.gameover;
                m_earth.SendMessage("GameOver");
                m_enemyMgr.SendMessage("GameStop");
            }
        }        
	}

    void SetRushMode()
    {
        gameState = GameState.rush;
        m_enemyMgr.SetGenerateRate(10);
        m_enemyMgr.SetGenerateInterval(3.0f);

        timerRushDuration = duration;
        nCurrRush++;
    }
    void SetFinalRushMode()
    {
        gameState = GameState.final_rush;
        m_enemyMgr.SetGenerateRate(10);
        m_enemyMgr.SetGenerateInterval(2.0f);

        timerRushDuration = duration;
        nCurrRush++;
    }
    void SetCloseMode()
    {
        m_enemyMgr.SetGenerateRate(0);
    }
    void SetNormalMode()
    {
        gameState = GameState.normal;
        m_enemyMgr.SetGenerateRate(4);
        m_enemyMgr.SetGenerateInterval(5.0f);
    }

    void OnGUI()
    {
        float sw = Screen.width;
        float sh = Screen.height;
        string strTime = Mathf.CeilToInt(timerReady).ToString();
        GUI.color = new Color(1, 1, 1, timerReady - Mathf.FloorToInt(timerReady));

        if (timerReady >= 0)
        {
            GUI.Label(new Rect(0, 0, sw, sh), strTime);
        }

        string strState = "Default State";
        switch (gameState)
        {
            case GameState.ready:
                strState = "Ready";
                break;
            case GameState.normal:
                strState = "Normal";
                break;
            case GameState.rush:
                strState = "Rush";
                break;
            case GameState.final_rush:
                strState = "Final Rush";
                break;
            case GameState.gameclear:
                strState = "Game Clear";
                break;
            case GameState.gameover:
                strState = "Game Over";
                break;
        }
        GUI.color = new Color(1, 0, 0, 1);
        GUI.Label(new Rect(0, 10, sw, sh), strState);
        GUI.Label(new Rect(0, 20, sw, sh), nCurrRush + "/" + nCountRush);
    }
}


/*
            timerDuration -= Time.deltaTime;
            if (timerDuration <= 0)
            {
                if (gameState == GameState.rush)
                {
                    gameState = GameState.normal;          
                    SetNormalMode();
                }
                else if (gameState == GameState.final_rush)
                {
                    m_enemyMgr.SetGenerateRate(0);      
                }
                timerDuration = duration;                
            }

 *             else if (idx >= nCountRush)
            {
                Debug.Log("Final Rush Progress");
                // Final Rush started at the last Frame.
                //if (m_enemyMgr.GetEnemyCount() == 0)
                //{
                //    gameState = GameState.gameclear;
                //}
            }

            if (m_earth.GetHP() <= 0)
            {
                gameState = GameState.gameover;
            }
 * 
 * 
 *             else {
                // Final Rush Starts at this moment.
                    if (nCurrRush >= nCountRush)
                        SetFinalRushMode();
            }

*/