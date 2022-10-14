using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgadesLogic : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] internal List<UnitTierUpgrade> unitInfo;
    internal int currentID;

    public GameObject upgradeInstance;
    public Transform parent;

    private void Awake()
    {
        UnitDataHolder.onClickCaluclate += UpgradeFunction;
    }

    void UpgradeFunction(BuildingUnit unit)
    {
        currentID = unit.unitID;
        Instantiate(upgradeInstance, parent.transform);
    }
}