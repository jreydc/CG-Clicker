using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PrestigeSaveLoad : MonoBehaviour
{
    [SerializeField] private PrestigeDataHandler prestigeData;
    string jsonData;

    private void Awake()
    {
        prestigeData = FindObjectOfType<PrestigeDataHandler>();

        LoadData();
    }

    private void Start()
    {

    }

    public void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/dataFile.json");
        Data loadedPData = JsonUtility.FromJson<Data>(jsonData);

        for (int i = 0; i < loadedPData.presCheck.Length; i++)
        {
            prestigeData.checkers[i] = loadedPData.presCheck[i];
        }
    }

    public void SaveData()
    {
        Data pData = new Data();

        for (int i = 0; i < pData.presCheck.Length; i++)
        {
            pData.presCheck[i] = prestigeData.checkers[i];
        }

        jsonData = JsonUtility.ToJson(pData);
        File.WriteAllText(Application.dataPath + "/dataFile.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }


    private class Data
    {
        public bool[] presCheck = new bool[17];
    }
}
