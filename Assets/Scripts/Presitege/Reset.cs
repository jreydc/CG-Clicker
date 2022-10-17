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

    public Button presButton;
    public GameObject presPointTex;

    private void Update()
    {
        if(presManager == null)
        {
            presManager = FindObjectOfType<PrestigeManager>();
        }

        if(presManager.totalPoints == 0)
        {
            presButton.interactable = false;
            presPointTex.SetActive(false);
        }
        else
        {
            presButton.interactable = true;
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
        presManager.tracker = 0;

        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].currentOwned = 0;
            buildings[i].unitLevel = 1;
            buildings[i].currentCost = buildings[i].baseCost;
            buildings[i].currentSol = 0;
        }

        scene.Prestiege();

        yield return null;
    }
}
