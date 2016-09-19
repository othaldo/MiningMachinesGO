using UnityEngine;
using System.Collections;

public class GoldPerSec : MonoBehaviour {

    public void AutoGoldPerSec()
    {
        Data.instance.AddGold(Data.instance.GetGoldPerSec() / 10);
    }

    IEnumerator AutoTick()
    {
        while (true)
        {   
            MaterialDepot.Instance.TakeDamage(Data.Instance.GetGoldPerSec() / 10);
            yield return new WaitForSeconds(0.1F);
        }

    }
	// Use this for initialization
	void Start () {
        StartCoroutine(AutoTick());
	}

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
