using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private UnitBuildingEconomy unitBuildingEconomy;
    [SerializeField] private PrestigeManager prestigeManager;
    //[SerializeField] private UpgradeListData upgradeDataList;
    [SerializeField] string jsonFileName;
    string jsonData;
    string path;

    private void Awake()
    {
        unitBuildingEconomy = FindObjectOfType<UnitBuildingEconomy>();
        //prestigeManager = FindObjectOfType<PrestigeManager>();

        ReadFromJson();
    }

    public void WriteToJson()
    {
        path = DataPath();
        CheckFileExistance(path);

        Data sData = new Data();

        sData.currentPoints = unitBuildingEconomy.solCount;
        sData.currentSPS = unitBuildingEconomy.solPerSecond;
        sData.currentTPS = unitBuildingEconomy.tapsPerSecond;

        jsonData = JsonUtility.ToJson(sData);
        File.WriteAllText(path, jsonData);
    }

    private void ReadFromJson()
    {
        path = DataPath();
        CheckFileExistance(path, true);

        jsonData = File.ReadAllText(path);

        Data lData = new Data();

        lData = JsonUtility.FromJson<Data>(jsonData);

        unitBuildingEconomy.solCount = lData.currentPoints;
        unitBuildingEconomy.solPerSecond = lData.currentSPS;
        if(unitBuildingEconomy.tapsPerSecond > 0)
            unitBuildingEconomy.tapsPerSecond = lData.currentTPS;


    }

    private string DataPath()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            return Path.Combine(Application.persistentDataPath, jsonFileName);
        }
        return Path.Combine(Application.streamingAssetsPath, jsonFileName);
    }

    private void CheckFileExistance(string filePath, bool isReading = false)
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            if (isReading)
            {
                //SetStartingData();

                Data sData = new Data();

                sData.currentPoints = unitBuildingEconomy.solCount;
                sData.currentSPS = unitBuildingEconomy.solPerSecond;
                sData.currentTPS = unitBuildingEconomy.tapsPerSecond;

                jsonData = JsonUtility.ToJson(sData);

                File.WriteAllText(filePath, jsonData);
            }
        }
    }

    private void OnApplicationQuit()
    {
        WriteToJson();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
            WriteToJson();
    }

    private class Data
    {
        public float currentPoints;
        public float currentTPS;
        public float currentSPS;
        //public List<GameObject> dataList;
    }
}