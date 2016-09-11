using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    public UnityEngine.UI.Text itemInfo;
    public Button miner;
    public Button button;
    public int i;
    private Miner m;


	// Use this for initialization
	void Start () {
        m = Data.minerList[i];
        itemInfo.resizeTextForBestFit = true;
        itemInfo.color = new Color(255,255, 255, 255);
    }
	
	// Update is called once per frame
	void Update () {
        if(Data.gold < m.cost)
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
            itemInfo.text = m.minerName + "\nCost: " + Data.CurrencyToString(m.cost) + "\nPower: +" + Data.CurrencyToString(m.clickPower) +" GPS: +"+ Data.CurrencyToString(m.goldPerSec)+"/s"+ " Level: " + m.count;
        } else
        {
            itemInfo.text = m.minerName + "\nCost: " + Data.CurrencyToString(m.cost) + "\nPower: +" + Data.CurrencyToString(m.clickPower) + " Level: " + m.count;
        }
	}

    public void PurchasedUpgrade()
    {
        if(Data.gold >= m.cost)
        {
            Data.gold -= m.cost;
            m.count++;
            m.goldPerSec = Mathf.Round(m.baseGPS * Mathf.Pow(m.upgradeGPS, m.count));
            m.clickPower = Mathf.Round(m.baseClickPower * Mathf.Pow(m.upgradeGPS, m.count));
            m.cost = Mathf.Round(m.baseCost * Mathf.Pow(m.upgradecost, m.count));
            //Data.goldPerClick += m.clickPower;
            //Data.goldPerSec += m.goldPerSec;

        }
    }
}
