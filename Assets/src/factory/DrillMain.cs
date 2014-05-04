using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;

public class DrillMain
{

    public string drillName;
    // public int maxLevel;
    public int costsMoney;    // Kosten
    public float buildTime; // Bauzeit in der Fabrik

    public float drillSpeed;
    public int materialAmount;
    public float mainPriceToDrill;


    // Use this for initialization
    public DrillMain(string dName, int moneyCost, float bTime, float dSpeed, int mAmount, float mPriceToDrill)
    {

        drillName = dName;
        costsMoney = moneyCost;
        buildTime = bTime;
        drillSpeed = dSpeed;
        materialAmount = mAmount;
        mainPriceToDrill = mPriceToDrill;

    }

    // Update is called once per frame
    public static Dictionary<bohrerArten, DrillMain> GenerateDrills()
    {
        Dictionary<bohrerArten, DrillMain> drillDict = new Dictionary<bohrerArten, DrillMain>();

        drillDict.Add(bohrerArten.Standard, new DrillMain("Standard", 500, 10f, 5f, 3, 1f));
        drillDict.Add(bohrerArten.Eisen, new DrillMain("Eisen", 2000, 13f, 4.5f, 4, 2f));
        drillDict.Add(bohrerArten.Stahl, new DrillMain("Stahl", 3000, 18f, 4.0f, 5, 3f));
        drillDict.Add(bohrerArten.Chrom, new DrillMain("Chrom", 7500, 22f, 3.5f, 6, 4f));
        drillDict.Add(bohrerArten.Titan, new DrillMain("Titan", 10000, 25f, 3.0f, 7, 5f));
        drillDict.Add(bohrerArten.Diamant, new DrillMain("Diamant", 12500, 30f, 2.5f, 8, 6f));

        return drillDict;
    }
}
