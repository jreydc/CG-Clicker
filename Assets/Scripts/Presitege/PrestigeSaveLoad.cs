using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PrestigeSaveLoad : MonoBehaviour
{
    [SerializeField] private PrestigeDataHandler prestigeData;
    [SerializeField] private PrestigeManager prestigeManager;
    [SerializeField] private Multipliers multipliers;
    string jsonData;

    private void Awake()
    {
        prestigeData = GetComponent<PrestigeDataHandler>();
        prestigeManager = GetComponent<PrestigeManager>();
        multipliers = GetComponent<Multipliers>();

        LoadData();
    }

    private void Start()
    {

    }

    public void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/presDataFile.json");
        Data loadedPData = JsonUtility.FromJson<Data>(jsonData);
        /*
        prestigeData.checkers[0] = loadedPData.upgrade0;
        prestigeData.checkers[1] = loadedPData.upgrade1;
        prestigeData.checkers[2] = loadedPData.upgrade2;
        prestigeData.checkers[3] = loadedPData.upgrade3;
        prestigeData.checkers[4] = loadedPData.upgrade4;
        prestigeData.checkers[5] = loadedPData.upgrade5;
        prestigeData.checkers[6] = loadedPData.upgrade6;
        prestigeData.checkers[7] = loadedPData.upgrade7;
        prestigeData.checkers[8] = loadedPData.upgrade8;
        prestigeData.checkers[9] = loadedPData.upgrade9;
        prestigeData.checkers[10] = loadedPData.upgrade10;
        prestigeData.checkers[11] = loadedPData.upgrade11;
        prestigeData.checkers[12] = loadedPData.upgrade12;
        prestigeData.checkers[13] = loadedPData.upgrade13;
        prestigeData.checkers[14] = loadedPData.upgrade14;
        prestigeData.checkers[15] = loadedPData.upgrade15;
        prestigeData.checkers[16] = loadedPData.upgrade16;
        */

        prestigeManager.presPoint = loadedPData.prestigePoints;
        multipliers.autoMulti = loadedPData.autoMultiplier;
        multipliers.clickMulti = loadedPData.clickMultiplier;

        prestigeManager.tracker = loadedPData.presTracker;
        prestigeManager.cost = loadedPData.presCost;
        prestigeManager.totalPoints = loadedPData.prestigePointTotal;
    }

    public void SaveData()
    {
        Data pData = new Data();

        /*
        pData.upgrade0 = prestigeData.checkers[0];
        pData.upgrade1 = prestigeData.checkers[1];
        pData.upgrade2 = prestigeData.checkers[2];
        pData.upgrade3 = prestigeData.checkers[3];
        pData.upgrade4 = prestigeData.checkers[4];
        pData.upgrade5 = prestigeData.checkers[5];
        pData.upgrade6 = prestigeData.checkers[6];
        pData.upgrade7 = prestigeData.checkers[7];
        pData.upgrade8 = prestigeData.checkers[8];
        pData.upgrade9 = prestigeData.checkers[9];
        pData.upgrade10 = prestigeData.checkers[10];
        pData.upgrade11 = prestigeData.checkers[11];
        pData.upgrade12 = prestigeData.checkers[12];
        pData.upgrade13 = prestigeData.checkers[13];
        pData.upgrade14 = prestigeData.checkers[14];
        pData.upgrade15 = prestigeData.checkers[15];
        pData.upgrade16 = prestigeData.checkers[16];

        pData.prestigePoints = prestigeManager.presPoint;
        pData.autoMultiplier = multipliers.autoMulti;
        pData.clickMultiplier = multipliers.clickMulti;

        pData.presTracker = prestigeManager.tracker;
        pData.presCost = prestigeManager.cost;
        pData.prestigePointTotal = prestigeManager.totalPoints;
        */

        jsonData = JsonUtility.ToJson(pData);
        File.WriteAllText(Application.dataPath + "/presDataFile.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }


    private class Data
    {
        public bool upgrade0;
        public bool upgrade1;
        public bool upgrade2;
        public bool upgrade3;
        public bool upgrade4;
        public bool upgrade5;
        public bool upgrade6;
        public bool upgrade7;
        public bool upgrade8;
        public bool upgrade9;
        public bool upgrade10;
        public bool upgrade11;
        public bool upgrade12;
        public bool upgrade13;
        public bool upgrade14;
        public bool upgrade15;
        public bool upgrade16;

        public int prestigePoints;
        public float autoMultiplier;
        public float clickMultiplier;

        public float presTracker;
        public int prestigePointTotal;
        public float presCost;
    }
}
