using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EconomyManager;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] private UpgadesLogic upgrades;

    [SerializeField] private UnitTierUpgrade unitInfo;

    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        upgrades = FindObjectOfType<UpgadesLogic>();
        unitMain = FindObjectOfType<UnitBuildingEconomy>();
    }
    private void Start()
    {
        unitInfo = upgrades.unitInfo[(upgrades.currentID - 1)];

        levelText.text = unitInfo.currentLevel.ToString();
    }

    public void OnBuy_Upgrade()
    {
        switch (unitInfo.unitIdentifier)
        {
            case 1:
                {
                    switch (unitInfo.currentLevel)
                    {
                        case 0:
                        case 1:
                        case 2:
                            {
                                unitMain.tapsPerSecond = unitInfo.UpgradeTPS(unitInfo.currentLevel, unitMain.tapsPerSecond);
                                break;
                            }
                        case 3:
                            {
                                
                                break;
                            }
                        case 4:
                            {
                                break;
                            }
                        case 5:
                            {
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
                            {
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    break;
                }
            default:
                {
                    if(unitInfo.currentLevel < 14)
                    {
                        unitMain.solPerSecond = unitInfo.UpgardeSPS(unitInfo.currentLevel, unitMain.solPerSecond);
                    }
                    break;
                }
        }

        Destroy(this.gameObject);
    }
}