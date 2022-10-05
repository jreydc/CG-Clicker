using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrestigeManager : MonoBehaviour
{
    [SerializeField]private int tracker;
    public int presPoint;
    public float clickMulti = 1;
    public float autoMulti = 1;

    private static PrestigeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPoint(int points)
    {
        tracker += points;
    }

    public void AutoAddPoint(int points)
    {
        tracker += points;
    }

    void Update()
    {
        if(tracker >= 1000000)
        {
            presPoint++;
            tracker = 0;
        }
    }

    public void BuyPrestige(int ID, int cost)
    {
        switch (ID)
        {
            case 1:
                clickMulti += 0.05f;
                break;

            case 2:
                autoMulti += 0.05f;
                break;

            case 3:
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;
        }

        if (presPoint >= cost)
        {
            presPoint -= cost;
        }
    }
}
