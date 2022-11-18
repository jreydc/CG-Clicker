using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades")]
public class UpgradeFunction : ScriptableObject
{
    public enum Upgrade
    {
        Tap,
        SPS,
        GTPS
    };

    public Upgrade upgradeType;
    public int upgradeLevel = 1;
    public float multiplier;
    public float upgradeCost;
    public int ID;
    public Sprite image;
    public string function;

    public void BuyFunction()
    {
        if(GameObject.FindObjectOfType<UnitBuildingEconomy>().solCount >= upgradeCost)
        {
            switch (upgradeType)
            {
                case Upgrade.Tap:
                    {
                        switch (upgradeLevel)
                        {
                            case 1:
                                {
                                    break;
                                }
                            case 2:
                                {
                                    break;
                                }
                            case 3:
                                {
                                    break;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                        break;
                    }
                case Upgrade.SPS:
                    {
                        switch (upgradeLevel)
                        {
                            case 1:
                                {
                                    //GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond = Mathf.Pow(GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond, multiplier);
                                    break;
                                }
                            case 2:
                                {
                                    //GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond = Mathf.Pow(GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond, multiplier);
                                    break;
                                }
                            case 3:
                                {
                                    //GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond = Mathf.Pow(GameObject.FindObjectOfType<UnitBuildingEconomy>().solPerSecond, multiplier);
                                    break;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                        break;
                    }
                case Upgrade.GTPS:
                    {
                        switch (upgradeLevel)
                        {
                            case 1:
                                {
                                    break;
                                }
                            case 2:
                                {
                                    break;
                                }
                            case 3:
                                {
                                    break;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            //upgradeLevel++;
            //FindObjectOfType<UpgradesList>().RemoveFromList(ID);
        }
    }
}