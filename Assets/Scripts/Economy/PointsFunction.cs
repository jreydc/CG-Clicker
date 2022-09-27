using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EconomyManager;
using TMPro;

public class PointsFunction : MonoBehaviour
{
    private double internalCounter;
    [SerializeField] internal double _score; //Must be accessed within the assembly
    [SerializeField] internal int _scoreToAdd = 1;
    [SerializeField] internal int _passiveScore; //Will be used for upgrades

    //UI
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI TPSTxt;
    [SerializeField] private TextMeshProUGUI SPSTxt;

    [SerializeField] private GameObject particleEffect;


    bool isHolding = false;
    float elapsedHoldingTime;
    float elapsedTime;

    //Used on the button, will add score and can even be used on other functions
    public void OnClick_AddScore()
    {
        _score = EconomyMain.addScore(_scoreToAdd, _score);
        Instantiate(particleEffect, transform.position, transform.rotation);
    }

    public void OnClick_HoldAddScore()
    {
        isHolding = true;
    }
    public void OnRelease_Hold()
    {
        isHolding = false;
    }

    //Using FixedUpdate so the addition of score will not fluctuate like crazy
    private void FixedUpdate()
    {
        countingSystem();
        TPSTxt.text = "" + _scoreToAdd;
        SPSTxt.text = _passiveScore + " / s";

        AutoAddScore();
        HoldClickButton();
    }

    void HoldClickButton()
    {
        //Still needs fixing
        if (isHolding)
        {
            elapsedHoldingTime += Time.fixedDeltaTime;
            if (elapsedHoldingTime >= 1f)
            {
                elapsedHoldingTime = elapsedTime % 1f;
                _score = EconomyMain.addScore(_scoreToAdd, _score);
            }
        }
    }

    void countingSystem()
    {
        //Simple counting logic, so it won't overpopulate the screen when the
        //numbers get too high
        if(_score < 1000) //less than 1000
        {
            scoreTxt.text = _score.ToString();
        }
        else if(_score >= 1000) //greater than or equal to 1000
        {
            internalCounter = _score / 1000;
            scoreTxt.text = internalCounter.ToString("F2") + "K"; //(F2) rounded to 2 decimal places
        }
        else if(_score >= 1000000) //greater than or equal to 1,000,000
        {
            internalCounter = _score / 1000000;
            scoreTxt.text = internalCounter.ToString("F2") + "M";
        }
        else if(_score >= 1000000000) //greater than or equal to 1,000,000,000
        {
            internalCounter = _score / 1000000000;
            scoreTxt.text = internalCounter.ToString("F2") + "B";
        }
        else if(_score >= 1000000000000) //greater than or equal to 1,000,000,000,000
        {
            internalCounter = _score / 1000000000000;
            scoreTxt.text = internalCounter.ToString("F2") + "T";
        }
        //Might add more later
    }

    //Limits to adding score every half a second
    private void AutoAddScore()
    {
        elapsedTime += Time.fixedDeltaTime;
        //Basically tells the condition that if the remainder is 1 or it is a whole number, then returns true
        if(elapsedTime >= 1f)
        {
            elapsedTime = elapsedTime % 0.5f;
            _score = EconomyMain.autoAddScore(_passiveScore, _score);
        }
    }
}