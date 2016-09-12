using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text goldDisplay;
    public Button button;
    Data data = new Data();

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

        data.UpdateGold();
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
