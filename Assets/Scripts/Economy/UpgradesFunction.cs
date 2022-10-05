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
            pfMain._score = EconomyMain.deductScore(15, (float)pfMain._score);
            pfMain._scoreToAdd += 1;
        }
    }

    public void AddUpgrade2()
    {
        if (pfMain._score >= 50)
        {
            pfMain._score = EconomyMain.deductScore(50, (float)pfMain._score);
            pfMain._passiveScore += 1;
        }
    }

    public void AddUpgrade3()
    {
        if (pfMain._score >= 60)
        {
            pfMain._score = EconomyMain.deductScore(60, (float)pfMain._score);
            pfMain._passiveScore += 2;
        }
    }

    public void AddUpgrade4()
    {
        if (pfMain._score >= 65)
        {
            pfMain._score = EconomyMain.deductScore(65, (float)pfMain._score);
            pfMain._passiveScore += 5;
        }
    }

    public void AddUpgrade5()
    {
        if (pfMain._score >= 100)
        {
            pfMain._score = EconomyMain.deductScore(100, (float)pfMain._score);
            pfMain._passiveScore += 10;
        }
    }

    public void AddUpgrade6()
    {
        if (pfMain._score >= 120)
        {
            pfMain._score = EconomyMain.deductScore(120, (float)pfMain._score);
            pfMain._passiveScore += 20;
        }
    }

    public void AddUpgrade7()
    {
        if (pfMain._score >= 150)
        {
            pfMain._score = EconomyMain.deductScore(150, (float)pfMain._score);
            pfMain._passiveScore += 30;
        }
    }

    public void AddUpgrade8()
    {
        if (pfMain._score >= 200)
        {
            pfMain._score = EconomyMain.deductScore(200, (float)pfMain._score);
            pfMain._passiveScore += 50;
        }
    }

    public void AddUpgrade9()
    {
        if (pfMain._score >= 1000)
        {
            pfMain._score = EconomyMain.deductScore(1000, (float)pfMain._score);
            pfMain._passiveScore += 100;
        }
    }
    #endregion
}