using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeBar : MonoBehaviour
{
    [SerializeField]private Slider slider;
    [SerializeField]private PrestigeManager prestigeManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        prestigeManager = GameObject.Find("PrestigeHandler").GetComponent<PrestigeManager>();
    }

    private void Update()
    {
        slider.maxValue = prestigeManager.cost;
        slider.value = prestigeManager.tracker;
    }
}
