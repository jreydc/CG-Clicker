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
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;

            case 2:
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;

            case 3:
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;

            case 4:
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;

            case 5:
                autoMulti += 0.025f;
                clickMulti += 0.025f;
                break;

            case 6:
                clickMulti += 0.05f;
                break;

            case 7:
                clickMulti += 0.05f;
                break;

            case 8:
                clickMulti += 0.05f;
                break;

            case 9:
                clickMulti += 0.05f;
                break;

            case 10:
                autoMulti += 0.05f;
                break;

            case 11:
                autoMulti += 0.05f;
                break;

            case 12:
                autoMulti += 0.05f;
                break;

            case 13:
                autoMulti += 0.05f;
                break;

            case 14:
                print("hi!!");
                break;

            case 15:
                print("hi!!");
                break;

            case 16:
                print("hi!!");
                break;

            case 17:
                print("hi!!");
                break;
        }

        if (presPoint >= cost)
        {
            presPoint -= cost;
        }
    }
}
