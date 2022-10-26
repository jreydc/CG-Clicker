using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsLogic : MonoBehaviour
{
    [SerializeField] private List<BuildingUnit> unit;
    [SerializeField] private GameObject unitGO;
    [SerializeField] private List<GameObject> listUnitGO;

    public delegate void spawnSpecificBuilding(int index);
    public static event spawnSpecificBuilding spawnBuilding;

    private void Awake()
    {
        UnitBuildingEconomy.buildingCounterInterval += CheckBuildingReqs;
        UnitBuildingEconomy.initSpawn += SpawnInstant;
    }

    void CheckBuildingReqs(float currentSol)
    {
        for(int i = 0; i < unit.Count; i++)
        {
            if(currentSol >= unit[i].currentCost)
            {
                if (listUnitGO.ElementAtOrDefault(i) != null)
                {
                    //continue
                    continue;
                }
                else
                {
                    Spawn(i);
                    break;
                }
            }
        }
    }

    void SpawnInstant(float currentSol)
    {
        for (int i = 0; i < unit.Count; i++)
        {
            if (currentSol >= unit[i].currentCost)
            {
                Spawn(i);
            }
        }
    }

    void Spawn(int index)
    {
        GameObject spawnedGO = Instantiate(unitGO, this.transform);
        spawnedGO.GetComponent<UnitDataHolder>().setUnit(index);
        listUnitGO.Add(spawnedGO);
    }
}