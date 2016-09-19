using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MaterialDepot : MonoBehaviour {

    //UnityEngine.UI.Image image;
    public Slider slider;
    public UnityEngine.UI.Text sliderLabel;

    public static MaterialDepot instance;
    public static MaterialDepot Instance {
        get { return instance; }
    }

    public void TakeDamage(float damage) {
        Debug.Log(""+damage);
        Data.Instance.Hitpoints -= damage;
        if (Data.Instance.Hitpoints <= 0) {
            Die();
            Respawn();
        }
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        MaterialDepot.Instance.slider.value =  Data.Instance.Hitpoints / Data.Instance.MaxHitpoints * 100f;
        MaterialDepot.Instance.sliderLabel.text = Data.Instance.CurrencyToString(Data.Instance.Hitpoints) +" HP";
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
        Data.Instance.AddGold(Data.Instance.AmountResource);

        if (Data.Instance.IsBoss) {
            Data.Instance.IsBoss = false;
            Data.Instance.Level += 1;
            Data.Instance.Stage = 1;
            Data.Instance.MaxStage = 10;
        } else {
            if (Data.Instance.Level % 10 == 9 && Data.Instance.Stage == Data.Instance.MaxStage) {
                Data.Instance.IsBoss = true;
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

    private void CalculateHitpoints() {
        if (Data.Instance.IsBoss) {
            Data.Instance.Hitpoints = Math.Max(Convert.ToSingle(Math.Round(Data.Instance.BaseHitpoints * 10 *(Math.Pow((Data.Instance.Level - 1), 1.6) + (Data.Instance.Level - 1)))), 10);
        } else {
            Data.Instance.Hitpoints = Math.Max(Convert.ToSingle(Math.Round(Data.Instance.BaseHitpoints * (Math.Pow((Data.Instance.Level - 1), 1.6)))),10);
        }
        Data.Instance.MaxHitpoints = Data.Instance.Hitpoints;
    }

    private void CalculateResourceAmount() {
        Data.Instance.AmountResource = Math.Max(Data.Instance.Hitpoints / 15,1);
    }
}
