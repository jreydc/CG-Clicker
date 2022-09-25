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
}
