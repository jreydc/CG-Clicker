using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuickBarItems : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy economy;

    [SerializeField] internal BuildingUnit unit;

    [SerializeField] private Image unitImage;

    [SerializeField] private Button buyButton;

    [SerializeField] private PlaySound sound;

    private void Awake()
    {
        economy = FindObjectOfType<UnitBuildingEconomy>();
        unitImage.sprite = unit.displayImage;
        if (unit.currentCost <= unit.baseCost)
            unit.currentCost = unit.baseCost;

        sound = GameObject.Find("SoundManager").GetComponent<PlaySound>();
    }

    private void Update()
    {
        if (economy.solCount <= unit.currentCost)
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
        if (economy.solCount >= unit.currentCost)
        {
            OnBuy();
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

        sound.Buy();
    }

    //Where M is the number of that type of unit you own
    // and F as the number of that type of unit you recieve for free
    private float priceActuator(float baseCost, float M, float F)
    {
        float price = Mathf.Round(baseCost * (Mathf.Pow(1.15f, (M - F))));
        return price;
    }
}
