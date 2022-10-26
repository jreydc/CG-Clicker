using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySellMode : MonoBehaviour
{
    public bool buy;

    public void Awake()
    {
        buy = true;
    }

    public void Buy()
    {
        buy = true;
    }

    public void Sell()
    {
        buy = false;
    }
}
