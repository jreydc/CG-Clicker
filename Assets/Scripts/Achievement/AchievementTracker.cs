using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    public bool[] achievements;

    public AchievementDataHandler achievementData;
    [SerializeField] private Multipliers multipliers;

    void Awake()
    {
        multipliers = FindObjectOfType<Multipliers>();
        achievementData = GetComponent<AchievementDataHandler>();
    }

    public void Unlock(int achID)
    {
        if (achievements[achID] != true)
        {
            achievements[achID] = true;
            multipliers.autoMulti += 0.04f;
            multipliers.clickMulti += 0.04f;
            achievementData.SaveData();
        }
    }
}
