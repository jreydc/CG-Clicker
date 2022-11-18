using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EconomyManager;

public class UnitBuildingEconomy : MonoBehaviour
{
    [SerializeField] internal List<BuildingUnit> unitInstance;

    [SerializeField] internal float solCount;
    private float internalCounter;

    [SerializeField] internal Animator solCountAnim;

    [SerializeField] private PrestigeMain prestigeManager;
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
    public ParticleSystem autoParticle;

    public delegate void buildingCounter(float currentSol);
    public static event buildingCounter buildingCounterInterval;

    public delegate void initialSpawn(float currentSol);
    public static event initialSpawn initSpawn;

    public delegate void upgradeCounter();
    public static event upgradeCounter upgradeCounterInterval;

    private void Awake()
    {
        solCountAnim = solCountText.GetComponent<Animator>();

        prestigeManager = FindObjectOfType<PrestigeMain>();
        multipliers = FindObjectOfType<Multipliers>();

        //BuildingsLogic.spawnBuilding += SpawnBuilding;
    }

    private void Start()
    {
        for (int i = 0; i < unitInstance.Count; i++)
        {
            solPerSecond += (unitInstance[i].baseSol * unitInstance[i].currentOwned);
        }
        initSpawn(solCount);
    }

    private void Update()
    {
        spsText.text = (solPerSecond * multipliers.autoMulti * multipliers.toucAuto).ToString("F1") + "/s";
        //tpsText.text = tapsPerSecond.ToString();
        //gtpsText.text = guardianTapsPerSecond.ToString();
        countingSystem();
        buildingCounterInterval(solCount);
        upgradeCounterInterval();

        if(solPerSecond >= 3)
        {
            autoParticle.loop = true;
        }
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
        else if (solCount >= 1000 && solCount < 1000000) //greater than or equal to 1000
        {
            internalCounter = solCount / 1000;
            solCountText.text = internalCounter.ToString("F1") + "K"; //Thousand
        }
        else if (solCount >= 1000000 && solCount < 1000000000) //Million
        {
            internalCounter = solCount / 1000000;
            solCountText.text = internalCounter.ToString("F3") + "M";
        }
        else if (solCount >= 1000000000 && solCount < 1000000000000) //Billion
        {
            internalCounter = solCount / 1000000000;
            solCountText.text = internalCounter.ToString("F3") + "B";
        }
        else if (solCount >= 1000000000000 && solCount < 1000000000000000) //Trillion
        {
            internalCounter = solCount / 1000000000000;
            solCountText.text = internalCounter.ToString("F3") + "T";
        }
        else if(solCount >= 1000000000000000 && solCount < 1000000000000000000) // Quadrillion
        {
            internalCounter = solCount / 1000000000000000;
            solCountText.text = internalCounter.ToString("F3") + "QD";
        }
        else if(solCount >= 1000000000000000000 && solCount < 1e+21) //Quintillion
        {
            internalCounter = solCount / 1000000000000000000;
            solCountText.text = internalCounter.ToString("F3") + "QT";
        }
        else if(solCount >= 1e+21 && solCount < 1e+24) // Sextillion
        {
            internalCounter = solCount / (float)1e+21;
            solCountText.text = internalCounter.ToString("F3") + "SX";
        }
        else if (solCount >= 1e+24 && solCount < 1e+27) // Septillion
        {
            internalCounter = solCount / (float)1e+24;
            solCountText.text = internalCounter.ToString("F3") + "SP";
        }
        else if (solCount >= 1e+27 && solCount < 1e+30) // Octillion
        {
            internalCounter = solCount / (float)1e+27;
            solCountText.text = internalCounter.ToString("F3") + "O";
        }
        else if(solCount >= 1e+30 && solCount < 1e+33) //Nonillion
        {
            internalCounter = solCount / (float)1e+30;
            solCountText.text = internalCounter.ToString("F3") + "N";
        }
        else if (solCount >= 1e+33) //Decillion
        {
            internalCounter = solCount / (float)1e+33;
            solCountText.text = internalCounter.ToString("F3") + "D";
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
            solCount = EconomyMain.autoAddScore(solPerSecond * multipliers.autoMulti * multipliers.toucAuto, solCount);
            solCountAnim.Play(0);

            //prestigeManager.AutoAddPoint(solPerSecond * multipliers.autoMulti * multipliers.toucAuto);
        }
    }

    public void OnClick_AddSol()
    {
        solCount += tapsPerSecond * multipliers.clickMulti * multipliers.toucClick;
        Instantiate(particle, transform.position, transform.rotation);

        //prestigeManager.AddPoint(tapsPerSecond * multipliers.clickMulti * multipliers.toucClick);
    }

    public void BonusSol(float bonusSol)
    {
        solCount += bonusSol;
        //prestigeManager.AddPoint(bonusSol);
    }
}