using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPeekerLogic : MonoBehaviour
{
    [SerializeField] private GameObject toInstantiate;
    [SerializeField] private List<BuildingUnit> building;


    private void Awake()
    {
        UnitBuildingEconomy.buildingPeeker += CheckCounter;
    }

    void CheckCounter(float solCount)
    {
        for(int i = 0; i < building.Count; i++)
        {
            if(solCount < building[i].currentCost)
            {

            }
        }
    }

    void Spawn()
    {

    }

    private void OnApplicationQuit()
    {
        UnitBuildingEconomy.buildingPeeker -= CheckCounter;
    }
}