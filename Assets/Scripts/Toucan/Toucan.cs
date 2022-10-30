using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucan : MonoBehaviour
{
    int moveSpeed = 25;
    UnitBuildingEconomy unitBuilding;
    [SerializeField] private UnitBuildingEconomy economy;
    PlaySound sound;

    private void Awake()
    {
        unitBuilding = FindObjectOfType<UnitBuildingEconomy>();
        sound = FindObjectOfType<PlaySound>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 55);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void OnClick()
    {
        float bonusSol = Random.Range(unitBuilding.solCount * 0.25f, unitBuilding.solCount * 0.5f);
        economy.BonusSol(bonusSol);
        sound.Buy();
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
