using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickText : MonoBehaviour
{
    public TextMeshProUGUI self;
    private UnitBuildingEconomy unit;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("ScoreText").transform);

        //unit = GameObject.Find("Game Manager").GetComponent<UnitBuildingEconomy>();

        //self.text = "+" + unit.tapsPerSecond.ToString() + " Sol";

        Invoke("Die", 1f);
    }

    private void Die()
    {
        Destroy(gameObject); 
    }
}
