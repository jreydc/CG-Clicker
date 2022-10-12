using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgadesLogic : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] private List<BuildingUnit> unitData;
    [SerializeField] private static List<UnitTierUpgrade> unitInfo;

    private void Awake()
    {
        UnitDataHolder.onClickCaluclate += UpgradeFunction;
    }

    void UpgradeFunction()
    {

    }
}