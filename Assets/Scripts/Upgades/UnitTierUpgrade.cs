using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Upgrade Tier ")]
public class UnitTierUpgrade : ScriptableObject
{
    [Range(0, 20)]
    public int unitIdentifier;

    public float multiplier;

    public int currentLevel;


    public float basePrice;
    private float priceMultiplier = 5f;

    private void Awake()
    {
        PriceIterator();
    }

    public float UpgradeTPS(int _currentLevel, float currentTPS)
    {
        currentLevel++;
        PriceIterator();
        return currentTPS *= multiplier;
    }

    public float UpgradeSPS(int _currentLevel, float currentSPS)
    {
        currentLevel++;
        PriceIterator();
        return currentSPS *= multiplier;
    }

    public float UpgradeSPS5(int _currentLevel, float currentSPS)
    {
        currentLevel++;
        PriceIterator();
        return currentSPS *= 5;
    }
    public float UpgradeSPS10(int _currentLevel, float currentSPS)
    {
        currentLevel++;
        PriceIterator();
        return currentSPS *= 10;
    }
    public float UpgradeSPS20(int _currentLevel, float currentSPS)
    {
        currentLevel++;
        PriceIterator();
        return currentSPS *= 20;
    }

    public float UpgradeGTPS(int _currentLevel, float currentGTPS)
    {
        currentLevel++;
        PriceIterator();
        return currentGTPS *= multiplier;
    }

    #region PRICE_VALUES
    void PriceIterator()
    {
        basePrice *= priceMultiplier;
        priceMultiplier *= 2;
    }
    #endregion
}