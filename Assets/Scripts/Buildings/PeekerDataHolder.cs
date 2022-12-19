using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekerDataHolder : MonoBehaviour
{
    [SerializeField] private List<Sprite> buildingImg;
    [SerializeField] private List<BuildingUnit> unitList;
    [SerializeField] internal BuildingUnit currentUnit;

    private void Awake()
    {
        UnitBuildingEconomy.buildingPeeker += CheckForRequirements;
    }

    void CheckForRequirements(float solCount)
    {
        
    }

    private void OnApplicationQuit()
    {
        UnitBuildingEconomy.buildingPeeker -= CheckForRequirements;
    }
}