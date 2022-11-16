using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesList : MonoBehaviour
{
    [SerializeField] private List<GameObject> instantiatedGO;
    [SerializeField] private List<UpgradeFunction> upgradeList;
    public GameObject upgradePrefab;
    public Transform parent;

    private void Awake()
    {
        UnitBuildingEconomy.upgradeCounterInterval += UpdateList;
    }

    private void UpdateList()
    {
        for(int i = 0; i < upgradeList.Count; i++)
        {
            if(instantiatedGO.ElementAtOrDefault(i) != null)
            {
                continue;
            }
            else
            {
                Spawn(i);
            }
        }
    }

    private void Spawn(int index)
    {
        if(upgradeList[index].upgradeLevel < 3)
        {
            GameObject GO = Instantiate(upgradePrefab, parent);
            GO.GetComponent<BuyUpgrade>().unitInfo = upgradeList[index];
            instantiatedGO.Add(GO);
        }
    }

    public void RemoveFromList(int index)
    {
        instantiatedGO.RemoveAt(index);
    }

    private void OnDestroy()
    {
        UnitBuildingEconomy.upgradeCounterInterval -= UpdateList;
    }
}