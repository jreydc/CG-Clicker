using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitBuildingEconomy;
    [SerializeField] private PrestigeManager prestigeManager;
    //[SerializeField] private UpgradeListData upgradeDataList;
    string jsonData;

    private void Awake()
    {
        unitBuildingEconomy = FindObjectOfType<UnitBuildingEconomy>();
        prestigeManager = FindObjectOfType<PrestigeManager>();
        //upgradeDataList = FindObjectOfType<UpgradeListData>();

        LoadData();
    }

    void Start()
    {
        //LoadData();
    }

    public void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/dataFile.json");
        Data loadedPData = JsonUtility.FromJson<Data>(jsonData);

        unitBuildingEconomy.solCount = loadedPData.currentPoints;
        unitBuildingEconomy.tapsPerSecond = loadedPData.currentTPS;
        unitBuildingEconomy.solPerSecond = loadedPData.currentSPS;
        //upgradeDataList.dataGO = loadedPData.dataList;
        //loadDataList();
        /*
        upgradeMain.upgradeLevelList = loadedPData.upgradeLevelList;
        upgradeMain.currentUpgradeCost = loadedPData.currentUpgradeCost;
        upgradeMain.incrementalUpgradeCost = loadedPData.currentIteration;
        */
    }

    public void SaveData()
    {
        Data pData = new Data();

        pData.currentPoints = unitBuildingEconomy.solCount;
        pData.currentTPS = unitBuildingEconomy.tapsPerSecond;
        pData.currentSPS = unitBuildingEconomy.solPerSecond;
        //spData.dataList = upgradeDataList.dataGO;
        /*
        pData.upgradeLevelList = new List<int>();
        pData.upgradeLevelList = upgradeMain.upgradeLevelList;
        pData.currentUpgradeCost = new List<int>();
        pData.currentUpgradeCost = upgradeMain.currentUpgradeCost;
        pData.currentIteration = new List<int>();
        pData.currentIteration = upgradeMain.incrementalUpgradeCost;
        */
        
        //Serialization
        //Machine Code > Assembly Languge > High Level (C#) > Unity Native Engine (GameObject, Prefab instance, vector, int etc.)

        jsonData = JsonUtility.ToJson(pData);
        File.WriteAllText(Application.dataPath + "/dataFile.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }


    private class Data
    {
        public float currentPoints;
        public float currentTPS;
        public float currentSPS;
        //public List<GameObject> dataList;
    }
}