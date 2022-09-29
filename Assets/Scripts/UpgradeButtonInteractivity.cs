using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonInteractivity : MonoBehaviour
{
    public int arrayPos;
    GameObject manager;
    Button self;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager");
        self = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.GetComponent<NewUpgradesFunction>().currentUpgradeCost[arrayPos] > manager.GetComponent<PointsFunction>()._score)
        {
            self.interactable = false;
        }
        else
        {
            self.interactable = true;
        }
    }
}
