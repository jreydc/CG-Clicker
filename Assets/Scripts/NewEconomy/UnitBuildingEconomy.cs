using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EconomyManager;

public class UnitBuildingEconomy : MonoBehaviour
{
    [SerializeField] internal List<BuildingUnit> unitInstance;
    [SerializeField] internal List<UpgradeFunction> upgradesInstance;

    [SerializeField] internal float solCount;
    private float internalCounter;
    private float spsInternalCounter;

    [SerializeField] internal Animator solCountAnim;

    [SerializeField] private PrestigeMain prestigeManager;
    [SerializeField] private Multipliers multipliers;

    #region NUMBER_VARIABLES
    [SerializeField] internal float solPerSecond = 0f;
    [SerializeField] internal float tapsPerSecond = 1.0f;
    [SerializeField] internal float guardianTapsPerSecond = 0f;

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

    public delegate void BuildingPeeker(float currentSol);
    public static event BuildingPeeker buildingPeeker;

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

        for(int i = 0; i < upgradesInstance.Count; i++)
        {
            solPerSecond += upgradesInstance[i].currentProduction;
        }
        initSpawn(solCount);
    }

    public void Formatter(float currentProd)
    {
        solPerSecond -= currentProd;
    }
    public void RefreshForUpgrades(int i)
    {
        solPerSecond += upgradesInstance[i].currentProduction;
    }

    private void Update()
    {
        spsCounter();
        //spsText.text = (solPerSecond * multipliers.autoMulti * multipliers.toucAuto).ToString("F1") + "/s";
        //tpsText.text = tapsPerSecond.ToString();
        //gtpsText.text = guardianTapsPerSecond.ToString();
        countingSystem();
        buildingCounterInterval(solCount);
        buildingPeeker(solCount);
        upgradeCounterInterval();

        if(solPerSecond >= 3)
        {
            //autoParticle.loop = true;
        }
    }

    void spsCounter()
    {
        if (solPerSecond < 1000) //less than 1000
        {
            spsText.text = solPerSecond.ToString("F1") + "/s";
        }
        //Thousand
        else if (solPerSecond >= 1e+3f && solPerSecond < 1e+4f)
        {
            spsInternalCounter = solPerSecond / 1e+3f;
            spsText.text = spsInternalCounter.ToString("F2") + "K" + "/s";
        }
        else if (solPerSecond >= 1e+4f && solPerSecond < 1e+5f)
        {
            spsInternalCounter = solPerSecond / 1e+3f;
            spsText.text = spsInternalCounter.ToString("F2") + "K" + "/s";
        }
        else if (solPerSecond >= 1e+5f && solPerSecond < 1e+6f)
        {
            spsInternalCounter = solPerSecond / 1e+3f;
            spsText.text = spsInternalCounter.ToString("F2") + "K" + "/s";
        }
        //Million
        else if (solPerSecond >= 1e+6f && solPerSecond < 1e+7f)
        {
            spsInternalCounter = solPerSecond / 1e+6f;
            spsText.text = spsInternalCounter.ToString("F2") + "M" + "/s";
        }
        else if (solPerSecond >= 1e+7f && solPerSecond < 1e+8f)
        {
            spsInternalCounter = solPerSecond / 1e+6f;
            spsText.text = spsInternalCounter.ToString("F2") + "M" + "/s";
        }
        else if (solPerSecond >= 1e+8f && solPerSecond < 1e+9f)
        {
            spsInternalCounter = solPerSecond / 1e+6f;
            spsText.text = spsInternalCounter.ToString("F2") + "M" + "/s";
        }
        //Billion
        else if (solPerSecond >= 1e+9f && solPerSecond < 1e+10f)
        {
            spsInternalCounter = solPerSecond / 1e+9f;
            spsText.text = spsInternalCounter.ToString("F2") + "B" + "/s";
        }
        else if (solPerSecond >= 1e+10f && solPerSecond < 1e+11f)
        {
            spsInternalCounter = solPerSecond / 1e+9f;
            spsText.text = spsInternalCounter.ToString("F2") + "B" + "/s";
        }
        else if (solPerSecond >= 1e+11f && solPerSecond < 1e+12f)
        {
            spsInternalCounter = solPerSecond / 1e+9f;
            spsText.text = spsInternalCounter.ToString("F2") + "B" + "/s";
        }
        //Trillion
        else if (solPerSecond >= 1e+12f && solPerSecond < 1e+13f)
        {
            spsInternalCounter = solPerSecond / 1e+12f;
            spsText.text = spsInternalCounter.ToString("F2") + "T" + "/s";
        }
        else if (solPerSecond >= 1e+13f && solPerSecond < 1e+14f)
        {
            spsInternalCounter = solPerSecond / 1e+12f;
            spsText.text = spsInternalCounter.ToString("F2") + "T" + "/s";
        }
        else if (solPerSecond >= 1e+14f && solPerSecond < 1e+15f)
        {
            spsInternalCounter = solPerSecond / 1e+12f;
            spsText.text = spsInternalCounter.ToString("F2") + "T" + "/s";
        }
        //Quadrillion
        else if (solPerSecond >= 1e+15f && solPerSecond < 1e+16f)
        {
            spsInternalCounter = solPerSecond / 1e+15f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qd" + "/s";
        }
        else if (solPerSecond >= 1e+16f && solPerSecond < 1e+17f)
        {
            spsInternalCounter = solPerSecond / 1e+15f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qd" + "/s";
        }
        else if (solPerSecond >= 1e+17f && solPerSecond < 1e+18f)
        {
            spsInternalCounter = solPerSecond / 1e+15f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qd" + "/s";
        }
        //Quintillion
        else if (solPerSecond >= 1e+18f && solPerSecond < 1e+19f)
        {
            spsInternalCounter = solPerSecond / 1e+18f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qt" + "/s";
        }
        else if (solPerSecond >= 1e+19f && solPerSecond < 1e+20f)
        {
            spsInternalCounter = solPerSecond / 1e+18f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qt" + "/s";
        }
        else if (solPerSecond >= 1e+20f && solPerSecond < 1e+21f)
        {
            spsInternalCounter = solPerSecond / 1e+18f;
            spsText.text = spsInternalCounter.ToString("F2") + "Qt" + "/s";
        }
        //Sextillion
        else if (solPerSecond >= 1e+21f && solPerSecond < 1e+22f)
        {
            spsInternalCounter = solPerSecond / 1e+21f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sx" + "/s";
        }
        else if (solPerSecond >= 1e+22f && solPerSecond < 1e+23f)
        {
            spsInternalCounter = solPerSecond / 1e+21f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sx" + "/s";
        }
        else if (solPerSecond >= 1e+23f && solPerSecond < 1e+24f)
        {
            spsInternalCounter = solPerSecond / 1e+21f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sx" + "/s";
        }
        //Septillion
        else if (solPerSecond >= 1e+24f && solPerSecond < 1e+25f)
        {
            spsInternalCounter = solPerSecond / 1e+24f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sp" + "/s";
        }
        else if (solPerSecond >= 1e+25f && solPerSecond < 1e+26f)
        {
            spsInternalCounter = solPerSecond / 1e+24f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sp" + "/s";
        }
        else if (solPerSecond >= 1e+26f && solPerSecond < 1e+27f)
        {
            spsInternalCounter = solPerSecond / 1e+24f;
            spsText.text = spsInternalCounter.ToString("F2") + "Sp" + "/s";
        }
        //Octillion
        else if (solPerSecond >= 1e+27f && solPerSecond < 1e+28f)
        {
            spsInternalCounter = solPerSecond / 1e+27f;
            spsText.text = spsInternalCounter.ToString("F2") + "Oc" + "/s";
        }
        else if (solPerSecond >= 1e+28f && solPerSecond < 1e+29f)
        {
            spsInternalCounter = solPerSecond / 1e+27f;
            spsText.text = spsInternalCounter.ToString("F2") + "Oc" + "/s";
        }
        else if (solPerSecond >= 1e+29f && solPerSecond < 1e+30f)
        {
            spsInternalCounter = solPerSecond / 1e+27f;
            spsText.text = spsInternalCounter.ToString("F2") + "Oc" + "/s";
        }
        //Nonillion
        else if (solPerSecond >= 1e+30f && solPerSecond < 1e+31f)
        {
            spsInternalCounter = solPerSecond / 1e+30f;
            spsText.text = spsInternalCounter.ToString("F2") + "N" + "/s";
        }
        else if (solPerSecond >= 1e+31f && solPerSecond < 1e+32f)
        {
            spsInternalCounter = solPerSecond / 1e+30f;
            spsText.text = spsInternalCounter.ToString("F2") + "N" + "/s";
        }
        else if (solPerSecond >= 1e+32f && solPerSecond < 1e+33f)
        {
            spsInternalCounter = solPerSecond / 1e+30f;
            spsText.text = spsInternalCounter.ToString("F2") + "N" + "/s";
        }
        //Decillion
        else if (solPerSecond >= 1e+33f && solPerSecond < 1e+34f)
        {
            spsInternalCounter = solPerSecond / 1e+33f;
            spsText.text = spsInternalCounter.ToString("F2") + "D" + "/s";
        }
        else if (solPerSecond >= 1e+34f && solPerSecond < 1e+35f)
        {
            spsInternalCounter = solPerSecond / 1e+33f;
            spsText.text = spsInternalCounter.ToString("F2") + "D" + "/s";
        }
        else if (solPerSecond >= 1e+35f && solPerSecond < 1e+36f)
        {
            spsInternalCounter = solPerSecond / 1e+33f;
            spsText.text = spsInternalCounter.ToString("F2") + "D" + "/s";
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
        //Thousand
        else if (solCount >= 1e+3f && solCount < 1e+4f)
        {
            internalCounter = solCount / 1e+3f;
            solCountText.text = internalCounter.ToString("F2") + "K";
        }
        else if (solCount >= 1e+4f && solCount < 1e+5f)
        {
            internalCounter = solCount / 1e+3f;
            solCountText.text = internalCounter.ToString("F2") + "K";
        }
        else if (solCount >= 1e+5f && solCount < 1e+6f)
        {
            internalCounter = solCount / 1e+3f;
            solCountText.text = internalCounter.ToString("F2") + "K";
        }
        //Million
        else if (solCount >= 1e+6f && solCount < 1e+7f)
        {
            internalCounter = solCount / 1e+6f;
            solCountText.text = internalCounter.ToString("F2") + "M";
        }
        else if (solCount >= 1e+7f && solCount < 1e+8f)
        {
            internalCounter = solCount / 1e+6f;
            solCountText.text = internalCounter.ToString("F2") + "M";
        }
        else if (solCount >= 1e+8f && solCount < 1e+9f)
        {
            internalCounter = solCount / 1e+6f;
            solCountText.text = internalCounter.ToString("F2") + "M";
        }
        //Billion
        else if (solCount >= 1e+9f && solCount < 1e+10f)
        {
            internalCounter = solCount / 1e+9f;
            solCountText.text = internalCounter.ToString("F2") + "B";
        }
        else if (solCount >= 1e+10f && solCount < 1e+11f)
        {
            internalCounter = solCount / 1e+9f;
            solCountText.text = internalCounter.ToString("F2") + "B";
        }
        else if (solCount >= 1e+11f && solCount < 1e+12f)
        {
            internalCounter = solCount / 1e+9f;
            solCountText.text = internalCounter.ToString("F2") + "B";
        }
        //Trillion
        else if (solCount >= 1e+12f && solCount < 1e+13f)
        {
            internalCounter = solCount / 1e+12f;
            solCountText.text = internalCounter.ToString("F1") + "T";
        }
        else if (solCount >= 1e+13f && solCount < 1e+14f)
        {
            internalCounter = solCount / 1e+12f;
            solCountText.text = internalCounter.ToString("F2") + "T";
        }
        else if (solCount >= 1e+14f && solCount < 1e+15f)
        {
            internalCounter = solCount / 1e+12f;
            solCountText.text = internalCounter.ToString("F2") + "T";
        }
        //Quadrillion
        else if (solCount >= 1e+15f && solCount < 1e+16f)
        {
            internalCounter = solCount / 1e+15f;
            solCountText.text = internalCounter.ToString("F2") + "Qd";
        }
        else if (solCount >= 1e+16f && solCount < 1e+17f)
        {
            internalCounter = solCount / 1e+15f;
            solCountText.text = internalCounter.ToString("F2") + "Qd";
        }
        else if (solCount >= 1e+17f && solCount < 1e+18f)
        {
            internalCounter = solCount / 1e+15f;
            solCountText.text = internalCounter.ToString("F2") + "Qd";
        }
        //Quintillion
        else if (solCount >= 1e+18f && solCount < 1e+19f)
        {
            internalCounter = solCount / 1e+18f;
            solCountText.text = internalCounter.ToString("F2") + "Qt";
        }
        else if (solCount >= 1e+19f && solCount < 1e+20f)
        {
            internalCounter = solCount / 1e+18f;
            solCountText.text = internalCounter.ToString("F2") + "Qt";
        }
        else if (solCount >= 1e+20f && solCount < 1e+21f)
        {
            internalCounter = solCount / 1e+18f;
            solCountText.text = internalCounter.ToString("F2") + "Qt";
        }
        //Sextillion
        else if (solCount >= 1e+21f && solCount < 1e+22f)
        {
            internalCounter = solCount / 1e+21f;
            solCountText.text = internalCounter.ToString("F2") + "Sx";
        }
        else if (solCount >= 1e+22f && solCount < 1e+23f)
        {
            internalCounter = solCount / 1e+21f;
            solCountText.text = internalCounter.ToString("F2") + "Sx";
        }
        else if (solCount >= 1e+23f && solCount < 1e+24f)
        {
            internalCounter = solCount / 1e+21f;
            solCountText.text = internalCounter.ToString("F2") + "Sx";
        }
        //Septillion
        else if (solCount >= 1e+24f && solCount < 1e+25f)
        {
            internalCounter = solCount / 1e+24f;
            solCountText.text = internalCounter.ToString("F2") + "Sp";
        }
        else if (solCount >= 1e+25f && solCount < 1e+26f)
        {
            internalCounter = solCount / 1e+24f;
            solCountText.text = internalCounter.ToString("F2") + "Sp";
        }
        else if (solCount >= 1e+26f && solCount < 1e+27f)
        {
            internalCounter = solCount / 1e+24f;
            solCountText.text = internalCounter.ToString("F2") + "Sp";
        }
        //Octillion
        else if (solCount >= 1e+27f && solCount < 1e+28f)
        {
            internalCounter = solCount / 1e+27f;
            solCountText.text = internalCounter.ToString("F2") + "Oc";
        }
        else if (solCount >= 1e+28f && solCount < 1e+29f)
        {
            internalCounter = solCount / 1e+27f;
            solCountText.text = internalCounter.ToString("F2") + "Oc";
        }
        else if (solCount >= 1e+29f && solCount < 1e+30f)
        {
            internalCounter = solCount / 1e+27f;
            solCountText.text = internalCounter.ToString("F2") + "Oc";
        }
        //Nonillion
        else if (solCount >= 1e+30f && solCount < 1e+31f)
        {
            internalCounter = solCount / 1e+30f;
            solCountText.text = internalCounter.ToString("F2") + "N";
        }
        else if (solCount >= 1e+31f && solCount < 1e+32f)
        {
            internalCounter = solCount / 1e+30f;
            solCountText.text = internalCounter.ToString("F2") + "N";
        }
        else if (solCount >= 1e+32f && solCount < 1e+33f)
        {
            internalCounter = solCount / 1e+30f;
            solCountText.text = internalCounter.ToString("F2") + "N";
        }
        //Decillion
        else if (solCount >= 1e+33f && solCount < 1e+34f)
        {
            internalCounter = solCount / 1e+33f;
            solCountText.text = internalCounter.ToString("F2") + "D";
        }
        else if (solCount >= 1e+34f && solCount < 1e+35f)
        {
            internalCounter = solCount / 1e+33f;
            solCountText.text = internalCounter.ToString("F2") + "D";
        }
        else if (solCount >= 1e+35f && solCount < 1e+36f)
        {
            internalCounter = solCount / 1e+33f;
            solCountText.text = internalCounter.ToString("F2") + "D";
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
            //solCount = EconomyMain.autoAddScore(solPerSecond * multipliers.autoMulti * multipliers.toucAuto, solCount);
            solCount = EconomyMain.autoAddScore(solPerSecond, solCount);
            solCountAnim.Play(0);

            //prestigeManager.AutoAddPoint(solPerSecond * multipliers.autoMulti * multipliers.toucAuto);
        }
    }

    public void OnClick_AddSol()
    {
        //solCount += tapsPerSecond * multipliers.clickMulti * multipliers.toucClick;
        solCount += tapsPerSecond;
        Instantiate(particle, transform.position, transform.rotation);

        //Vibrator.Vibrate(500);

        //prestigeManager.AddPoint(tapsPerSecond * multipliers.clickMulti * multipliers.toucClick);
    }

    public void BonusSol(float bonusSol)
    {
        solCount += bonusSol;
        //prestigeManager.AddPoint(bonusSol);
    }
}