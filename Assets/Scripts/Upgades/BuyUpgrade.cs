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

    public void GetUnitInfo(UnitTierUpgrade info)
    {
        unitInfo = info;
    }

    public void OnBuy_Upgrade()
    {
        switch (unitInfo.unitIdentifier)
        {
            case 1:
                {
                    if(unitMain.solCount >= unitInfo.basePrice)
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
                                    unitMain.tapsPerSecond = unitInfo.UpgradeTPS(unitInfo.currentLevel, unitMain.tapsPerSecond);
                                    break;
                                }
                            case 4:
                                {
                                    unitMain.solPerSecond = unitInfo.UpgradeSPS5(unitInfo.currentLevel, unitMain.solPerSecond);
                                    break;
                                }
                            case 5:
                                {
                                    unitMain.solPerSecond = unitInfo.UpgradeSPS10(unitInfo.currentLevel, unitMain.solPerSecond);
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
                                    unitMain.solPerSecond = unitInfo.UpgradeSPS20(unitInfo.currentLevel, unitMain.solPerSecond);
                                    break;
                                }
                        }
                    }
                    break;
                }
            case 3:
                {
                    //Temporary
                    if (unitMain.solCount >= unitInfo.basePrice)
                    {
                        if (unitInfo.currentLevel < 14)
                        {
                            unitMain.solPerSecond += unitInfo.UpgradeSPS(unitInfo.currentLevel, unitMain.solPerSecond);
                        }
                    }
                    break;
                }
            default:
                {
                    if(unitMain.solCount >= unitInfo.basePrice)
                    {
                        if (unitInfo.currentLevel < 14)
                        {
                            unitMain.solPerSecond += unitInfo.UpgradeSPS(unitInfo.currentLevel, unitMain.solPerSecond);
                        }
                    }
                    break;
                }
        }
        GameObject.FindObjectOfType<UpgradeListData>().DestroyID(unitInfo.unitIdentifier);
        Destroy(this.gameObject);
    }
}