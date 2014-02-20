using UnityEngine;
using System.Collections;

public class enemybase : MonoBehaviour {
    public enum EnemyType 
    { 
        temp, 
        meteorS, 
        meteorL, 
        ufo 
    };
    public EnemyType eType;
    public float maxhp;
    public float hp;
    public float atk;
    public float def;

    public float score;
    
    public virtual void GameOver()
    {
        Debug.Log("Enemy Base Gameover");
        DestroyByEvent();
        enabled = false;
    }
    public virtual void DestroyByEvent() { }
}