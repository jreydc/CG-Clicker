using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Building", menuName = "Unit Building")]
public class BuildingUnit : ScriptableObject
{
    public Image displayImage;

    public float baseCost;
    public float baseSol;
    public float currentOwned;
}