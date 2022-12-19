using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EconomyManager;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private List<BuildingUnit> building;

    [SerializeField] internal UpgradeFunction unitInfo;

    [SerializeField] private TextMeshProUGUI levelText, priceText, functionText;

    [SerializeField] private Button buyButton;

    public Image dispImage;

    private void Awake()
    {
        dispImage.sprite = unitInfo.image;

        levelText.text = unitInfo.upgradeLevel.ToString();
        priceText.text = unitInfo.baseUpgradeCost.ToString();
        functionText.text = unitInfo.function;
    }

    private void Update()
    {
        levelText.text = unitInfo.upgradeLevel.ToString();
        priceText.text = unitInfo.currentUpgradeCost.ToString();

        buyButton.interactable = CanBuy();
    }

    private bool CanBuy()
    {
        if(building[(unitInfo.ID - 1)].currentOwned != 0)
        {
            return true;
        }
        return false;
    }

    public void OnClick_Buy()
    {
        if (GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount >= unitInfo.currentUpgradeCost)
        {
            //GameObject.FindObjectOfType<UnitBuildingEconomy>().Formatter(currentProduction);
            float currentSol = GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount;
            GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount = currentSol - unitInfo.currentUpgradeCost;

            switch (unitInfo.upgradeLevel)
            {
                case 1:
                case 2:
                case 3:
                    {
                        if (unitInfo.ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 2;
                            break;
                        }
                        unitInfo.currentProduction = unitInfo.baseProduction * 2;
                        break;
                    }
                case 4:
                    {
                        if (unitInfo.ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 5;
                            break;
                        }
                        unitInfo.currentProduction = unitInfo.baseProduction * 2;
                        break;
                    }
                case 5:
                    {
                        if (unitInfo.ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 10;
                            break;
                        }
                        unitInfo.currentProduction = unitInfo.baseProduction * 2;
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
                        if (unitInfo.ID == 1)
                        {
                            GameObject.FindObjectOfType<UnitBuildingEconomy>().tapsPerSecond *= 20;
                            break;
                        }
                        unitInfo.currentProduction = unitInfo.baseProduction * 2;
                        break;
                    }
            }
            GameObject.FindObjectOfType<UnitBuildingEconomy>().RefreshForUpgrades(unitInfo.ID);
            unitInfo.upgradeLevel++;
            unitInfo.currentUpgradeCost = priceIterator(unitInfo.currentUpgradeCost);
        }
        //Destroy(gameObject);
    }
    float priceIterator(float costNext)
    {
        return costNext = unitInfo.baseUpgradeCost * Mathf.Round(Mathf.Pow((unitInfo.currentUpgradeCost * 0.05f), unitInfo.upgradeLevel));
    }
}