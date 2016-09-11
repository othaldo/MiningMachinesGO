using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text goldDisplay;
    public Button button;

    void Start()
    {
        //Data.gold = PlayerPrefs.GetFloat("gold");
    }
	// Update is called once per frame
	void Update () {
        goldDisplay.text = "Gold: " + Data.CurrencyToString(Data.gold);
        if (goldDisplay.text.Length > 5)
        {

        }

        Data.goldPerClick = 1;
        Data.goldPerSec = 0;
        for (int i =0; i <Data.minerList.Count ; i++)
        {
            if (Data.minerList[i].count > 0)
            {
                Data.goldPerClick += Data.minerList[i].clickPower;
                Data.goldPerSec += Data.minerList[i].goldPerSec;
            }
        }
	}

    public void Clicked()
    {
        button.interactable = false;
        Data.gold += Data.goldPerClick;
        StartCoroutine(Reactivate());
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(Data.delay);
        button.interactable = true;
    }
}
