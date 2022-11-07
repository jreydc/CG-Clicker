using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private DataHandler dataHandler;
    [SerializeField] private PrestigeSaveLoad prestigeData;
    public GameObject social, shop;

    private void Awake()
    {
        dataHandler = FindObjectOfType<DataHandler>();
        prestigeData = FindObjectOfType<PrestigeSaveLoad>();

        //social.SetActive(false);
        shop.SetActive(false);
    }

    public void Prestiege()
    {
        SceneManager.LoadScene("Prestiege");
        dataHandler.SaveData();
        prestigeData.SaveData();
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Main");
        //dataHandler.SaveData();
    }

    public void Shop()
    {
        shop.SetActive(true);
        dataHandler.SaveData();
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void Social()
    {
        social.SetActive(true);
        dataHandler.SaveData();
    }

    public void CloseSocial()
    {
        social.SetActive(false);
    }

    public void Grove()
    {
        SceneManager.LoadScene("TheGrove");
        dataHandler.SaveData();
    }
}
