using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucan : MonoBehaviour
{
    int moveSpeed = 25;
    public float bonusSol;
    [SerializeField] private UnitBuildingEconomy economy;
    [SerializeField] SpawnClickText spawnText;
    [SerializeField]PlaySound sound;
    [SerializeField] Multipliers multi;

    int bonusTime;

    private void Awake()
    {
        economy = FindObjectOfType<UnitBuildingEconomy>();
        sound = FindObjectOfType<PlaySound>();
        spawnText = FindObjectOfType<SpawnClickText>();
        multi = FindObjectOfType<Multipliers>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bonusSol = Random.Range(economy.solCount * 0.25f, economy.solCount * 0.5f);
        Invoke("Die", 55);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void OnClick()
    {
        int chooser = Random.Range(1, 4);

        switch (chooser)
        {
            case 1:
                economy.BonusSol(bonusSol);
                sound.Sqwack();
                spawnText.ToucSpawn(chooser, bonusTime);
                break;

            case 2:
                bonusTime = Random.Range(30, 61);
                print(bonusTime);
                multi.ToucAuto(bonusTime);
                sound.Sqwack();
                spawnText.ToucSpawn(chooser, bonusTime);
                break;

            case 3:
                bonusTime = Random.Range(30, 61);
                print(bonusTime);
                multi.ToucClick(bonusTime);
                sound.Sqwack();
                spawnText.ToucSpawn(chooser, bonusTime);
                break;
        }
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
