using UnityEngine;
using System.Collections;

public class Miner {

    public int id;
    public string minerName;
    public float cost;
    public float baseCost;
    public float baseGPS;
    public float clickPower;
    public float baseClickPower;
    public float goldPerSec;
    public float upgradecost;
    public float upgradeGPS;
    public int count = 0;

    public Miner(int id, string minerName, float cost, float clickPower, float goldPerSec, float upgradecost, float upgradeGPS) {
        this.id = id;
        this.minerName = minerName;
        this.cost = cost;
        this.baseCost = cost;
        this.baseGPS = goldPerSec;
        this.goldPerSec = goldPerSec;
        this.clickPower = clickPower;
        this.baseClickPower = clickPower;
        this.upgradecost = upgradecost;
        this.upgradeGPS = upgradeGPS;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
