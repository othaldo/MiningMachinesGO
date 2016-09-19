using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour {

    public Button button;
    private MaterialDepot md;

    void Start()
    {
        md = MaterialDepot.Instance;
    }
	void Update () {

	}

    public void Clicked()
    {
        button.interactable = false;
        md.TakeDamage(Data.Instance.GetGoldPerClick());
        button.interactable = true;
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(Data.instance.GetDelay());
    }
}
