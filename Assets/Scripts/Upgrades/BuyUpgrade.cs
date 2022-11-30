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
        unitInfo.BuyFunction();
        //Destroy(gameObject);
    }
}