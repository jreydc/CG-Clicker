using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestiegeInitialSetup : MonoBehaviour
{
    public GameObject[] unusedButtons;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < unusedButtons.Length; i++)
        {
            if (unusedButtons[i].GetComponent<PrestiegeTextBox>().bought == false)
            {
                unusedButtons[i].SetActive(false);
            }
        }
    }
}
