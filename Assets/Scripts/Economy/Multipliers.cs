using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public float autoMulti;
    public float clickMulti;
    public float toucAuto;
    public float toucClick;

    int waitTime;

    public void ToucAuto(int wait)
    {
        waitTime = wait;

        StartCoroutine("Auto");
    }

    public IEnumerator Auto()
    {
        toucAuto = 7;
        yield return new WaitForSeconds(waitTime);
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
        yield return new WaitForSeconds(waitTime);
        toucClick = 1;
    }
}
