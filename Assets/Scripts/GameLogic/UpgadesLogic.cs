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

    public delegate void SaveData(GameObject instantiatedObject, int unitID);
    public static event SaveData saveData;

    private void Awake()
    {
        //UnitDataHolder.upgradeCounterInterval += Count;
    }

    public void InitializeDelegate()
    {
        UnitDataHolder.upgradeCounterInterval += Count;
        //Added Counter
    }

    public void DestroyDelegate()
    {
        UnitDataHolder.upgradeCounterInterval -= Count;
        //Deleted Counter
    }

    private void Start()
    {
        //A
    }

    void Count()
    {
        for(int i = 0; i < unitInstances.Count; i++)
        {
            if (i == 1)
            {
                switch (unitInstances[i].currentOwned)
                {
                    case 1:
                        {
                            for(int j = 2; i < unitInstances.Count; i++)
                            {
                                if(unitInstances[j].currentOwned == 15)
                                {
                                    UpgradeFunction(j);
                                    break;
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                switch (unitInstances[i].currentOwned)
                {
                    case 1:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 5:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 10:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 25:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 50:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 100:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 150:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 200:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 250:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 300:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 350:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 400:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 450:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                    case 500:
                        {
                            UpgradeFunction(i);
                            break;
                        }
                }
            }
        }
    }

    void UpgradeFunction(int index)
    {
        currentID = unitInstances[index].unitID;
        GameObject GO = Instantiate(upgradeInstance, parent.transform);
        saveData(GO, (currentID - 1));
    }

    private void OnDestroy()
    {
        UnitDataHolder.upgradeCounterInterval -= Count;
    }

    private void OnApplicationQuit()
    {
        UnitDataHolder.upgradeCounterInterval -= Count;
    }
}