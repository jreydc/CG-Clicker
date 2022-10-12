using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Upgrade Tier ")]
public class UnitTierUpgrade : ScriptableObject
{
    [Range(0, 19)]
    public int unitIdentifier;

    public float tpsUpgrade;
    public float gtpsUpgrade;
    public float spsUpgrade;

    public float UpgradeTPS(int currentLevel, float currentTPS)
    {
        return currentTPS *= tpsUpgrade;
    }
}