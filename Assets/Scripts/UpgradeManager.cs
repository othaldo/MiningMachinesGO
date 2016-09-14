using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    public UnityEngine.UI.Text itemInfo;
    public UnityEngine.UI.Text nameAndLevel;
    public UnityEngine.UI.Text sliderLabel;
    public Button miner;
    public Button button;
    public int i;
    private Miner m;
    private Slider slider;
    //Data data = new Data();

	// Use this for initialization
	void Start () {
        m = Data.instance.GetMiner(i);
        itemInfo.resizeTextForBestFit = true;
        itemInfo.color = new Color(255,255, 255, 255);
        slider = GetComponentInChildren<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        sliderLabel.text = Data.instance.GetGoldString() + " / " + Data.instance.CurrencyToString(m.cost);
        nameAndLevel.text = m.minerName + " Level: " + m.count;
        if (Data.instance.GetGold() < m.cost)
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
            itemInfo.text = "Cost: " + Data.instance.CurrencyToString(m.cost) + "\nPower: +" + Data.instance.CurrencyToString(m.clickPower) +"\nGPS: +"+ Data.instance.CurrencyToString(m.goldPerSec)+"/s";
        } else
        {
            itemInfo.text = "Cost: " + Data.instance.CurrencyToString(m.cost) + "\nPower: +" + Data.instance.CurrencyToString(m.clickPower);
        }

        slider.value = Data.instance.GetGold() / m.cost * 100f;
	}

    public void PurchasedUpgrade()
    {
        if(Data.instance.GetGold() >= m.cost)
        {
            Data.instance.RemoveGold(m.cost);
            m.count++;
            m.goldPerSec = m.baseGPS * Mathf.Pow(m.upgradeGPS, m.count);
            m.clickPower = m.baseClickPower * Mathf.Pow(m.upgradeGPS, m.count);
            m.cost = Mathf.Round(m.baseCost * Mathf.Pow(m.upgradecost, m.count));
            //Data.goldPerClick += m.clickPower;
            //Data.goldPerSec += m.goldPerSec;

        }
        //Debug.Log("Füge Gold hinzu!" + Data.goldPerSec);
        Data.instance.UpdateGold();
        //Debug.Log("Füge Gold hinzu!" + Data.goldPerSec);
    }
}
