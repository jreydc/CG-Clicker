using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public float autoMulti;
    public float clickMulti;
    public float toucAuto;
    public float toucClick;

    [SerializeField] ShineSpin shineSpin;

    int waitTime;

    private void Awake()
    {
        shineSpin = FindObjectOfType<ShineSpin>();
    }

    public void ToucAuto(int wait)
    {
        waitTime = wait;

        StartCoroutine("Auto");
    }

    public IEnumerator Auto()
    {
        toucAuto = 7;
        shineSpin.On();
        yield return new WaitForSeconds(waitTime);
        shineSpin.Off();
        toucAuto = 1;
    }

    public void ToucClick(int wait)
    {
        waitTime = wait;

        StartCoroutine("Click");
    }

    public IEnumerator Click()
    {
        toucClick = 7;
        shineSpin.On();
        yield return new WaitForSeconds(waitTime);
        shineSpin.Off();
        toucClick = 1;
    }
}
