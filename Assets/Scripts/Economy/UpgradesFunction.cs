using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EconomyManager;

public class UpgradesFunction : MonoBehaviour
{
    private PointsFunction pfMain;

    private void Awake()
    {
        pfMain = FindObjectOfType<PointsFunction>();
    }

    //Should the cost be modular or hardcoded(?)
    #region UPGRADES
    public void AddUpgrade1()
    {
        if(pfMain._score >= 15)
        {
            pfMain._score = EconomyMain.deductScore(15, pfMain._score);
            pfMain._scoreToAdd += 1;
        }
    }

    public void AddUpgrade2()
    {
        if (pfMain._score >= 50)
        {
            pfMain._score = EconomyMain.deductScore(50, pfMain._score);
            pfMain._passiveScore += 1;
        }
    }

    public void AddUpgrade3()
    {
        if (pfMain._score >= 60)
        {
            pfMain._score = EconomyMain.deductScore(60, pfMain._score);
            pfMain._passiveScore += 2;
        }
    }

    public void AddUpgrade4()
    {
        if (pfMain._score >= 65)
        {
            pfMain._score = EconomyMain.deductScore(65, pfMain._score);
            pfMain._passiveScore += 5;
        }
    }
    #endregion
}