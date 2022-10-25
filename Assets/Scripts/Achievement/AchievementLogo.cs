using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementLogo : MonoBehaviour
{
    public int ID;
    public Sprite locked, unlocked;
    [SerializeField]Image logo;
    [SerializeField]AchievementTracker achievementTracker;

    // Start is called before the first frame update
    void Awake()
    {
        achievementTracker = FindObjectOfType<AchievementTracker>();
        logo = GetComponent<Image>();
    }

    private void Update()
    {
        if (achievementTracker.achievements[ID] != true)
        {
            logo.sprite = locked;
        }
        else
        {
            logo.sprite = unlocked;
        }
    }
}
