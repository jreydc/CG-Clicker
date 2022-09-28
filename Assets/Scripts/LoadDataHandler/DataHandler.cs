using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private PointsFunction pfMain;
    [SerializeField] private NewUpgradesFunction upgradeMain;
    string jsonData;

    private void Awake()
    {
        pfMain = FindObjectOfType<PointsFunction>();
        upgradeMain = FindObjectOfType<NewUpgradesFunction>();
        LoadData();
    }

    private void Start()
    {
        
    }

    public void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/dataFile.json");
        Data loadedPData = JsonUtility.FromJson<Data>(jsonData);

        pfMain._score = loadedPData.currentPoints;
        pfMain._scoreToAdd = loadedPData.currentTPS;
        pfMain._passiveScore = loadedPData.currentSPS;
        upgradeMain.upgradeLevelList = loadedPData.upgradeLevelList;
        upgradeMain.currentUpgradeCost = loadedPData.currentUpgradeCost;
        upgradeMain.incrementalUpgradeCost = loadedPData.currentIteration;
    }

    public void SaveData()
    {
        Data pData = new Data();

        pData.currentPoints = pfMain._score;
        pData.currentTPS = pfMain._scoreToAdd;
        pData.currentSPS = pfMain._passiveScore;
        pData.upgradeLevelList = new List<int>();
        pData.upgradeLevelList = upgradeMain.upgradeLevelList;
        pData.currentUpgradeCost = new List<int>();
        pData.currentUpgradeCost = upgradeMain.currentUpgradeCost;
        pData.currentIteration = new List<int>();
        pData.currentIteration = upgradeMain.incrementalUpgradeCost;

        jsonData = JsonUtility.ToJson(pData);
        File.WriteAllText(Application.dataPath + "/dataFile.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }


    private class Data
    {
        public double currentPoints;
        public int currentTPS;
        public int currentSPS;

        public List<int> upgradeLevelList;
        public List<int> currentUpgradeCost;
        public List<int> currentIteration;
    }
}