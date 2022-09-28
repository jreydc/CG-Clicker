using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroveTracker : MonoBehaviour
{
    public bool upgrade1, upgrade2, upgrade3, upgrade4, upgrade5;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
