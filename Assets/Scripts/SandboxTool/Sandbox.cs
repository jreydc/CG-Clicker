using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox : MonoBehaviour
{
    private void Start()
    {
        float M = 25f;
        float F = 0f;
        float BM = 1.15f;
        float BC = 15;

        //Price Multiplier
        Debug.Log(Mathf.Round(BC *(Mathf.Pow(BM, (M-F)))));
    }
}