using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EconomyManager;
using TMPro;

public class PointsFunction : MonoBehaviour
{
    [SerializeField] internal int _score; //Must be accessed within the assembly
    [SerializeField] internal int _scoreToAdd = 1;
    [SerializeField] internal int _passiveScore; //Will be used for upgrades

    //UI
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI TPSTxt;
    [SerializeField] private TextMeshProUGUI SPSTxt;

    [SerializeField] private GameObject particleEffect;


    float elapsedTime;

    //Used on the button, will add score and can even be used on other functions
    public void OnClick_AddScore()
    {
        _score = EconomyMain.addScore(_scoreToAdd, _score);
        Instantiate(particleEffect);
    }

    //Using FixedUpdate so the addition of score will not fluctuate like crazy
    private void FixedUpdate()
    {
        scoreTxt.text = "" + _score;
        TPSTxt.text = "" + _scoreToAdd;
        SPSTxt.text = _passiveScore + " / s";

        AutoAddScore();
    }

    //Limits to adding score every (1) second
    private void AutoAddScore()
    {
        elapsedTime += Time.deltaTime;
        //Basically tells the condition that if the remainder is 1 or it is a whole number, then returns true
        if(elapsedTime >= 1f)
        {
            elapsedTime = elapsedTime % 0.5f;
            _score = EconomyMain.autoAddScore(_passiveScore, _score);
        }
    }
}