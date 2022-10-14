using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgadesLogic : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] private List<BuildingUnit> unitInstances;
    [SerializeField] internal List<UnitTierUpgrade> unitInfo;
    internal int currentID;
    internal int indexID;

    public GameObject upgradeInstance;
    public Transform parent;

    private void Awake()
    {
        UnitBuildingEconomy.upgradeCounterInterval += Count;
    }

    void Count()
    {
        for(int i = 0; i < unitInstances.Count; i++)
        {

        }
    }

    void UpgradeFunction()
    {
        currentID = unitInstances[indexID].unitID;
        Instantiate(upgradeInstance, parent.transform);
    }
}