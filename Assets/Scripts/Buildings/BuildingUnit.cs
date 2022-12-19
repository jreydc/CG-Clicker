using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Building", menuName = "Unit Building")]
public class BuildingUnit : ScriptableObject
{
    public Sprite displayImage;

    public float baseCost;
    public float currentCost; //Need
    public float baseSol;
    public float currentSol; //Need
    public float currentOwned; //Need
    public int unitLevel = 1; // Need
    public int unitID;

    public float sellCost; //Need
}