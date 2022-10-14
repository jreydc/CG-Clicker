using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitDataHolder : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy economy;

    [SerializeField] internal BuildingUnit unit;

    [SerializeField] private TextMeshProUGUI unitName;
    [SerializeField] private TextMeshProUGUI unitsOwned;
    [SerializeField] private TextMeshProUGUI solPerSecond;
    [SerializeField] private TextMeshProUGUI unitLevel;
    [SerializeField] private TextMeshProUGUI unitCost;
    [SerializeField] private Image unitImage;

    [SerializeField] private Button buyButton;

    public delegate void upgradeLogic(BuildingUnit unit);
    public static event upgradeLogic onClickCaluclate;

    private void Awake()
    {
        economy = FindObjectOfType<UnitBuildingEconomy>();
        unitName.text = unit.name;
        unitImage.sprite = unit.displayImage;
        if (unit.currentCost <= unit.baseCost)
            unit.currentCost = unit.baseCost;
    }

    private void Update()
    {
        unitLevel.text = "Level: " + unit.unitLevel;
        unitsOwned.text = "Owned: " + unit.currentOwned;
        solPerSecond.text = unit.baseSol + "/s";
        unitCost.text = unit.currentCost.ToString("F0");

        if(economy.solCount <= unit.currentCost)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void OnClick_Buy()
    {
        if(economy.solCount >= unit.currentCost)
        {
            OnBuy();
            onClickCaluclate(unit);
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
    }

    //Where M is the number of that type of unit you own
    // and F as the number of that type of unit you recieve for free
    private float priceActuator(float baseCost, float M, float F)
    {
        float price = Mathf.Round(baseCost * (Mathf.Pow(1.15f, (M - F))));
        return price;
    }
}