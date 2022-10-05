using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EconomyManager
{
    public class EconomyMain : MonoBehaviour
    {
        //Add Scores to your iterator
        internal static float addScore(float points, float current)
        {
            current += points;
            return current;
        }

        //Automatic farming of points
        internal static float autoAddScore(float points, float current)
        {
            current += points;
            return current;
        }

        //For Purchasing Upgrades/Deductions
        internal static float deductScore(float points, float current)
        {
            current -= points;
            return current;
        }
    }
}