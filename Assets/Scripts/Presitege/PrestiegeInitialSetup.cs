using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrestiegeInitialSetup : MonoBehaviour
{
    public GameObject[] unusedButtons;
    public GameObject[] lines;

    PrestigeManager manager;

    [SerializeField] TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("PrestigeHandler").GetComponent<PrestigeManager>();

        for (int i = 0; i < unusedButtons.Length; i++)
        {
            if (unusedButtons[i].GetComponent<PrestiegeTextBox>().bought == false)
            {
                unusedButtons[i].SetActive(false);
            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
           lines[i].SetActive(false);
        }
    }

    private void Update()
    {
        points.text = "Points Left: " + manager.presPoint;
    }
}
