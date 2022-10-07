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
    public Image glow;

    PrestigeManager manager;
    [SerializeField]PrestigeDataHandler data;
    [SerializeField] PrestigeSaveLoad save;

    public int ID, cost;

    public bool bought;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);

        manager = GameObject.Find("PrestigeHandler").GetComponent<PrestigeManager>();
        data = GameObject.Find("PrestigeHandler").GetComponent<PrestigeDataHandler>();
        save = GameObject.Find("Data").GetComponent<PrestigeSaveLoad>();

        if (data.checkers[ID] != true)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Update()
    {
        if(manager.presPoint >= cost && !bought)
        {
            buyButton.interactable = true;
            glow.enabled = true;
        }
        else
        {
            buyButton.interactable = false;
            glow.enabled = false;
        }
    }

    public void OpenTextBox()
    {
        textbox.SetActive(true);
    }

    public void CloseTextBox()
    {
        textbox.SetActive(false);
    }

    void Show()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(true);
        }

        bought = true;

        buyButton.interactable = false;
        button.interactable = false;
    }

    void Hide()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(false);
        }

        bought = false;
    }

    public void BuyUpgrade()
    {
        CloseTextBox();
        Show();
        bought = true;

        manager.BuyPrestige(ID, cost);
        data.checkers[ID] = true;
        save.SaveData();
    }
}
