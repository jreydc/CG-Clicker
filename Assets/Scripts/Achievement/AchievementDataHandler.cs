using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AchievementDataHandler : MonoBehaviour
{
    [SerializeField] AchievementTracker achievementTracker;
    string jsonData;

    void Awake()
    {
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        jsonData = File.ReadAllText(Application.dataPath + "/achievementFile.json");
        Data loadedPData = JsonUtility.FromJson<Data>(jsonData);

        for (int i = 0; i < achievementTracker.achievements.Length; i++)
        {
            achievementTracker.achievements[i] = loadedPData.unlocks[i];
        }
    }

    // Update is called once per frame
    public void SaveData()
    {
        Data pData = new Data();

        for (int i = 0; i < achievementTracker.achievements.Length; i++)
        {
            pData.unlocks[i] = achievementTracker.achievements[i];
        }

        jsonData = JsonUtility.ToJson(pData);
        File.WriteAllText(Application.dataPath + "/achievementFile.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private class Data
    {
        public bool[] unlocks = new bool[19];
    }
}
