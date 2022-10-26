using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EconomyManager;

public class UnitBuildingEconomy : MonoBehaviour
{
    [SerializeField] internal List<UnitDataHolder> unitInstance;

    [SerializeField] internal float solCount;
    private float internalCounter;

    [SerializeField] private Animator solCountAnim;

    [SerializeField] private PrestigeManager prestigeManager;
    [SerializeField] private Multipliers multipliers;

    #region NUMBER_VARIABLES
    [SerializeField] internal float solPerSecond;
    [SerializeField] internal float tapsPerSecond = 1.0f;
    [SerializeField] internal float guardianTapsPerSecond;

    float elapsedTime;
    #endregion

    #region UI_VARIABLES
    [SerializeField] private TextMeshProUGUI solCountText;
    [SerializeField] private TextMeshProUGUI spsText;
    //[SerializeField] private TextMeshProUGUI tpsText;
    [SerializeField] private TextMeshProUGUI gtpsText;
    #endregion

    public GameObject particle;

    public delegate void buildingCounter(float currentSol);
    public static event buildingCounter buildingCounterInterval;

    public delegate void initialSpawn(float currentSol);
    public static event initialSpawn initSpawn;

    private void Awake()
    {
        solCountAnim = solCountText.GetComponent<Animator>();

        prestigeManager = GameObject.Find("PrestigeHandler").GetComponent<PrestigeManager>();
        multipliers = FindObjectOfType<Multipliers>();

        BuildingsLogic.spawnBuilding += SpawnBuilding;
    }

    private void Start()
    {
        for (int i = 0; i < unitInstance.Count; i++)
        {
            solPerSecond += (unitInstance[i].unit.baseSol * unitInstance[i].unit.currentOwned);
        }
        initSpawn(solCount);
    }

    private void Update()
    {
        spsText.text = solPerSecond.ToString("F1") + "/s";
        //tpsText.text = tapsPerSecond.ToString();
        //gtpsText.text = guardianTapsPerSecond.ToString();
        countingSystem();
    }

    private void FixedUpdate()
    {
        AutoAddScore();
    }

    void countingSystem()
    {
        //Simple counting logic, so it won't overpopulate the screen when the
        //numbers get too high
        if (solCount < 1000) //less than 1000
        {
            solCountText.text = solCount.ToString("F1");
        }
        else if (solCount >= 1000) //greater than or equal to 1000
        {
            internalCounter = solCount / 1000;
            solCountText.text = internalCounter.ToString("F2") + "K"; //(F2) rounded to 2 decimal places
        }
        else if (solCount >= 1000000) //greater than or equal to 1,000,000
        {
            internalCounter = solCount / 1000000;
            solCountText.text = internalCounter.ToString("F2") + "M";
        }
        else if (solCount >= 1000000000) //greater than or equal to 1,000,000,000
        {
            internalCounter = solCount / 1000000000;
            solCountText.text = internalCounter.ToString("F2") + "B";
        }
        else if (solCount >= 1000000000000) //greater than or equal to 1,000,000,000,000
        {
            internalCounter = solCount / 1000000000000;
            solCountText.text = internalCounter.ToString("F2") + "T";
        }
        //Might add more later
    }
    void AutoAddScore()
    {
        elapsedTime += Time.fixedDeltaTime;
        //Basically tells the condition that if the remainder is 1 or it is a whole number, then returns true
        if (elapsedTime >= 1f)
        {
            elapsedTime = elapsedTime % 0.5f;
            solCount = EconomyMain.autoAddScore(solPerSecond * multipliers.autoMulti, solCount);
            solCountAnim.Play(0);

            prestigeManager.AutoAddPoint(solPerSecond * multipliers.autoMulti);
            buildingCounterInterval(solCount);
        }
    }

    public void OnClick_AddSol()
    {
        solCount += tapsPerSecond * multipliers.clickMulti;
        Instantiate(particle, transform.position, transform.rotation);

        prestigeManager.AddPoint(tapsPerSecond * multipliers.clickMulti);
    }


    public void SpawnBuilding(int index)
    {

    }
}