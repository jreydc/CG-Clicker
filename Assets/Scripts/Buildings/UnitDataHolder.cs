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
    private float internalFloatCost;
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
        UnitCost();

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

    void UnitCost()
    {
        if (unit.sellCost < 1000) //less than 1000
        {
            unitCost.text = unit.sellCost.ToString("F1");
        }
        else if (unit.sellCost >= 1000 && unit.sellCost < 1000000) //greater than or equal to 1000
        {
            internalFloatCost = unit.sellCost / 1000;
            unitCost.text = internalFloatCost.ToString("F1") + "K"; //Thousand
        }
        else if (unit.sellCost >= 1000000 && unit.sellCost < 1000000000) //Million
        {
            internalFloatCost = unit.sellCost / 1000000;
            unitCost.text = internalFloatCost.ToString("F3") + "M";
        }
        else if (unit.sellCost >= 1000000000 && unit.sellCost < 1000000000000) //Billion
        {
            internalFloatCost = unit.sellCost / 1000000000;
            unitCost.text = internalFloatCost.ToString("F3") + "B";
        }
        else if (unit.sellCost >= 1000000000000 && unit.sellCost < 1000000000000000) //Trillion
        {
            internalFloatCost = unit.sellCost / 1000000000000;
            unitCost.text = internalFloatCost.ToString("F3") + "T";
        }
        else if (unit.sellCost >= 1000000000000000 && unit.sellCost < 1000000000000000000) // Quadrillion
        {
            internalFloatCost = unit.sellCost / 1000000000000000;
            unitCost.text = internalFloatCost.ToString("F3") + "QD";
        }
        else if (unit.sellCost >= 1000000000000000000 && unit.sellCost < 1e+21) //Quintillion
        {
            internalFloatCost = unit.sellCost / 1000000000000000000;
            unitCost.text = internalFloatCost.ToString("F3") + "QT";
        }
        else if (unit.sellCost >= 1e+21 && unit.sellCost < 1e+24) // Sextillion
        {
            internalFloatCost = unit.sellCost / (float)1e+21;
            unitCost.text = internalFloatCost.ToString("F3") + "SX";
        }
        else if (unit.sellCost >= 1e+24 && unit.sellCost < 1e+27) // Septillion
        {
            internalFloatCost = unit.sellCost / (float)1e+24;
            unitCost.text = internalFloatCost.ToString("F3") + "SP";
        }
        else if (unit.sellCost >= 1e+27 && unit.sellCost < 1e+30) // Octillion
        {
            internalFloatCost = unit.sellCost / (float)1e+27;
            unitCost.text = internalFloatCost.ToString("F3") + "O";
        }
        else if (unit.sellCost >= 1e+30 && unit.sellCost < 1e+33) //Nonillion
        {
            internalFloatCost = unit.sellCost / (float)1e+30;
            unitCost.text = internalFloatCost.ToString("F3") + "N";
        }
        else if (unit.sellCost >= 1e+33) //Decillion
        {
            internalFloatCost = unit.sellCost / (float)1e+33;
            unitCost.text = internalFloatCost.ToString("F3") + "D";
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