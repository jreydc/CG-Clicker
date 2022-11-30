using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades")]
public class UpgradeFunction : ScriptableObject
{
    //Might become obselete
    public enum Upgrade
    {
        Tap,
        SPS,
        GTPS
    };

    public Upgrade upgradeType;
    public int upgradeLevel = 1;
    [SerializeField] internal float baseProduction;
    public float currentProduction;
    [SerializeField] internal float baseUpgradeCost;
    public float currentUpgradeCost;
    public int ID;
    public Sprite image;
    [TextArea]
    public string function;
    public void BuyFunction()
    {
        if (GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount >= currentUpgradeCost)
        {
            GameObject.FindObjectOfType<UnitBuildingEconomy>().Formatter(currentProduction);
            float currentSol = GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount;
            GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount = currentSol - currentUpgradeCost;

            switch (upgradeLevel)
            {
                case 1:
                case 2:
                case 3:
                    {
                        if(ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 2;
                            break;
                        }
                        currentProduction = baseProduction * 2;
                        break;
                    }
                case 4:
                    {
                        if (ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 5;
                            break;
                        }
                        currentProduction = baseProduction * 2;
                        break;
                    }
                case 5:
                    {
                        if (ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 10;
                            break;
                        }
                        currentProduction = baseProduction * 2;
                        break; 
                    }
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    {
                        if (ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 20;
                            break;
                        }
                        currentProduction = baseProduction * 2;
                        break;
                    }
            }
            GameObject.FindObjectOfType<UnitBuildingEconomy>().RefreshForUpgrades(ID);
            upgradeLevel++;
            currentUpgradeCost = priceIterator(currentUpgradeCost);
        }
    }

    float priceIterator(float costNext)
    {
        return costNext = baseUpgradeCost * Mathf.Round(Mathf.Pow((currentUpgradeCost * 0.05f), upgradeLevel));
    }
}