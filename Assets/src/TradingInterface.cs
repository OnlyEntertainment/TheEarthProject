using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using BODENARTEN = CellControl.BODENARTEN;

public class TradingInterface : MonoBehaviour
{

    public GameObject tradingInterfaceWindow;

    public UILabel coalStorageVar;
    public UILabel oreStorageVar;
    public UILabel goldStorageVar;
    public UILabel oilStorageVar;
    public UILabel diamondStorageVar;

    public UISlider coalStorageSlider;
    public UISlider oreStorageSlider;
    public UISlider goldStorageSlider;
    public UISlider oilStorageSlider;
    public UISlider diamondStorageSlider;


    public UILabel coalPriceVar;
    public UILabel orePriceVar;
    public UILabel goldPriceVar;
    public UILabel oilPriceVar;
    public UILabel diamondPriceVar;

    //public int coalAmount = 0;
    //public int oreAmount = 0;
    //public int goldAmount = 0;
    //public int oilAmount = 0;
    //public int diamondAmount = 0;

    public UILabel sumPriceVar;

    public GameObject storageWindowObject;
    private StorageWindow storageWindow;

    public GameObject playerAttributeControlObject;
    private PlayerAttributeControl playerAttributeControl;

    private Dictionary<CellControl.BODENARTEN, int> fixedStorage;



    //Trading Stuff
    private Dictionary<BODENARTEN, int> tradingPrices = new Dictionary<BODENARTEN, int>();
    private Dictionary<BODENARTEN, int> changesUP = new Dictionary<BODENARTEN, int>();
    private Dictionary<BODENARTEN, int> changesDOWN = new Dictionary<BODENARTEN, int>();
    //private int changesUP = 0;
    //private int changesDOWN = 0;
    public float tradingPriceTimerIntervall = 30;
    public float tradingPriceTimer;


    private Dictionary<BODENARTEN, int> InitValues = new Dictionary<BODENARTEN, int>();
    
    // Use this for initialization
    void Start()
    {
        tradingPriceTimer = tradingPriceTimerIntervall;

        //foreach (int i in Enum.GetValues(typeof(BODENARTEN)))
        for (int i = 0; i < Enum.GetValues(typeof(BODENARTEN)).Length; i++)
        {
            changesUP[(BODENARTEN)i] = 0;
            changesDOWN[(BODENARTEN)i] = 0;
        }


        storageWindow = storageWindowObject.GetComponent<StorageWindow>();
        playerAttributeControl = playerAttributeControlObject.GetComponent<PlayerAttributeControl>();


        tradingPrices[BODENARTEN.Kohle] = InitValues[BODENARTEN.Kohle] = 100;
        tradingPrices[BODENARTEN.Erz] = InitValues[BODENARTEN.Erz] = 200;
        tradingPrices[BODENARTEN.Gold] = InitValues[BODENARTEN.Gold] = 300;
        tradingPrices[BODENARTEN.Oel] = InitValues[BODENARTEN.Oel] = 400;
        tradingPrices[BODENARTEN.Diamant] = InitValues[BODENARTEN.Diamant] = 500;

        //fixedStorage = new Dictionary<BODENARTEN, int>(storageWindow.bodenData);

    }

    public void ButtonPressed_Sell()
    {
        storageWindow.bodenArtenDictionary[BODENARTEN.Kohle] -= (int)(coalStorageSlider.value * fixedStorage[BODENARTEN.Kohle]);
        storageWindow.bodenArtenDictionary[BODENARTEN.Erz] -= (int)(oreStorageSlider.value * fixedStorage[BODENARTEN.Erz]);
        storageWindow.bodenArtenDictionary[BODENARTEN.Gold] -= (int)(goldStorageSlider.value * fixedStorage[BODENARTEN.Gold]);
        storageWindow.bodenArtenDictionary[BODENARTEN.Oel] -= (int)(oilStorageSlider.value * fixedStorage[BODENARTEN.Oel]);
        storageWindow.bodenArtenDictionary[BODENARTEN.Diamant] -= (int)(diamondStorageSlider.value * fixedStorage[BODENARTEN.Diamant]);

        playerAttributeControl.playerMoney += Convert.ToInt32(sumPriceVar.text);

        coalStorageSlider.value = 0;
        oreStorageSlider.value = 0;
        goldStorageSlider.value = 0;
        oilStorageSlider.value = 0;
        diamondStorageSlider.value = 0;

        ShowWindow();


    }


    // Update is called once per frame
    void Update()
    {
        
        if ( fixedStorage == null)fixedStorage = new Dictionary<BODENARTEN, int>(storageWindow.bodenArtenDictionary);

        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (tradingInterfaceWindow.activeInHierarchy)
            { CloseWindow(); }
            else
            { ShowWindow(); }
        }

        tradingPriceTimer -= 1 * Time.deltaTime;
        if (tradingPriceTimer <= 0)
        {
            tradingPriceTimer = tradingPriceTimerIntervall;
            for (int i = 0; i < Enum.GetValues(typeof(BODENARTEN)).Length; i++)
            {
                if (tradingPrices.ContainsKey((BODENARTEN)i)) ChangingOfTradingPrices((BODENARTEN)i);
            }

        }

        coalStorageVar.text = (coalStorageSlider.value * fixedStorage[BODENARTEN.Kohle]).ToString();
        oreStorageVar.text = (oreStorageSlider.value * fixedStorage[BODENARTEN.Erz]).ToString();
        goldStorageVar.text = (goldStorageSlider.value * fixedStorage[BODENARTEN.Gold]).ToString();
        oilStorageVar.text = (oilStorageSlider.value * fixedStorage[BODENARTEN.Oel]).ToString();
        diamondStorageVar.text = (diamondStorageSlider.value * fixedStorage[BODENARTEN.Diamant]).ToString();

        coalPriceVar.text = tradingPrices[BODENARTEN.Kohle].ToString();
        orePriceVar.text = tradingPrices[BODENARTEN.Erz].ToString();
        goldPriceVar.text = tradingPrices[BODENARTEN.Gold].ToString();
        oilPriceVar.text = tradingPrices[BODENARTEN.Oel].ToString();
        diamondPriceVar.text = tradingPrices[BODENARTEN.Diamant].ToString();

        int sumPrice = 0;
        sumPrice += ((int)(coalStorageSlider.value * fixedStorage[BODENARTEN.Kohle])) * tradingPrices[BODENARTEN.Kohle];
        sumPrice += ((int)(oreStorageSlider.value * fixedStorage[BODENARTEN.Erz])) * tradingPrices[BODENARTEN.Erz];
        sumPrice += ((int)(goldStorageSlider.value * fixedStorage[BODENARTEN.Gold])) * tradingPrices[BODENARTEN.Gold];
        sumPrice += ((int)(oilStorageSlider.value * fixedStorage[BODENARTEN.Oel])) * tradingPrices[BODENARTEN.Oel];
        sumPrice += ((int)(diamondStorageSlider.value * fixedStorage[BODENARTEN.Diamant])) * tradingPrices[BODENARTEN.Diamant];

        sumPriceVar.text = sumPrice.ToString();


    }


    public void ButtonPressed_Coal_Min() { coalStorageSlider.value = 0; }
    public void ButtonPressed_Ore_Min() { oreStorageSlider.value = 0; }
    public void ButtonPressed_Gold_Min() { goldStorageSlider.value = 0; }
    public void ButtonPressed_Oil_Min() { oilStorageSlider.value = 0; }
    public void ButtonPressed_Diamond_Min() { diamondStorageSlider.value = 0; }

    public void ButtonPressed_Coal_Max() { coalStorageSlider.value = fixedStorage[BODENARTEN.Kohle]; }
    public void ButtonPressed_Ore_Max() { oreStorageSlider.value = fixedStorage[BODENARTEN.Erz]; }
    public void ButtonPressed_Gold_Max() { goldStorageSlider.value = fixedStorage[BODENARTEN.Gold]; }
    public void ButtonPressed_Oil_Max() { oilStorageSlider.value = fixedStorage[BODENARTEN.Oel]; }
    public void ButtonPressed_Diamond_Max() { diamondStorageSlider.value = fixedStorage[BODENARTEN.Diamant]; }


    public void ShowWindow()
    {

        fixedStorage = new Dictionary<BODENARTEN, int>(storageWindow.bodenArtenDictionary);
        coalStorageSlider.numberOfSteps = (fixedStorage[BODENARTEN.Kohle]) + 1;
        oreStorageSlider.numberOfSteps = (fixedStorage[BODENARTEN.Erz]) + 1;
        goldStorageSlider.numberOfSteps = (fixedStorage[BODENARTEN.Gold]) + 1;
        oilStorageSlider.numberOfSteps = (fixedStorage[BODENARTEN.Oel]) + 1;
        diamondStorageSlider.numberOfSteps = (fixedStorage[BODENARTEN.Diamant]) + 1;
        tradingInterfaceWindow.SetActive(true);
    }

    public void CloseWindow()
    {

        tradingInterfaceWindow.SetActive(false);

    }


    private void ChangingOfTradingPrices(BODENARTEN bodenart)
    {
        float changeOfPriceMin = 0;
        float changeOfPriceMax = 0;

        float rnd = (int)UnityEngine.Random.Range(1, 100);
        if (rnd > 0 && rnd < 20)
        {
            changeOfPriceMin = 20;
            changeOfPriceMax = 40;
        }
        else if (rnd >= 20 && rnd <= 80)
        {
            changeOfPriceMin = 10;
            changeOfPriceMax = 20;
        } 
        else if (rnd > 80 && rnd <= 100)
        {
            changeOfPriceMin = 30;
            changeOfPriceMax = 60;
        }

        float changeOfPricePercent = UnityEngine.Random.RandomRange(changeOfPriceMin, changeOfPriceMax);

        float chanceOfPriceDown = 50 + changesUP[bodenart];
        float chanceOfPriceUp = 50 + changesDOWN[bodenart];

        rnd = UnityEngine.Random.RandomRange(1f, chanceOfPriceDown + chanceOfPriceUp);

        if (rnd <= chanceOfPriceDown) // Preis Runter
        {
            tradingPrices[bodenart] = Mathf.Clamp((int)(tradingPrices[bodenart] * (100 - changeOfPricePercent) / 100), InitValues[bodenart] / 2, InitValues[bodenart] * 5);
            changesUP[bodenart] = Mathf.Clamp(changesUP[bodenart]--, 0, changesUP[bodenart]);
            changesDOWN[bodenart]++;
        }
        else // Preis Hoch
        {
            tradingPrices[bodenart] = Mathf.Clamp((int)(tradingPrices[bodenart] * (1 + (changeOfPricePercent / 100))), InitValues[bodenart] / 2, InitValues[bodenart] * 5);
            changesDOWN[bodenart] = Mathf.Clamp(changesDOWN[bodenart]--, 0, changesDOWN[bodenart]);
            changesUP[bodenart]++;
        }








    }


}
