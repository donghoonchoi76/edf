using UnityEngine;
using System.Collections;

[System.Serializable]
public class buildingMiner : buildingbase
{
    public float fMiningUpdateInterval = 1.0f;
    public float fHealingEarthUpdateInterval = 1.0f;
    public float fHealingShieldUpdateInterval = 1.0f;

    public float fMiningSpeed = 0.0f;
    public float fHealingEarthSpeed = 0.0f;
    public float fHealingShieldSpeed = 0.0f;

    float fLastMiningUpdateTime = 1.0f;
    float fLastHealingEarthUpdateTime = 1.0f;
    float fLastHealingShieldUpdateTime = 1.0f;

    public buildingMiner() : base()
    {
        eType = BuildingType.shooter;
    }

    void Start()
    {
        fLastMiningUpdateTime = Time.time;
        fLastHealingEarthUpdateTime = Time.time;
        fLastHealingShieldUpdateTime = Time.time;
    }
	
	protected override void Update()
    {
        base.Update();

        if ((fLastMiningUpdateTime + fMiningUpdateInterval) <= Time.time)
        {
            float money = fMiningSpeed * (Time.time - fLastMiningUpdateTime);
             
            uimgr uiMgr = GameObject.Find("UIManager").GetComponent<uimgr>();
            float currMoney = uiMgr.GetMoney();

            uiMgr.SetMoney(currMoney + money);

            fLastMiningUpdateTime = Time.time;
        }

        if ((fLastHealingEarthUpdateTime + fHealingEarthUpdateInterval) <= Time.time)
        {
            float hp = fHealingEarthSpeed * (Time.time - fLastHealingEarthUpdateTime);

            GameObject obj = GameObject.Find("earth");
            earth e = obj.GetComponent<earth>();
            int _hp = e.GetHP();

            Debug.Log("hp added : " + (int)hp);
            e.SetHP(_hp + (int)hp);

            fLastHealingEarthUpdateTime = Time.time;
        }

        if ((fLastHealingShieldUpdateTime + fHealingShieldUpdateInterval) <= Time.time)
        {
            /*
            float shp = fHealingShieldSpeed * (Time.time - fLastHealingShieldUpdateTime);

            

            fLastHealingShieldUpdateTime = Time.time;
             */
        }
    }
}
