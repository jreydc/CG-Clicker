using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySellButtons : MonoBehaviour
{
    public Button self, button1, button2;

    public void Awake()
    {
        if(gameObject.tag == "Buy" || gameObject.tag == "One")
        {
            self.GetComponent<Image>().color = Color.red;
        }
    }

    public void ChangeColour()
    {
        self.GetComponent<Image>().color = Color.red;
        button1.GetComponent<Image>().color = Color.white;
        button2.GetComponent<Image>().color = Color.white;
    }
}
