using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdManager : MonoBehaviour
{
    public TextMeshProUGUI spawnedText;
    [SerializeField] SpawnToucan spawnToucan;
    [SerializeField] Toucan toucan;
    [SerializeField] ShineSpin shineSpin;

    void Update()
    {
        if(toucan == null)
        {
            toucan = FindObjectOfType<Toucan>();
        }

        if(shineSpin == null)
        {
            shineSpin = FindObjectOfType<ShineSpin>();
        }
    }

    public void WatchAd(int toucChooser, int bonusTime, float bonusSol)
    {
        switch (toucChooser)
        {
            case 1:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "Watch an Ad for +" + Mathf.RoundToInt(bonusSol) + " Sols";
                break;

            case 2:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "Watch an Ad for x7 Auto Sols for " + bonusTime + " Seconds!";
                break;

            case 3:
                spawnedText.GetComponentInChildren<TextMeshProUGUI>().text = "Watch an Ad for x7 Tap Sols for " + bonusTime + " Seconds!";
                break;
        }
    }

    public void AdWatched()
    {
        toucan.GiveBonus();
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
