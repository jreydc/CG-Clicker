using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDataHandler : MonoBehaviour
{
    [SerializeField] private List<BuildingUnit> building;
    [SerializeField] private List<UpgradeFunction> upgrade;

    [SerializeField] string jsonFileName;
    string jsonDataB, jsonDataU;
    string path;

    private void Awake()
    {
        ReadFromJson();
    }

    
    public void WriteToJson()
    {
        for(int i = 0; i < building.Count; i++)
        {
            path = DataPath(jsonFileName + building[i].unitID);
            CheckFileExistance(path, false, i);

            bData sData = new bData();

            sData.cCost = building[i].currentCost;
            sData.cSol = building[i].currentSol;
            sData.cOwned = building[i].currentOwned;
            sData.cLevel = building[i].unitLevel;
            sData.sellCost = building[i].sellCost;

            jsonDataB = JsonUtility.ToJson(sData);
            File.WriteAllText(path, jsonDataB);
        }

        for(int i = 0; i < upgrade.Count; i++)
        {
            path = DataPath(jsonFileName + "U" + upgrade[i].ID);
            CheckFileExistance(path, false, i);

            uData sData = new uData();

            sData.uCost = upgrade[i].currentUpgradeCost;
            sData.uProduction = upgrade[i].currentProduction;
            sData.uLevel = upgrade[i].upgradeLevel;

            jsonDataU = JsonUtility.ToJson(sData);
            File.WriteAllText(path, jsonDataU);
        }
    }

    private void ReadFromJson()
    {
        for(int i = 0; i < building.Count; i++)
        {
            path = DataPath(jsonFileName + building[i].unitID);
            CheckFileExistance(path, true);

            jsonDataB = File.ReadAllText(path);

            bData lData = new bData();
            lData = JsonUtility.FromJson<bData>(jsonDataB);

            lData.cCost = building[i].currentCost;
            lData.cLevel = building[i].unitLevel;
            lData.cOwned = building[i].currentOwned;
            lData.cSol = building[i].currentSol;
            lData.sellCost = building[i].sellCost;

            GameObject.FindObjectOfType<UnitBuildingEconomy>().RefreshForUpgrades(i);
        }

        for (int i = 0; i < upgrade.Count; i++)
        {
            path = DataPath(jsonFileName + "U" + upgrade[i].ID);
            CheckFileExistance(path, true);

            jsonDataU = File.ReadAllText(path);

            uData lData = new uData();
            lData = JsonUtility.FromJson<uData>(jsonDataU);

            lData.uCost = upgrade[i].currentUpgradeCost;
            lData.uLevel = upgrade[i].upgradeLevel;
            lData.uProduction = upgrade[i].currentProduction;

            GameObject.FindObjectOfType<UnitBuildingEconomy>().RefreshForUpgrades(i);
        }
    }

    private string DataPath(string file)
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            return Path.Combine(Application.persistentDataPath, file);
        }
        return Path.Combine(Application.streamingAssetsPath, file);
    }

    private void CheckFileExistance(string filePath, bool isReading = false, int i = 0)
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            if (isReading)
            {
                //SetStartingData();
                for(int j = 0; j < building.Count; j++)
                {
                    bData sData = new bData();

                    sData.cCost = building[j].currentCost;
                    sData.cSol = building[j].currentSol;
                    sData.cOwned = building[j].currentOwned;
                    sData.cLevel = building[j].unitLevel;
                    sData.sellCost = building[j].sellCost;

                    jsonDataB = JsonUtility.ToJson(sData);
                    File.WriteAllText((filePath + building[j].unitID), jsonDataB);
                }

                for (int j = 0; j < upgrade.Count; j++)
                {
                    path = DataPath(jsonFileName + upgrade[j].ID);
                    CheckFileExistance(path, false, j);

                    uData sData = new uData();

                    sData.uCost = upgrade[j].currentUpgradeCost;
                    sData.uProduction = upgrade[j].currentProduction;
                    sData.uLevel = upgrade[j].upgradeLevel;

                    jsonDataU = JsonUtility.ToJson(sData);
                    File.WriteAllText((filePath + "U" + upgrade[j].ID), jsonDataU);
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        WriteToJson();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            WriteToJson();
    }

    private class bData
    {
        public float cCost;
        public float cSol;
        public float cOwned;
        public float cLevel;
        public float sellCost;
    }

    private class uData
    {
        public int uLevel;
        public float uProduction;
        public float uCost;
    }
}