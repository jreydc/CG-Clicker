using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reset : MonoBehaviour
{
    public BuildingUnit[] buildings;
    public UnitBuildingEconomy economy;
    public PrestigeManager presManager;
    public SceneLoader scene;
    public DataHandler data;

    public GameObject presButton;
    public GameObject presPointTex;

    private void Update()
    {
        if(presManager == null)
        {
            presManager = FindObjectOfType<PrestigeManager>();
        }

        if(presManager.totalPoints == 0)
        {
            presButton.SetActive(false);
            presPointTex.SetActive(false);
        }
        else
        {
            presButton.SetActive(true);
            presPointTex.SetActive(true);
        }
    }

    // Update is called once per frame
    public void Re()
    {
        StartCoroutine("Redo");
    }

    private IEnumerator Redo()
    {
        economy.solCount = 0;
        economy.solPerSecond = 0.1f;
        economy.tapsPerSecond = 1;
        presManager.tracker = 0;

        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].currentOwned = 0;
            buildings[i].unitLevel = 1;
            buildings[i].currentCost = buildings[i].baseCost;
            buildings[i].currentSol = 0;
        }

        data.WriteToJson();
        scene.Prestiege();

        yield return null;
    }
}
