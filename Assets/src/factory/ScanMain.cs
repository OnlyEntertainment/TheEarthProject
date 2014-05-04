using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using sondenArten = BuildingInterface.SONDENART;

public class ScanMain
{

    public string scanName;
    public int costsMoney;    // Kosten
    public float buildTime; // Bauzeit in der Fabrik
    public float probingSpeed;
    public int drillDepht;
    public float mainPriceToprobing;

    public ScanMain(string sName, int moneyCost, float bTime, float pSpeed, int dDepht, float mPriceToProbing)
    {

        scanName = sName;
        costsMoney = moneyCost;
        buildTime = bTime;
        probingSpeed = pSpeed;
        drillDepht = dDepht;
        mainPriceToprobing = mPriceToProbing;
    } // END ScanMain

    
    public static Dictionary<sondenArten, ScanMain> GenerateScan()
    {

        Dictionary<sondenArten, ScanMain> scanDict = new Dictionary<sondenArten,ScanMain>();

        scanDict.Add(sondenArten.Starterkit, new ScanMain("Starter Kit", 100, 10f, 5f, 3, 100f));    
        scanDict.Add(sondenArten.Schwach, new ScanMain("Schwach", 200, 15f, 4.5f, 5, 200f));
        scanDict.Add(sondenArten.Klein, new ScanMain("Klein", 300, 20f, 4.0f, 8, 300f));
        scanDict.Add(sondenArten.Mittel, new ScanMain("Mittel", 400, 25f, 3.5f, 11, 400f));
        scanDict.Add(sondenArten.Groß, new ScanMain("Groß", 500, 30f, 3.0f, 14, 500f));
        scanDict.Add(sondenArten.Stark, new ScanMain("Stark", 600, 35f, 2.5f, 15, 600f));

        return scanDict;
    } // END GenerateScan
}
