using UnityEngine;
using System.Collections;

public class DisplayInfo : MonoBehaviour {

    public UnityEngine.UI.Text dps,dpc,level,stage;
	
	// Update is called once per frame
	void Update () {
        dpc.text = Data.Instance.CurrencyToString(Data.Instance.GetGoldPerClick())+" / c";
        dps.text = Data.Instance.CurrencyToString(Data.Instance.GetGoldPerSec()) + " / s";
        level.text = Data.Instance.Level.ToString();
        stage.text = Data.Instance.Stage+"/"+Data.Instance.MaxStage;
    }
}
