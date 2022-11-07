using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigeOfflineCollect : MonoBehaviour
{
    DateTime currentTime;
    DateTime storedTime;


    private void Awake()
    {
        currentTime = DateTime.Now;

        if (PlayerPrefs.HasKey("timeSave"))
        {
            string timeAsString = PlayerPrefs.GetString("timeSave");
            storedTime = DateTime.Parse(timeAsString);

            TimeSpan timePassed = currentTime - storedTime;

            print("Current Time: " + currentTime.ToString());
            print("Stored Time: " + storedTime.ToString());
            if(timePassed.TotalSeconds < 60)
            {
                print("Total time between: " + timePassed.TotalSeconds.ToString("F1") + " seconds.");
            }
            else if (timePassed.TotalSeconds >= 60)
            {
                print("Total time between: " + timePassed.TotalMinutes.ToString("F1") + " minutes.");
            }
            else if(timePassed.TotalMinutes >= 60)
            {
                print("Total time between: " + timePassed.TotalHours.ToString("F1") + " hours.");
            }
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("timeSave", DateTime.Now.ToString());
    }
}