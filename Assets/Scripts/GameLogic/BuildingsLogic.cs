using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsLogic : MonoBehaviour
{
    [SerializeField] private List<UnitDataHolder> unit;

    public delegate void spawnSpecificBuilding(int index);
    public static event spawnSpecificBuilding spawnBuilding;

    private void Awake()
    {
        UnitBuildingEconomy.buildingCounterInterval += CheckBuildingReqs;
    }

    void CheckBuildingReqs(float currentSol)
    {
        for(int i = 2; i < unit.Count; i++)
        {
            if(currentSol >= unit[i].unit.currentCost)
            {
                spawnBuilding(unit[i].unit.unitID);
                break;
            }
        }
    }
}