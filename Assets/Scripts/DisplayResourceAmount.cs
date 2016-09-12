using UnityEngine;
using System.Collections;

public class DisplayResourceAmount : MonoBehaviour {

    public UnityEngine.UI.Text goldDisplay;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        goldDisplay.text = Data.CurrencyToString(Data.gold);
    }
}
