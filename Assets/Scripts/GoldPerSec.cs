using UnityEngine;
using System.Collections;

public class GoldPerSec : MonoBehaviour {

    private static GoldPerSec instance = null;

    public void AutoGoldPerSec()
    {
        Debug.Log("Füge Gold hinzu!"+ Data.goldPerSec / 10);
        Data.gold += Data.goldPerSec/10;
    }

    IEnumerator AutoTick()
    {
        Debug.Log("AutoTick gestartet!");
        while (true)
        {
            AutoGoldPerSec();
            yield return new WaitForSeconds(0.1F);
        }
    }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(AutoTick());
	}

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
