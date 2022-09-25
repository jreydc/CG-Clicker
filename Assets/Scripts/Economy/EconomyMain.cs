using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EconomyManager
{
    public class EconomyMain : MonoBehaviour
    {
        //Add Scores to your iterator
        internal static int addScore(int points, int current)
        {
            current += points;
            return current;
        }

        //Automatic farming of points
        internal static int autoAddScore(int points, int current)
        {
            current += points;
            return current;
        }

        //For Purchasing Upgrades/Deductions
        internal static int deductScore(int points, int current)
        {
            current -= points;
            return current;
        }
    }
}