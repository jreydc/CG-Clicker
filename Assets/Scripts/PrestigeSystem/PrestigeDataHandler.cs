using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrestigeDataHandler : MonoBehaviour
{
    [SerializeField] internal PrestigeData data;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI d_name;
    [SerializeField] private TextMeshProUGUI cost;

    private void Start()
    {
        description.text = data.Description[data.level];
        d_name.text = data.name;
        cost.text = "Cost: " + data.cost.ToString();
    }
}