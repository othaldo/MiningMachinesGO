using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static float gold = 0F;
    public static float goldPerClick = 1F;
    public static float goldPerSec = 0F;
    public static float delay = 0.1F;

    private static string[] suffix = new string[] { "", "K", "M", "B", "q", "Q", "s", "S", "O", "N", "d", "D" };

    public static List<Miner> minerList = new List<Miner>
    {
        new Miner(0,"Miner MK I", 10, 1,1,1.2f,1.15f),
        new Miner(1,"Miner MK II", 100, 15000,15000,1.25f,1.3f),
        new Miner(2,"Miner MK III", 1000,200000,200000,1.5f,1.5f)
    };

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	public void UpdateGold () {
        Data.goldPerClick = 1;
        Data.goldPerSec = 0;
        for (int i = 0; i < Data.minerList.Count; i++)
        {
            if (Data.minerList[i].count > 0)
            {
                Data.goldPerClick += Data.minerList[i].clickPower;
                Data.goldPerSec += Data.minerList[i].goldPerSec;
            }
        }
    }

    public static string CurrencyToString(float valueToConvert)
    {
        int scale = 0;
        float v = valueToConvert;
        while (v >= 1000f)
        {
            v /= 1000f;
            scale++;
            if (scale >= suffix.Length)
                return valueToConvert.ToString("e2"); // overflow, can't display number, fallback to exponential
        }
        return v.ToString("0.###") + suffix[scale];
    }
}
