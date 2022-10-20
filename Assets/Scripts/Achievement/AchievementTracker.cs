using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    public bool[] achievements;

    public AchievementDataHandler achievementData;

    void Awake()
    {
        achievementData = GetComponent<AchievementDataHandler>();
    }

    public void Unlock(int achID)
    {
        achievements[achID] = true;
        achievementData.SaveData();
    }
}
