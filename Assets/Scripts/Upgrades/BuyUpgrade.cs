using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EconomyManager;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] internal UpgradeFunction unitInfo;

    [SerializeField] private TextMeshProUGUI levelText, priceText, functionText;

    public Image dispImage;

    private void Awake()
    {
        dispImage.sprite = unitInfo.image;

        levelText.text = unitInfo.upgradeLevel.ToString();
        priceText.text = unitInfo.upgradeCost.ToString();
        functionText.text = unitInfo.function;
    }

    private void Update()
    {
        levelText.text = unitInfo.upgradeLevel.ToString();
    }

    public void OnClick_Buy()
    {
        unitInfo.BuyFunction();
        //Destroy(gameObject);
    }
}