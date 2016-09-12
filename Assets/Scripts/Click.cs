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
        goldDisplay.text = Data.CurrencyToString(Data.gold);
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
