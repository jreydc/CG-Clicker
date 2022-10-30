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
        spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "+" + (unit.tapsPerSecond * multipliers.clickMulti) + " Sols";
    }

    public void ToucSpawn()
    {
        GameObject spawnedText = Instantiate(text, Input.mousePosition, transform.rotation);
        spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "+" + touc.bonusSol + " Sols";
    }

    private void Update()
    {
        if(touc == null)
        {
            touc = FindObjectOfType<Toucan>();
        }
    }
}
