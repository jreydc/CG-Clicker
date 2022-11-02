using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeListData : MonoBehaviour
{
    public List<GameObject> dataGO;

    public List<UnitTierUpgrade> tierList;

    [SerializeField] private List<int> unitID;

    public int instanceCount;
    public GameObject dataGOPrefab;
    string jsonData;

    [SerializeField] private DataHandler dataHandler;
    private void Awake()
    {
        UpgadesLogic.saveData += GetDataGO;
        //DataHandler.loadDataList += LoadData;
        dataHandler = FindObjectOfType<DataHandler>();
        instanceCount = PlayerPrefs.GetInt("InstanceCount");
    }

    private void Start()
    {
        LoadData();
    }

    void GetDataGO(GameObject instantiatedObject, int unitID)
    {
        dataGO.Add(instantiatedObject);
        StoreID(unitID);
        //Save load Data because we can't serialize it
    }

    void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/upgradeDataFile.json");
        loadData loadedData = JsonUtility.FromJson<loadData>(jsonData);

        for (int i = 0; i < instanceCount; i++)
        {
            if (dataGO.ElementAtOrDefault(i) != null)
            {
                GameObject GO = Instantiate(dataGOPrefab, this.transform);
                GO.GetComponent<BuyUpgrade>().GetUnitInfo(tierList[loadedData.unitID[i]]);
                dataGO.Add(GO);
            }
        }
        Debug.Log("Load Data");
    }

    public void OnApplicationQuit()
    {
        instanceCount = dataGO.Count;
        PlayerPrefs.SetInt("InstanceCount", instanceCount);
        PlayerPrefs.Save();
        SaveData();
    }

    void SaveData()
    {
        loadData data = new loadData();
        data.unitID = new List<int>();

        for(int i = 0;i < dataGO.Count; i++)
        {
            data.unitID.Add(unitID[i]);
        }

        jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/upgradeDataFile.json", jsonData);
        Debug.Log("Saved Data " + instanceCount);
    }

    public void StoreID(int id)
    {
        unitID.Add(id);
    }

    public void DestroyID(int id)
    {
        for(int i = 0; i < unitID.Count; i++)
        {
            if(unitID[i] == id)
            {
                unitID.RemoveAt(i);
            }
        }
    }

    public class loadData
    {
        public List<int> unitID;
    }
}