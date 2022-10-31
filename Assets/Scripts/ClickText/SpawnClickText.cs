using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnClickText : MonoBehaviour
{
    public GameObject text;
    private UnitBuildingEconomy unit;
    private Multipliers multipliers;
    [SerializeField]private Toucan touc;
    private float bonusToucSol;

    private void Awake()
    {
        unit = FindObjectOfType<UnitBuildingEconomy>();
        multipliers = FindObjectOfType<Multipliers>();
    }

    public void Spawn()
    {
        GameObject spawnedText = Instantiate(text, Input.mousePosition, transform.rotation);
        spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "+" + (unit.tapsPerSecond * multipliers.clickMulti * multipliers.toucClick) + " Sols";
    }

    public void ToucSpawn(int chooser, int bonusTime)
    { 
        GameObject spawnedText = Instantiate(text, Input.mousePosition, transform.rotation);

        switch (chooser)
        {
            case 1:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "+" + Mathf.RoundToInt(touc.bonusSol) + " Sols";
                break;

            case 2:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "x7 Auto Sols for " + bonusTime + " Seconds!";
                break;

            case 3:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "x7 Tap Sols for " + bonusTime + " Seconds!";
                break;
        }
        
    }

    private void Update()
    {
        if(touc == null)
        {
            touc = FindObjectOfType<Toucan>();
        }
    }
}
