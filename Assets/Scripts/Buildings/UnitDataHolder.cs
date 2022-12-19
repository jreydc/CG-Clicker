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

    private void Start()
    {
        UnitCost();
    }

    private void Update()
    {
        //unitLevel.text = "Level: " + unit.unitLevel;
        unitsOwned.text = unit.currentOwned.ToString();
        if(unit.currentSol == 0)
            solPerSecond.text = "generating " + unit.baseSol + " sol/s per second";
        else
            solPerSecond.text = "generating " + unit.currentSol + " sol/s per second";
        UnitCost();

        if (buySell.buy == true)
        {
            //= ROUNDUP(ROUNDUP(BASE_COST * (1 - 1.15 ^ 10)) / (1 - 1.15))

            if (buySell.amount != 1)
            {
                //unitCost.text = Mathf.Round(Mathf.Round((unit.currentCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f))))).ToString("F0");

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
                //unitCost.text = unit.currentCost.ToString("F0");

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
                //unitCost.text = Mathf.Round(Mathf.Round((unit.sellCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f))))).ToString("F0");
            }
            else
            {
                //unitCost.text = unit.sellCost.ToString("F0");
            }

            if (unit.currentOwned > buySell.amount)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
                //unitCost.text = "";
            }
            buyButton.GetComponent<Image>().color = Color.red;
        }
    }

    void UnitCost()
    {
        if (unit.currentCost < 1000) //less than 1000
        {
            unitCost.text = unit.currentCost.ToString("F1");
        }
        //Thousand
        else if (unit.currentCost >= 1e+3f && unit.currentCost < 1e+4f)
        {
            internalFloatCost = unit.currentCost / 1e+3f;
            unitCost.text = internalFloatCost.ToString("F2") + "K";
        }
        else if (unit.currentCost >= 1e+4f && unit.currentCost < 1e+5f)
        {
            internalFloatCost = unit.currentCost / 1e+3f;
            unitCost.text = internalFloatCost.ToString("F2") + "K";
        }
        else if (unit.currentCost >= 1e+5f && unit.currentCost < 1e+6f)
        {
            internalFloatCost = unit.currentCost / 1e+3f;
            unitCost.text = internalFloatCost.ToString("F2") + "K";
        }
        //Million
        else if (unit.currentCost >= 1e+6f && unit.currentCost < 1e+7f)
        {
            internalFloatCost = unit.currentCost / 1e+6f;
            unitCost.text = internalFloatCost.ToString("F2") + "M";
        }
        else if (unit.currentCost >= 1e+7f && unit.currentCost < 1e+8f)
        {
            internalFloatCost = unit.currentCost / 1e+6f;
            unitCost.text = internalFloatCost.ToString("F2") + "M";
        }
        else if (unit.currentCost >= 1e+8f && unit.currentCost < 1e+9f)
        {
            internalFloatCost = unit.currentCost / 1e+6f;
            unitCost.text = internalFloatCost.ToString("F2") + "M";
        }
        //Billion
        else if (unit.currentCost >= 1e+9f && unit.currentCost < 1e+10f)
        {
            internalFloatCost = unit.currentCost / 1e+9f;
            unitCost.text = internalFloatCost.ToString("F2") + "B";
        }
        else if (unit.currentCost >= 1e+10f && unit.currentCost < 1e+11f)
        {
            internalFloatCost = unit.currentCost / 1e+9f;
            unitCost.text = internalFloatCost.ToString("F2") + "B";
        }
        else if (unit.currentCost >= 1e+11f && unit.currentCost < 1e+12f)
        {
            internalFloatCost = unit.currentCost / 1e+9f;
            unitCost.text = internalFloatCost.ToString("F2") + "B";
        }
        //Trillion
        else if (unit.currentCost >= 1e+12f && unit.currentCost < 1e+13f)
        {
            internalFloatCost = unit.currentCost / 1e+12f;
            unitCost.text = internalFloatCost.ToString("F2") + "T";
        }
        else if (unit.currentCost >= 1e+13f && unit.currentCost < 1e+14f)
        {
            internalFloatCost = unit.currentCost / 1e+12f;
            unitCost.text = internalFloatCost.ToString("F2") + "T";
        }
        else if (unit.currentCost >= 1e+14f && unit.currentCost < 1e+15f)
        {
            internalFloatCost = unit.currentCost / 1e+12f;
            unitCost.text = internalFloatCost.ToString("F2") + "T";
        }
        //Quadrillion
        else if (unit.currentCost >= 1e+15f && unit.currentCost < 1e+16f)
        {
            internalFloatCost = unit.currentCost / 1e+15f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qd";
        }
        else if (unit.currentCost >= 1e+16f && unit.currentCost < 1e+17f)
        {
            internalFloatCost = unit.currentCost / 1e+15f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qd";
        }
        else if (unit.currentCost >= 1e+17f && unit.currentCost < 1e+18f)
        {
            internalFloatCost = unit.currentCost / 1e+15f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qd";
        }
        //Quintillion
        else if (unit.currentCost >= 1e+18f && unit.currentCost < 1e+19f)
        {
            internalFloatCost = unit.currentCost / 1e+18f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qt";
        }
        else if (unit.currentCost >= 1e+19f && unit.currentCost < 1e+20f)
        {
            internalFloatCost = unit.currentCost / 1e+18f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qt";
        }
        else if (unit.currentCost >= 1e+20f && unit.currentCost < 1e+21f)
        {
            internalFloatCost = unit.currentCost / 1e+18f;
            unitCost.text = internalFloatCost.ToString("F2") + "Qt";
        }
        //Sextillion
        else if (unit.currentCost >= 1e+21f && unit.currentCost < 1e+22f)
        {
            internalFloatCost = unit.currentCost / 1e+21f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sx";
        }
        else if (unit.currentCost >= 1e+22f && unit.currentCost < 1e+23f)
        {
            internalFloatCost = unit.currentCost / 1e+21f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sx";
        }
        else if (unit.currentCost >= 1e+23f && unit.currentCost < 1e+24f)
        {
            internalFloatCost = unit.currentCost / 1e+21f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sx";
        }
        //Septillion
        else if (unit.currentCost >= 1e+24f && unit.currentCost < 1e+25f)
        {
            internalFloatCost = unit.currentCost / 1e+24f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sp";
        }
        else if (unit.currentCost >= 1e+25f && unit.currentCost < 1e+26f)
        {
            internalFloatCost = unit.currentCost / 1e+24f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sp";
        }
        else if (unit.currentCost >= 1e+26f && unit.currentCost < 1e+27f)
        {
            internalFloatCost = unit.currentCost / 1e+24f;
            unitCost.text = internalFloatCost.ToString("F2") + "Sp";
        }
        //Octillion
        else if (unit.currentCost >= 1e+27f && unit.currentCost < 1e+28f)
        {
            internalFloatCost = unit.currentCost / 1e+27f;
            unitCost.text = internalFloatCost.ToString("F2") + "Oc";
        }
        else if (unit.currentCost >= 1e+28f && unit.currentCost < 1e+29f)
        {
            internalFloatCost = unit.currentCost / 1e+27f;
            unitCost.text = internalFloatCost.ToString("F2") + "Oc";
        }
        else if (unit.currentCost >= 1e+29f && unit.currentCost < 1e+30f)
        {
            internalFloatCost = unit.currentCost / 1e+27f;
            unitCost.text = internalFloatCost.ToString("F2") + "Oc";
        }
        //Nonillion
        else if (unit.currentCost >= 1e+30f && unit.currentCost < 1e+31f)
        {
            internalFloatCost = unit.currentCost / 1e+30f;
            unitCost.text = internalFloatCost.ToString("F2") + "N";
        }
        else if (unit.currentCost >= 1e+31f && unit.currentCost < 1e+32f)
        {
            internalFloatCost = unit.currentCost / 1e+30f;
            unitCost.text = internalFloatCost.ToString("F2") + "N";
        }
        else if (unit.currentCost >= 1e+32f && unit.currentCost < 1e+33f)
        {
            internalFloatCost = unit.currentCost / 1e+30f;
            unitCost.text = internalFloatCost.ToString("F2") + "N";
        }
        //Decillion
        else if (unit.currentCost >= 1e+33f && unit.currentCost < 1e+34f)
        {
            internalFloatCost = unit.currentCost / 1e+33f;
            unitCost.text = internalFloatCost.ToString("F2") + "D";
        }
        else if (unit.currentCost >= 1e+34f && unit.currentCost < 1e+35f)
        {
            internalFloatCost = unit.currentCost / 1e+33f;
            unitCost.text = internalFloatCost.ToString("F2") + "D";
        }
        else if (unit.currentCost >= 1e+35f && unit.currentCost < 1e+36f)
        {
            internalFloatCost = unit.currentCost / 1e+33f;
            unitCost.text = internalFloatCost.ToString("F2") + "D";
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
            unit.currentSol += (unit.baseSol * buySell.amount);

        if (buySell.amount != 1)
        {
            economy.solCount -= Mathf.Round(Mathf.Round((unit.currentCost * (1 - Mathf.Pow(1.15f, buySell.amount) / (1 - 1.15f)))));
        }
        else
        {
            economy.solCount -= unit.currentCost;
        }

            unit.currentCost = priceActuator(unit.baseCost, (unit.currentOwned * buySell.amount), 0f);
            economy.solPerSecond += (unit.baseSol * buySell.amount);
            unit.sellCost = unit.currentCost / 2.2f;
            if (unit.currentOwned >= buildingBuy.buildingCount[nextAch])
            {
                switch (nextAch)
                {
                    case 0:
                        achievementTracker.Unlock(unit.unitLevel);
                        achievementText.achName.text = unit.name + " Bronze";
                        achievementText.Play();
                        break;

                    case 1:
                        achievementTracker.Unlock(unit.unitLevel + 19);
                        achievementText.achName.text = unit.name + " Silver";
                        achievementText.Play();
                        break;

                    case 2:
                        achievementTracker.Unlock(unit.unitLevel + 38);
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