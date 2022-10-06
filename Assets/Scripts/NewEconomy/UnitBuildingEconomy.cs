using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EconomyManager;

public class UnitBuildingEconomy : MonoBehaviour
{
    [SerializeField] private List<UnitDataHolder> unitInstance;

    [SerializeField] internal float solCount;
    private float internalCounter;

    #region NUMBER_VARIABLES
    [SerializeField] internal float solPerSecond;
    [SerializeField] internal float tapsPerSecond = 1.0f;
    [SerializeField] internal float guardianTapsPerSecond;

    float elapsedTime;
    #endregion

    #region UI_VARIABLES
    [SerializeField] private TextMeshProUGUI solCountText;
    [SerializeField] private TextMeshProUGUI spsText;
    [SerializeField] private TextMeshProUGUI tpsText;
    [SerializeField] private TextMeshProUGUI gtpsText;
    #endregion

    private void Awake()
    {
        unitInstance.AddRange(GameObject.FindObjectsOfType<UnitDataHolder>());
    }

    private void Start()
    {
        for (int i = 0; i < unitInstance.Count; i++)
        {
            solPerSecond += (unitInstance[i].unit.baseSol * unitInstance[i].unit.currentOwned);
        }
    }

    private void Update()
    {
        spsText.text = solPerSecond + "/s";
        tpsText.text = tapsPerSecond.ToString();
        gtpsText.text = guardianTapsPerSecond.ToString();
        countingSystem();
    }

    private void FixedUpdate()
    {
        AutoAddScore();
    }

    void countingSystem()
    {
        //Simple counting logic, so it won't overpopulate the screen when the
        //numbers get too high
        if (solCount < 1000) //less than 1000
        {
            solCountText.text = solCount.ToString("F1");
        }
        else if (solCount >= 1000) //greater than or equal to 1000
        {
            internalCounter = solCount / 1000;
            solCountText.text = internalCounter.ToString("F2") + "K"; //(F2) rounded to 2 decimal places
        }
        else if (solCount >= 1000000) //greater than or equal to 1,000,000
        {
            internalCounter = solCount / 1000000;
            solCountText.text = internalCounter.ToString("F2") + "M";
        }
        else if (solCount >= 1000000000) //greater than or equal to 1,000,000,000
        {
            internalCounter = solCount / 1000000000;
            solCountText.text = internalCounter.ToString("F2") + "B";
        }
        else if (solCount >= 1000000000000) //greater than or equal to 1,000,000,000,000
        {
            internalCounter = solCount / 1000000000000;
            solCountText.text = internalCounter.ToString("F2") + "T";
        }
        //Might add more later
    }
    void AutoAddScore()
    {
        elapsedTime += Time.fixedDeltaTime;
        //Basically tells the condition that if the remainder is 1 or it is a whole number, then returns true
        if (elapsedTime >= 1f)
        {
            elapsedTime = elapsedTime % 0.5f;
            solCount = EconomyMain.autoAddScore(solPerSecond, solCount);
        }
    }

    public void OnClick_AddSol()
    {
        solCount += tapsPerSecond;
    }
}