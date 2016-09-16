﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {

    public static Data instance;

    private float gold = 0F;
    private float goldPerClick = 1F;
    private float goldPerSec = 0F;
    private float delay = 0F;
    private int level = 1;
    private int stage = 1;
    private int maxStage = 10;

    private static string[] suffix = new string[] { "", "K", "M", "B", "T", "q", "Q", "s", "S", "O", "N", "d", "D", "!", "@", "#", "$", "%", "^", "&", "*", "UI" };

    public enum typeResource { Gold, Iron };

    //id,name,kosten,ppc,gps,upgradekosten,upgradepower
    private List<Miner> minerList = new List<Miner>
    {
        new Miner(0,"Miner MK I", 10, 1,1,1.2f,1.15f),
        new Miner(1,"Miner MK II", 100, 3,2,1.2f,1.25f),
        new Miner(2,"Miner MK III", 10000, 500,0,1.3f,1.35f),
    };


    public static Data Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddGold() {
        gold += goldPerClick;
    }
    // Update is called once per frame
    public void UpdateGold() {
        goldPerClick = 1;
        goldPerSec = 0;
        for (int i = 0; i < Data.instance.minerList.Count; i++) {
            if (Data.instance.minerList[i].count > 0) {
                goldPerClick += Data.instance.minerList[i].clickPower;
                goldPerSec += Data.instance.minerList[i].goldPerSec;
            }
        }
    }

    public string CurrencyToString(float valueToConvert) {
        int scale = 0;
        float v = valueToConvert;
        while (v >= 10000f) {
            v /= 1000f;
            scale++;
            if (scale >= suffix.Length)
                return valueToConvert.ToString("e2"); // overflow, can't display number, fallback to exponential
        }
        return v.ToString("0") + suffix[scale];
    }

    public float GetGold() {
        return gold;
    }
    public void AddGold(float amount) {
        gold += amount;
    }
    public void RemoveGold(float amount) {
        gold -= amount;
    }
    public string GetGoldString() {
        return CurrencyToString(gold);
    }

    public float GetDelay() {
        return delay;
    }

    public float GetGoldPerSec() {
        return goldPerSec;
    }
    public float GetGoldPerClick() {
        return goldPerClick;
    }
    public Miner GetMiner(int i) {
        return minerList[i];
    }

    public int Level {
        get { return level; }
        set { level = value; }
    }

    public int Stage {
        get { return stage; }
        set { stage = value; }
    }

    public int MaxStage {
        get { return maxStage; }
        set { maxStage = value; }
    }

}
