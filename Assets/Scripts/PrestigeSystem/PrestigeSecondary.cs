using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigeSecondary : MonoBehaviour
{
    [SerializeField] private GameObject prestigeGOInstance;
    [SerializeField] private List<GameObject> prestigeList;
    [SerializeField] private List<PrestigeData> storedData;

    [SerializeField] internal PrestigeMain prestigeMain;

    [SerializeField] private Transform transformParent;

    private void Awake()
    {
        PrestigeMain.CheckRequirements += CheckPrestigeReqs;
    }

    private void Start()
    {
        prestigeMain = FindObjectOfType<PrestigeMain>();
    }

    private void CheckPrestigeReqs(float prestigePoints)
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            if (prestigePoints >= storedData[i].cost && prestigePoints != 0)
            {
                if (prestigeList.ElementAtOrDefault(i) != null)
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

    void Spawn(int index)
    {
        GameObject GO = Instantiate(prestigeGOInstance, transformParent);
        GO.GetComponent<PrestigeDataHandler>().data = storedData[index];
        prestigeList.Add(GO);
    }

    private void OnDestroy()
    {
        PrestigeMain.CheckRequirements -= CheckPrestigeReqs;
    }
}