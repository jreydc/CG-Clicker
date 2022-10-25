using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PrestigeManager : MonoBehaviour
{
    public float cost, tracker;
    public int presPoint, totalPoints;
    public Button presButton;

    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private Multipliers multiplier;

    void Awake()
    {
        cost = nextCostCalc(totalPoints);
    }

    public void AddPoint(float points)
    {
        tracker += points;
    }

    public void AutoAddPoint(float points)
    {
        tracker += points;
    }

    void Update()
    {
        if (tracker >= cost)
        {
            presPoint++;
            totalPoints++;
            tracker = 0;
            cost = nextCostCalc(totalPoints);
        }

        if(pointText == null)
        {
            pointText = GameObject.Find("PrestigePoints").GetComponent<TextMeshProUGUI>();
        }

        if(multiplier == null)
        {
            multiplier = FindObjectOfType<Multipliers>();
        }

        if(presButton == null)
        {
            presButton = GameObject.Find("PrestigeButton").GetComponent<Button>();
        }

        pointText.text = "Cycle Points: " + presPoint;
    }

    public void BuyPrestige(int ID, int cost)
    {
        switch (ID)
        {
            case 1:
                multiplier.autoMulti += 0.025f;
                multiplier.clickMulti += 0.025f;
                break;

            case 2:
                multiplier.autoMulti += 0.025f;
                multiplier.clickMulti += 0.025f;
                break;

            case 3:
                multiplier.autoMulti += 0.025f;
                multiplier.clickMulti += 0.025f;
                break;

            case 4:
                multiplier.autoMulti += 0.025f;
                multiplier.clickMulti += 0.025f;
                break;

            case 5:
                multiplier.autoMulti += 0.025f;
                multiplier.clickMulti += 0.025f;
                break;

            case 6:
                multiplier.clickMulti += 0.05f;
                break;

            case 7:
                multiplier.clickMulti += 0.05f;
                break;

            case 8:
                multiplier.clickMulti += 0.05f;
                break;

            case 9:
                multiplier.autoMulti += 0.05f;
                break;

            case 10:
                multiplier.autoMulti += 0.05f;
                break;

            case 11:
                multiplier.autoMulti += 0.05f;
                break;

            case 12:
                multiplier.autoMulti += 0.05f;
                break;

            case 13:
                multiplier.autoMulti += 0.05f;
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

    //K is the number of points previously earned
    private float nextCostCalc(int K)
    {
        float price = (Mathf.Pow(10, 12)) * (Mathf.Pow((K + 1), 3) - (Mathf.Pow(K, 3)));
        return price;
    }
}
