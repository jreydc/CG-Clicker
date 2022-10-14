using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Upgrade Tier ")]
public class UnitTierUpgrade : ScriptableObject
{
    [Range(0, 19)]
    public int unitIdentifier;

    public float multiplier;

    public int currentLevel;

    public float basePrice;

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

    public float UpgardeSPS(int _currentLevel, float currentSPS)
    {
        currentLevel++;
        PriceIterator();
        return currentSPS *= multiplier;
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
        basePrice *= 10;
    }
    #endregion
}