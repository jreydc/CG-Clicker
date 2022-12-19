using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades")]
public class UpgradeFunction : ScriptableObject
{
    //Might become obselete
    /*
    public enum Upgrade
    {
        Tap,
        SPS,
        GTPS
    };

    public Upgrade upgradeType;
    */
    public int upgradeLevel = 1;
    [SerializeField] internal float baseProduction;
    public float currentProduction;
    [SerializeField] internal float baseUpgradeCost;
    public float currentUpgradeCost;
    public int ID;
    public Sprite image;
    [TextArea]
    public string function;
}