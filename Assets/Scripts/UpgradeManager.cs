using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    public UnityEngine.UI.Text itemInfo;
    public UnityEngine.UI.Text nameAndLevel;
    public Button miner;
    public Button button;
    public int i;
    private Miner m;
    //Data data = new Data();

	// Use this for initialization
	void Start () {
        m = Data.minerList[i];
        itemInfo.resizeTextForBestFit = true;
        itemInfo.color = new Color(255,255, 255, 255);
    }
	
	// Update is called once per frame
	void Update () {

        nameAndLevel.text = m.minerName + " Level: " + m.count;
        if (Data.gold < m.cost)
        {
            miner.interactable = false;
            button.interactable = false;
        } else
        {
            miner.interactable = true;
            button.interactable = true;
        }
        if (m.goldPerSec > 0)
        {
            itemInfo.text = "Cost: " + Data.CurrencyToString(m.cost) + "\nPower: +" + Data.CurrencyToString(m.clickPower) +"\nGPS: +"+ Data.CurrencyToString(m.goldPerSec)+"/s";
        } else
        {
            itemInfo.text = "Cost: " + Data.CurrencyToString(m.cost) + "\nPower: +" + Data.CurrencyToString(m.clickPower);
        }
	}

    public void PurchasedUpgrade()
    {
        if(Data.gold >= m.cost)
        {
            Data.gold -= m.cost;
            m.count++;
            m.goldPerSec = m.baseGPS * Mathf.Pow(m.upgradeGPS, m.count);
            m.clickPower = m.baseClickPower * Mathf.Pow(m.upgradeGPS, m.count);
            m.cost = Mathf.Round(m.baseCost * Mathf.Pow(m.upgradecost, m.count));
            //Data.goldPerClick += m.clickPower;
            //Data.goldPerSec += m.goldPerSec;

        }
        //Debug.Log("Füge Gold hinzu!" + Data.goldPerSec);
        Data.UpdateGold();
        //Debug.Log("Füge Gold hinzu!" + Data.goldPerSec);
    }
}
