using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpgrade : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] private List<BuildingUnit> unitData;
    [SerializeField] private static List<UnitTierUpgrade> unitInfo;

    private void Awake()
    {
        
    }
}