using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgadesLogic : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitMain;
    [SerializeField] private List<BuildingUnit> unitInstances;
    //[SerializeField] internal List<UnitTierUpgrade> unitInfo;
    internal int currentID;
    internal int indexID;

    public GameObject upgradeInstance;
    public Transform parent;

    public delegate void SaveData(GameObject instantiatedObject, int unitID);
    public static event SaveData saveData;

    private void Awake()
    {
        //UnitDataHolder.upgradeCounterInterval += Count;
    }

    public void InitializeDelegate()
    {
        //UnitDataHolder.upgradeCounterInterval += Count;
        //Added Counter
    }

    private void Start()
    {
        //A
    }

    void Count()
    {

    }

    void UpgradeFunction(int index)
    {
        currentID = unitInstances[index].unitID;
        GameObject GO = Instantiate(upgradeInstance, parent.transform);
        saveData(GO, (currentID - 1));
    }

    private void OnDestroy()
    {
        //UnitDataHolder.upgradeCounterInterval -= Count;
    }

    private void OnApplicationQuit()
    {
        //UnitDataHolder.upgradeCounterInterval -= Count;
    }
}