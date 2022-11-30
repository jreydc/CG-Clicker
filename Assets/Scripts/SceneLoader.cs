using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private DataHandler dataHandler;
    [SerializeField] private PrestigeSaveLoad prestigeData;
    public GameObject social, shop, settings;

    private void Awake()
    {
        dataHandler = FindObjectOfType<DataHandler>();
        prestigeData = FindObjectOfType<PrestigeSaveLoad>();

        //social.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
        social.SetActive(false);
    }

    public void Prestiege()
    {
        SceneManager.LoadScene("Prestiege");
        dataHandler.WriteToJson();
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
        dataHandler.WriteToJson();
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void Social()
    {
        social.SetActive(true);
        dataHandler.WriteToJson();
    }

    public void CloseSocial()
    {
        social.SetActive(false);
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void Grove()
    {
        SceneManager.LoadScene("TheGrove");
        dataHandler.WriteToJson();
    }
}
