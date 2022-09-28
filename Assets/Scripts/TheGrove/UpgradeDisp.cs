using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDisp : MonoBehaviour
{
    public int upNumber;
    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("GroveTracker");

        switch (upNumber)
        {
            case 1:
                if(tracker.GetComponent<GroveTracker>().upgrade1 == true)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;

            case 2:
                if (tracker.GetComponent<GroveTracker>().upgrade2 == true)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;

            case 3:
                if (tracker.GetComponent<GroveTracker>().upgrade3 == true)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;

            case 4:
                if (tracker.GetComponent<GroveTracker>().upgrade4 == true)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;

            case 5:
                if (tracker.GetComponent<GroveTracker>().upgrade5 == true)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
