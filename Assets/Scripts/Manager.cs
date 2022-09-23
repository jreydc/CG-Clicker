using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    //Actual number to be displayed
    int Score;
    public TextMeshProUGUI scoreText;

    //Number added to score per click
    int scoreToAdd;
    public TextMeshProUGUI scoreToAddText;

    //Number added per second
    int autoScoreToAdd;
    public TextMeshProUGUI autoScoreToAddText;

    //Price for the upgrades and their displays
    int clickUpgradePrice;
    int autoUpgradePrice;
    public TextMeshProUGUI clickUpgradeText;
    public TextMeshProUGUI autoUpgradeText;

    //upgrade buttons
    public Button clickUpgradeButton;
    public Button autoUpgradeButton;

    //particles for playert feedback
    public GameObject particle;

    private void Start()
    {
        scoreToAdd = 1;
        autoScoreToAdd = 0;

        clickUpgradePrice = 15;
        autoUpgradePrice = 15;

        InvokeRepeating("AddAutoScore", 1f, 1f);
    }

    void Update()
    {
        scoreText.text = Score.ToString();
        clickUpgradeText.text = "Cost: " + clickUpgradePrice.ToString();
        autoUpgradeText.text = "Cost: " + autoUpgradePrice.ToString();
        scoreToAddText.text = scoreToAdd.ToString() + " Per Click";
        autoScoreToAddText.text = autoScoreToAdd.ToString() + " Per Second";

        if (Score >= clickUpgradePrice)
        {
            clickUpgradeButton.interactable = true;
        }
        else
        {
            clickUpgradeButton.interactable = false;
        }

        if (Score >= autoUpgradePrice)
        {
            autoUpgradeButton.interactable = true;
        }
        else
        {
            autoUpgradeButton.interactable = false;
        }
    }

    public void AddScore()
    {
        Score += scoreToAdd;
        Instantiate(particle, transform.position, transform.rotation);
    }

    void AddAutoScore()
    {
        Score += autoScoreToAdd;
    }

    public void BuyClick()
    {
        //Uses the score to purchase the upgrade, then makes the next one more expensive
        scoreToAdd++;
        Score -= clickUpgradePrice;
        clickUpgradePrice = Mathf.RoundToInt(clickUpgradePrice * 1.5f);
    }

    public void BuyAutoClick()
    {
        autoScoreToAdd++;
        Score -= autoUpgradePrice;
        autoUpgradePrice = Mathf.RoundToInt(autoUpgradePrice * 1.3f);
    }
}
