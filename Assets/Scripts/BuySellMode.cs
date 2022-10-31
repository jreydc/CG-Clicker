using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySellMode : MonoBehaviour
{
    public bool buy;
    public int amount;

    public UnitDataHolder[] unitDatas;

    public void Awake()
    {
        buy = true;
        amount = 1;
    }

    private void Update()
    {
        unitDatas = FindObjectsOfType<UnitDataHolder>();
    }

    public void Buy()
    {
        buy = true;
    }

    public void Sell()
    {
        buy = false;
    }

    public void One()
    {
        amount = 1;
    }

    public void Ten()
    {
        amount = 10;
    }

    public void Hundred()
    {
        amount = 100;
    }
}
