using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EconomyManager;

public class NewUpgradesFunction : MonoBehaviour
{
    private PointsFunction pfMain;

    [SerializeField] internal List<int> currentUpgradeCost;
    [SerializeField] internal List<int> incrementalUpgradeCost;

    [SerializeField] internal List<int> upgradeLevelList;

    [SerializeField] private List<TextMeshProUGUI> currentLvlText;
    [SerializeField] private List<TextMeshProUGUI> upgradeCostText;

    private void Awake()
    {
        pfMain = FindObjectOfType<PointsFunction>();
    }

    private void Start()
    {
        for (int i = 0; i < upgradeLevelList.Count; i++)
        {
            currentLvlText[i].text = "Lvl " + upgradeLevelList[i];
        }

        for (int i = 0; i < currentUpgradeCost.Count; i++)
        {
            upgradeCostText[i].text = currentUpgradeCost[i].ToString();
        }
    }

    public void OnClick_Upgrade(int index)
    {
        switch (index)
        {
            case 0:
                {
                    if (pfMain._score >= currentUpgradeCost[0])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[0], pfMain._score);
                        pfMain._scoreToAdd += 1;
                        upgradeLevelList[0] += 1;

                        currentUpgradeCost[0] += incrementalUpgradeCost[0];
                        incrementalUpgradeCost[0] += 5;

                        upgradeCostText[0].text = currentUpgradeCost[0].ToString();
                        currentLvlText[0].text = "Lvl " + upgradeLevelList[0];
                    }
                    break;
                }
            case 1:
                {
                    if (pfMain._score >= currentUpgradeCost[1])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[1], pfMain._score);
                        pfMain._passiveScore += 1;
                        upgradeLevelList[1] += 1;

                        currentUpgradeCost[1] += incrementalUpgradeCost[1];
                        incrementalUpgradeCost[1] += 5;

                        upgradeCostText[1].text = currentUpgradeCost[1].ToString();
                        currentLvlText[1].text = "Lvl " + upgradeLevelList[1];
                    }
                    break;
                }
            case 2:
                {
                    if (pfMain._score >= currentUpgradeCost[2])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[2], pfMain._score);
                        pfMain._passiveScore += 2;
                        upgradeLevelList[2] += 1;

                        currentUpgradeCost[2] += incrementalUpgradeCost[2];
                        incrementalUpgradeCost[2] += 5;

                        upgradeCostText[2].text = currentUpgradeCost[2].ToString();
                        currentLvlText[2].text = "Lvl " + upgradeLevelList[2];
                    }
                    break;
                }
            case 3:
                {
                    if (pfMain._score >= currentUpgradeCost[3])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[3], pfMain._score);
                        pfMain._passiveScore += 5;
                        upgradeLevelList[3] += 1;

                        currentUpgradeCost[3] += incrementalUpgradeCost[3];
                        incrementalUpgradeCost[3] += 5;

                        upgradeCostText[3].text = currentUpgradeCost[3].ToString();
                        currentLvlText[3].text = "Lvl " + upgradeLevelList[3];
                    }
                    break;
                }
            case 4:
                {
                    if (pfMain._score >= currentUpgradeCost[4])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[4], pfMain._score);
                        pfMain._passiveScore += 10;
                        upgradeLevelList[4] += 1;

                        currentUpgradeCost[4] += incrementalUpgradeCost[4];
                        incrementalUpgradeCost[4] += 5;

                        upgradeCostText[4].text = currentUpgradeCost[4].ToString();
                        currentLvlText[4].text = "Lvl " + upgradeLevelList[4];
                    }
                    break;
                }
            case 5:
                {
                    if (pfMain._score >= currentUpgradeCost[5])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[5], pfMain._score);
                        pfMain._passiveScore += 20;
                        upgradeLevelList[5] += 1;

                        currentUpgradeCost[5] += incrementalUpgradeCost[5];
                        incrementalUpgradeCost[5] += 5;

                        upgradeCostText[5].text = currentUpgradeCost[5].ToString();
                        currentLvlText[5].text = "Lvl " + upgradeLevelList[5];
                    }
                    break;
                }
            case 6:
                {
                    if (pfMain._score >= currentUpgradeCost[6])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[6], pfMain._score);
                        pfMain._passiveScore += 30;
                        upgradeLevelList[6] += 1;

                        currentUpgradeCost[6] += incrementalUpgradeCost[6];
                        incrementalUpgradeCost[6] += 5;

                        upgradeCostText[6].text = currentUpgradeCost[6].ToString();
                        currentLvlText[6].text = "Lvl " + upgradeLevelList[6];
                    }
                    break;
                }
            case 7:
                {
                    if (pfMain._score >= currentUpgradeCost[7])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[7], pfMain._score);
                        pfMain._passiveScore += 50;
                        upgradeLevelList[7] += 1;

                        currentUpgradeCost[7] += incrementalUpgradeCost[5];
                        incrementalUpgradeCost[7] += 5;

                        upgradeCostText[7].text = currentUpgradeCost[7].ToString();
                        currentLvlText[7].text = "Lvl " + upgradeLevelList[7];
                    }
                    break;
                }
            case 8:
                {
                    if (pfMain._score >= currentUpgradeCost[8])
                    {
                        pfMain._score = EconomyMain.deductScore(currentUpgradeCost[8], pfMain._score);
                        pfMain._passiveScore += 100;
                        upgradeLevelList[8] += 1;

                        currentUpgradeCost[8] += incrementalUpgradeCost[8];
                        incrementalUpgradeCost[8] += 5;

                        upgradeCostText[8].text = currentUpgradeCost[8].ToString();
                        currentLvlText[8].text = "Lvl " + upgradeLevelList[8];
                    }
                    break;
                }
        }
    }
}