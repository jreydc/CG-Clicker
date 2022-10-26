using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitDataHolder : MonoBehaviour
{
    [SerializeField] private List<BuildingUnit> l_unit;
    [SerializeField] private UnitBuildingEconomy economy;

    [SerializeField] internal BuildingUnit unit;

    [SerializeField] private TextMeshProUGUI unitName;
    [SerializeField] private TextMeshProUGUI unitsOwned;
    [SerializeField] private TextMeshProUGUI solPerSecond;
    [SerializeField] private TextMeshProUGUI unitLevel;
    [SerializeField] private TextMeshProUGUI unitCost;
    [SerializeField] private Image unitImage;

    [SerializeField] private Button buyButton;

    public delegate void upgradeCounter();
    public static event upgradeCounter upgradeCounterInterval;


    [SerializeField] PlaySound sound;

    [SerializeField] AchievementTracker achievementTracker;
    [SerializeField] BuildingBuyCount buildingBuy;
    [SerializeField] int nextAch;

    private void Awake()
    {
        
    }

    private void Update()
    {
        unitLevel.text = "Level: " + unit.unitLevel;
        unitsOwned.text = "Owned: " + unit.currentOwned;
        solPerSecond.text = unit.baseSol + "/s";
        unitCost.text = unit.currentCost.ToString("F0");

        if(economy.solCount >= unit.currentCost)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void OnClick_Buy()
    {
        if(economy.solCount >= unit.currentCost)
        {
            OnBuy();
            upgradeCounterInterval();
        }
    }
    void OnBuy()
    {
        unit.unitLevel++;
        unit.currentOwned++;
        unit.currentSol += unit.baseSol;
        economy.solCount -= unit.currentCost;
        unit.currentCost = priceActuator(unit.baseCost, unit.currentOwned, 0f);
        economy.solPerSecond += unit.currentSol;

        if(unit.currentOwned >= buildingBuy.buildingCount[nextAch]){
            achievementTracker.Unlock(unit.unitID);
            nextAch++;
        }

        sound.Buy();
    }

    //Where M is the number of that type of unit you own
    // and F as the number of that type of unit you recieve for free
    private float priceActuator(float baseCost, float M, float F)
    {
        float price = Mathf.Round(baseCost * (Mathf.Pow(1.15f, (M - F))));
        return price;
    }

    public void setUnit(int index)
    {
        unit = l_unit[index];
        PopulateData();
    }

    void PopulateData()
    {
        economy = FindObjectOfType<UnitBuildingEconomy>();
        unitName.text = unit.name;
        unitImage.sprite = unit.displayImage;
        if (unit.currentCost <= unit.baseCost)
            unit.currentCost = unit.baseCost;

        sound = GameObject.Find("SoundManager").GetComponent<PlaySound>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
        buildingBuy = FindObjectOfType<BuildingBuyCount>();
    }
}