using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private PointsFunction pfMain;
    string jsonData;

    private void Awake()
    {
        pfMain = FindObjectOfType<PointsFunction>();
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
    }

    public void SaveData()
    {
        Data pData = new Data();

        pData.currentPoints = pfMain._score;
        pData.currentTPS = pfMain._scoreToAdd;
        pData.currentSPS = pfMain._passiveScore;

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
    }
}