using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeListData : MonoBehaviour
{
    public List<GameObject> dataGO;

    public List<GameObject> loadedDataGO;

    [SerializeField] private DataHandler dataHandler;
    private void Awake()
    {
        UpgadesLogic.saveData += saveData;
        DataHandler.loadDataList += LoadData;
        dataHandler = FindObjectOfType<DataHandler>();
    }

    void saveData(GameObject instantiatedObject)
    {
        dataGO.Add(instantiatedObject);

        //Save load Data because we can't serialize it
    }

    void LoadData()
    {
        for(int i = 0;i < dataGO.Count; i++)
        {

        }
    }
}