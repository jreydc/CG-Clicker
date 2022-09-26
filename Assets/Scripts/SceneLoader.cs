using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private DataHandler dataHandler;

    private void Awake()
    {
        dataHandler = FindObjectOfType<DataHandler>();
    }

    public void Prestiege()
    {
        SceneManager.LoadScene("Prestiege");
        dataHandler.SaveData();
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Main");
        dataHandler.SaveData();
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        dataHandler.SaveData();
    }

    public void Social()
    {
        SceneManager.LoadScene("Social");
        dataHandler.SaveData();
    }

    public void Grove()
    {
        SceneManager.LoadScene("TheGrove");
        dataHandler.SaveData();
    }
}
