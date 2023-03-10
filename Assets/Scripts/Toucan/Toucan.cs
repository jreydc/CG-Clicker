using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toucan : MonoBehaviour
{
    int moveSpeed = 25;
    public float bonusSol;
    [SerializeField] private UnitBuildingEconomy economy;
    [SerializeField] SpawnClickText spawnText;
    [SerializeField]PlaySound sound;
    [SerializeField] Multipliers multi;
    [SerializeField] GameObject textBox;
    [SerializeField] AdManager adManager;

    bool fly;
    Animator anim;

    int bonusTime, chooser;

    private void Awake()
    {
        economy = FindObjectOfType<UnitBuildingEconomy>();
        sound = FindObjectOfType<PlaySound>();
        spawnText = FindObjectOfType<SpawnClickText>();
        multi = FindObjectOfType<Multipliers>();
        textBox = GameObject.Find("ToucTextBox");
        adManager = FindObjectOfType<AdManager>();

        chooser = Random.Range(1, 4);
        bonusTime = Random.Range(15, 25);

        anim = GetComponent<Animator>();
        fly = false;
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
        if (!fly)
        {
            transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * moveSpeed * 3f * Time.deltaTime);
        }
    }

    public void OnClick()
    {
        textBox.SetActive(true);
        adManager.WatchAd(chooser, bonusTime, bonusSol);
        sound.Sqwack();
    }

    public void GiveBonus()
    {
        switch (chooser)
        {
            case 1:
                economy.BonusSol(bonusSol);
                spawnText.ToucSpawn(chooser, bonusTime);
                break;

            case 2:
                print(bonusTime);
                multi.ToucAuto(bonusTime);
                spawnText.ToucSpawn(chooser, bonusTime);
                break;

            case 3:
                print(bonusTime);
                multi.ToucClick(bonusTime);
                spawnText.ToucSpawn(chooser, bonusTime);
                break;
        }
        gameObject.GetComponent<Button>().interactable = false;
        fly = true;
        anim.Play("toucan_front_frame");
        Invoke("Die", 15f);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
