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

    public delegate void upgradeCounter();
    public static event upgradeCounter upgradeCounterInterval;


    [SerializeField] PlaySound sound;

    [SerializeField] AchievementTracker achievementTracker;
    [SerializeField] BuildingBuyCount buildingBuy;
    [SerializeField] int nextAch;

    [SerializeField] BuySellMode buySell;

    private void Awake()
    {
        buySell = FindObjectOfType<BuySellMode>();
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

            unitCost.text = Mathf.Round(Mathf.Round((unit.currentCost * (Mathf.Pow(1 + 1.15f, buySell.amount) / (1 + 1.15f))))).ToString("F0");

            buyButton.GetComponent<Image>().color = Color.white;
            if (economy.solCount >= Mathf.Round(Mathf.Round((unit.currentCost * (Mathf.Pow(1 + 1.15f, buySell.amount) / (1 + 1.15f))))))
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
            unitCost.text = unit.sellCost.ToString("F0");

            if (unit.currentOwned != 0)
            {
                buyButton.interactable = true;
                unitCost.text = unit.sellCost.ToString("F0");
            }
            else
            {
                buyButton.interactable = false;
                unitCost.text = "";
            }
            buyButton.GetComponent<Image>().color = Color.red;
            buyButton.interactable = true;
        }
    }

    public void OnClick_Buy()
    {
        if (buySell.buy == true)
        {

            if (economy.solCount >= Mathf.Round(Mathf.Round((unit.currentCost * (Mathf.Pow(1 + 1.15f, buySell.amount) / (1 + 1.15f))))))
            {
                OnBuy();
                upgradeCounterInterval();
            }
        }
        else
        {
            OnSell();
        }
    }

        void OnBuy()
        {
            unit.unitLevel += buySell.amount;
            unit.currentOwned += buySell.amount;
            unit.currentSol += unit.baseSol * buySell.amount;
            economy.solCount -= Mathf.Round(Mathf.Round((unit.currentCost * (Mathf.Pow(1 + 1.15f, buySell.amount) / (1 + 1.15f)))));
            unit.currentCost = priceActuator(unit.baseCost, unit.currentOwned, 0f);
            economy.solPerSecond += unit.currentSol;
            unit.sellCost = unit.currentCost / 2.2f;
            if (unit.currentOwned >= buildingBuy.buildingCount[nextAch])
            {
                achievementTracker.Unlock(unit.unitID);
                nextAch++;
            }
            sound.Buy();
        }

        void OnSell()
        {
            unit.unitLevel--;
            unit.currentOwned--;
            unit.currentSol -= unit.baseSol;
            economy.solCount += unit.sellCost;
            unit.currentCost = priceActuator(unit.baseCost, unit.currentOwned, 0f);
            economy.solPerSecond -= unit.currentSol;
            unit.sellCost = unit.currentCost / 2.2f;
            sound.Buy();
        }

        //Where M is the number of that type of unit you own
        // and F as the number of that type of unit you recieve for free
        private float priceActuator(float baseCost, float M, float F)
        {
            float price = Mathf.Round(baseCost * (Mathf.Pow(1.15f, (M - F))));
            return price;
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