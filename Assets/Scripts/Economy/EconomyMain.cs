using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EconomyManager
{
    public class EconomyMain : MonoBehaviour
    {
        //Add Scores to your iterator
        internal static double addScore(int points, double current)
        {
            current += points;
            return current;
        }

        //Automatic farming of points
        internal static double autoAddScore(int points, double current)
        {
            current += points;
            return current;
        }

        //For Purchasing Upgrades/Deductions
        internal static double deductScore(int points, double current)
        {
            current -= points;
            return current;
        }
    }
}