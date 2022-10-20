using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    public bool[] achievements;

    public AchievementDataHandler achievementData;
    public float sapCount;

    void Awake()
    {
        achievementData = GetComponent<AchievementDataHandler>();
    }

    public void Unlock(int achID)
    {
        if (achievements[achID] != true)
        {
            achievements[achID] = true;
            sapCount += 0.04f;
            achievementData.SaveData();
        }
    }
}
