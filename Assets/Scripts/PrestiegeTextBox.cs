using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestiegeTextBox : MonoBehaviour
{
    public GameObject textbox;
    public GameObject[] nextUpgrades;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);

        for (int i = 0; i < nextUpgrades.Length; i++)
        {
            nextUpgrades[i].SetActive(false);
        }
    }

    // Update is called once per frame
    public void OpenTextBox()
    {
        textbox.SetActive(true);
    }

    public void CloseTextBox()
    {
        textbox.SetActive(false);
    }

    public void BuyUpgrade()
    {
        CloseTextBox();
        button.interactable = false;
        for (int i = 0; i < nextUpgrades.Length; i++)
         {
             nextUpgrades[i].SetActive(true);
         }
       
    }
}
