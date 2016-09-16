using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MaterialDepot : MonoBehaviour {

    public static MaterialDepot instance;

    private float baseHitpoints = 10f;
    private float hitpoints;
    private float maxHitpoints;
    private float defence;
    private float amountResource;

    private int resourceNumber;

    private bool isBoss = false;

    //UnityEngine.UI.Image image;
    public Slider slider;
    public UnityEngine.UI.Text sliderLabel;

    public static MaterialDepot Instance {
        get { return instance; }
    }

    public void TakeDamage(float damage) {
        hitpoints -= damage;
        if (hitpoints <= 0) {
            Die();
            Respawn();
        }
    }

    // Use this for initialization
    void Start() {
        CalculateHitpoints();
        CalculateResourceAmount();
        maxHitpoints = hitpoints;
    }

    // Update is called once per frame
    void Update() {
        slider.value =  hitpoints / maxHitpoints * 100f;
        sliderLabel.text = Data.Instance.CurrencyToString(hitpoints);
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

    private void Die() {
        Data.Instance.AddGold(amountResource);

        if (isBoss) {
            isBoss = false;
            Data.Instance.Level += 1;
            Data.Instance.Stage = 1;
            Data.Instance.MaxStage = 10;
        } else {
            if (Data.Instance.Level % 10 == 9 && Data.Instance.Stage == Data.Instance.MaxStage) {
                isBoss = true;
                Data.Instance.Stage = 1;
                Data.Instance.MaxStage = 1;
                Data.Instance.Level += 1;
            } else if (Data.Instance.Stage == Data.Instance.MaxStage) {
                        Data.Instance.Level += 1;
                        Data.Instance.Stage = 1;
                     } else {
                            Data.Instance.Stage += 1;
            }
        }

    }

    private void Respawn() {
        CalculateHitpoints();
        CalculateResourceAmount();
    }

    //Round Up(MAX([Is Boss] * 10, 1) * [Base Life]  * (1.6 ^ ([Level] - 1)) + ([Level] - 1) * 10, 0)
    private void CalculateHitpoints() {
        if (isBoss) {
            //Round Up(([Base Life] * (1.6 ^ ([Level] - 1)) + (Level - 1) * 10) * 10)
            //100 * (1.6 ^ ([Level] - 1)) + ([Level] - 1) * 10
            hitpoints = Math.Max(Convert.ToSingle(Math.Round(baseHitpoints * 10 *(Math.Pow((Data.Instance.Level - 1), 1.6) + (Data.Instance.Level - 1)))), 10);
        } else {
            hitpoints = Math.Max(Convert.ToSingle(Math.Round(baseHitpoints * (Math.Pow((Data.Instance.Level - 1), 1.6)))),10);
        }
        maxHitpoints = hitpoints;
    }

    private void CalculateResourceAmount() {
        amountResource = Math.Max(hitpoints / 15,1);
    }
}
