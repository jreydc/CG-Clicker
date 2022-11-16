using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EconomyManager;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] internal UpgradeFunction unitInfo;

    [SerializeField] private TextMeshProUGUI levelText;

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