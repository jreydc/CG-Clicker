using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Prestiege()
    {
        SceneManager.LoadScene("Prestiege");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Main");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Social()
    {
        SceneManager.LoadScene("Social");
    }

    public void Grove()
    {
        SceneManager.LoadScene("TheGrove");
    }
}
