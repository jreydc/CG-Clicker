using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestiegeTextBox : MonoBehaviour
{
    public GameObject textbox;
    public GameObject[] nextUpgrades;
    public GameObject[] lines;
    public Button button, buyButton;

    PrestigeManager manager;

    public int ID, cost;

    public bool bought;

    // Start is called before the first frame update
    void Start()
    {
        bought = false;
        textbox.SetActive(false);

        manager = GameObject.Find("PrestigeHandler").GetComponent<PrestigeManager>();
    }

    private void Update()
    {
        if(manager.presPoint >= cost && !bought)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
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
        buyButton.interactable = false;
        button.interactable = false;
        bought = true;
        

        for (int i = 0; i < nextUpgrades.Length; i++)
         {
             nextUpgrades[i].SetActive(true);
         }

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(true);
        }

        manager.BuyPrestige(ID, cost);
    }
}
