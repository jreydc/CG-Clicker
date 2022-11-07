using EconomyManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PrestigeMain : MonoBehaviour
{
    [SerializeField] private Button prestigeButton;
    [SerializeField] private Slider prestigeTracker;
    [SerializeField] private TextMeshProUGUI prestigeAmountText;

    [SerializeField] private List<PrestigeData> prestigeData;

    [SerializeField] internal float prestigePoints;

    float elapsedTime;
    UnitBuildingEconomy ecoMain;

    Scene currentScene;

    public delegate void checkRequirements(float currentPrestigePts);
    public static event checkRequirements CheckRequirements;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey("prestigePoints"))
        {
            prestigePoints = PlayerPrefs.GetFloat("prestigePoints");
        }
    }

    private void Start()
    {
        if (currentScene.name == "Main")
            ecoMain = FindObjectOfType<UnitBuildingEconomy>();
        else if (currentScene.name == "Pretiege")
            prestigeAmountText = GameObject.Find("PrestigePoints").GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        prestigePoints = (float)CalculatePrestigePoints();
        if (currentScene.name == "Main")
        {
            elapsedTime += Time.fixedDeltaTime;
            //Basically tells the condition that if the remainder is 1 or it is a whole number, then returns true
            if (elapsedTime >= 1f)
            {
                elapsedTime = elapsedTime % 0.5f;
                prestigeTracker.value = (float)CalculatePrestigePoints();

                if (CalculatePrestigePoints() > 0)
                {
                    prestigeButton.interactable = true;
                }

                prestigeAmountText.text = "Prestige Points: " + CalculatePrestigePoints().ToString();
            }
        }
        else
        {
            prestigeAmountText.text = "Prestige Points: " + CalculatePrestigePoints().ToString();
            CheckRequirements(prestigePoints);
        }
    }

    private double CalculatePrestigePoints()
    {
        print(Math.Floor(Math.Pow((ecoMain.solCount / (Math.Pow(10, 12))), (1 % 3))));
        return Math.Floor(Math.Pow((ecoMain.solCount / (Math.Pow(10, 12))), (1 % 3)));
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("prestigePoints", prestigePoints);
        PlayerPrefs.Save();
    }
}