using System;
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

    [SerializeField] PlaySound sound;

    [SerializeField] AchievementText achievementText;

    [SerializeField] AchievementTracker achievementTracker;
    [SerializeField] BuildingBuyCount buildingBuy;
    [SerializeField] int nextAch;

    [SerializeField] BuySellMode buySell;

    private void Awake()
    {
        buySell = FindObjectOfType<BuySellMode>();

        achievementText = FindObjectOfType<AchievementText>();
        sound = FindObjectOfType<PlaySound>();
    }

    private void Update()
    {
        unitLevel.text = "Level: " + unit.unitLevel;
        unitsOwned.text = "Owned: " + unit.currentOwned;
        solPerSecond.text = unit.baseSol + "/s";
        unitCost.text = unit.currentCost.ToString("F0");

        if (buySell.buy == true)
        {
            //= ROUNDUP(ROUNDUP(BASE_COST * (1 - 1.15 ^ 10)) / (1 - 1.15))

            if (buySell.amount != 1)
            {
                unitCost.text = Mathf.Round(Mathf.Round((unit.currentCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f))))).ToString("F0");

                if (economy.solCount >= Mathf.Round(Mathf.Round((unit.currentCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f))))))
                {
                    buyButton.interactable = true;
                }
                else
                {
                    buyButton.interactable = false;
                }
            }
            else
            {
                unitCost.text = unit.currentCost.ToString("F0");

                if (economy.solCount >= unit.currentCost)
                {
                    buyButton.interactable = true;
                }
                else
                {
                    buyButton.interactable = false;
                }
            }
            buyButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            if (buySell.amount != 1)
            {
                unitCost.text = Mathf.Round(Mathf.Round((unit.sellCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f))))).ToString("F0");
            }
            else
            {
                unitCost.text = unit.sellCost.ToString("F0");
            }

            if (unit.currentOwned > buySell.amount)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
                unitCost.text = "";
            }
            buyButton.GetComponent<Image>().color = Color.red;
        }
    }

    public void OnClick_Buy()
    {
        if (buySell.buy == true)
        {
             OnBuy();
        }
        else if(buySell.buy == false && unit.currentOwned > buySell.amount)
        {
            OnSell();
        }
    }

        void OnBuy()
        {
            unit.unitLevel += buySell.amount;
            unit.currentOwned += buySell.amount;
            unit.currentSol += unit.baseSol * buySell.amount;

        if (buySell.amount != 1)
        {
            economy.solCount -= Mathf.Round(Mathf.Round((unit.currentCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f)))));
        }
        else
        {
            economy.solCount -= unit.currentCost;
        }

            unit.currentCost = priceActuator(unit.baseCost, unit.currentOwned, 0f);
            economy.solPerSecond += unit.currentSol * buySell.amount;
            unit.sellCost = unit.currentCost / 2.2f;
            if (unit.currentOwned >= buildingBuy.buildingCount[nextAch])
            {
            switch (nextAch)
            {
                case 0:
                    achievementTracker.Unlock(unit.unitID);
                    achievementText.achName.text = unit.name + " Bronze";
                    achievementText.Play();
                    break;

                case 1:
                    achievementTracker.Unlock(unit.unitID + 19);
                    achievementText.achName.text = unit.name + " Silver";
                    achievementText.Play();
                    break;

                case 2:
                    achievementTracker.Unlock(unit.unitID + 38);
                    achievementText.achName.text = unit.name + " Gold";
                    achievementText.Play();
                    break;
            }
                nextAch++;
            }
            sound.Buy();
        }

        void OnSell()
        {
            unit.unitLevel-= buySell.amount;
            unit.currentOwned-= buySell.amount;
            unit.currentSol -= unit.baseSol * buySell.amount;

        if (buySell.amount != 1)
        {
            economy.solCount += Mathf.Round(Mathf.Round((unit.sellCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f)))));
        }
        else
        {
            economy.solCount += unit.sellCost;
        }

            unit.currentCost = priceActuator(unit.baseCost, unit.currentOwned, 0f);
            economy.solPerSecond -= unit.currentSol;
            unit.sellCost = unit.currentCost / 2.2f;
            sound.Buy();
        }

        //Where M is the number of that type of unit you own
        // and F as the number of that type of unit you recieve for free
        private float priceActuator(float baseCost, float M, float F)
        {
            double price = Math.Round(baseCost * (Math.Pow(1.15f, (M - F))));
            return (float)price;
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