using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour {

    public UnityEngine.UI.Text goldDisplay;
    public Button button;

    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        //goldDisplay.text = Data.CurrencyToString(Data.gold);
	}

    public void Clicked()
    {
        button.interactable = false;
        //Data.instance.AddGold();
        MaterialDepot.Instance.TakeDamage(Data.Instance.GetGoldPerClick());
        StartCoroutine(Reactivate());
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(Data.instance.GetDelay());
        button.interactable = true;
    }
}
