using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;
using sondenArten = BuildingInterface.SONDENART;

public class FactoryWindow : MonoBehaviour
{


    // Standard
    public bool showFactory = true;

    // Factory
    // Allgemein
    public int costsAmount = 0;


    // Factory
    // Drill
    public DrillMaster dMaster;
    public Dictionary<bohrerArten, DrillMain> drillDic;
    public int drillCurrentShownType = 0;
    public int drillAmount = 0;


    // Factory
    // Scan
    public ScanMaster sMaster;
    public Dictionary<sondenArten, ScanMain> scanDic;
    public int scanCurrentShownType = 0;
    public int scanAmount = 0;

    // Factory
    // Pipes
    public int pipesAmount = 0;
    public int pipesPrice = 150;      // Baukosten pro Stück
    public float pipesTime = 5f;     // Bauzeit

    // Links
    public GameObject factoryWindowMenu;


    // Label
    public UILabel drillLabelType;
    public UILabel drillLabelValue;
    public UILabel scanLabelType;
    public UILabel scanLabelValue;
    public UILabel pipesValue;

    public UILabel costsValue;


    // Use this for initialization
    void Start()
    {

        factoryWindowMenu = GameObject.FindGameObjectWithTag("MenuFactory");
        dMaster = GetComponent<DrillMaster>();
        sMaster = GetComponent<ScanMaster>();
        drillDic = dMaster.drillDictionary;
        scanDic = sMaster.scanDictionary;

        GameObject drillDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("DrillData").gameObject;
        drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        drillLabelValue = drillDataObject.transform.FindChild("LabelDrillValue").gameObject.GetComponent<UILabel>();

        GameObject scanDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("ScanData").gameObject;
        scanLabelType = scanDataObject.transform.FindChild("LabelScanType").gameObject.GetComponent<UILabel>();
        scanLabelValue = scanDataObject.transform.FindChild("LabelScanValue").gameObject.GetComponent<UILabel>();

        GameObject pipesDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("PipesData").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        pipesValue = pipesDataObject.transform.FindChild("LabelPipesValue").gameObject.GetComponent<UILabel>();

        GameObject kostenDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("LabelKosten").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        costsValue = kostenDataObject.transform.FindChild("LabelKostenValue").gameObject.GetComponent<UILabel>();

        FactoryWindowReload();
    }

    // Update is called once per frame
    void Update()
    {

        FactoryWindowReload();
    }



    public void FactoryShow()
    {

        if (showFactory == false)
        {
            showFactory = true;
            factoryWindowMenu.SetActive(true);

            FactoryWindowReload();
        }
        else
        {
            showFactory = false;
            factoryWindowMenu.SetActive(false);
        }



    } // END FactoryShow

    void FactoryWindowReload()
    {

        switch (drillCurrentShownType)
        {
            case 0:
                drillLabelType.text = drillDic[bohrerArten.Standard].drillName;
                break;
            case 1:
                drillLabelType.text = drillDic[bohrerArten.Eisen].drillName;
                break;
            case 2:
                drillLabelType.text = drillDic[bohrerArten.Stahl].drillName;
                break;
            case 3:
                drillLabelType.text = drillDic[bohrerArten.Chrom].drillName;
                break;
            case 4:
                drillLabelType.text = drillDic[bohrerArten.Titan].drillName;
                break;
            case 5:
                drillLabelType.text = drillDic[bohrerArten.Diamant].drillName;
                break;
        } // DrillLabelType

        drillLabelValue.text = drillAmount.ToString();



        switch (scanCurrentShownType)
        {
            case 0:
                scanLabelType.text = scanDic[sondenArten.Starterkit].scanName;
                break;
            case 1:
                scanLabelType.text = scanDic[sondenArten.Schwach].scanName;
                break;
            case 2:
                scanLabelType.text = scanDic[sondenArten.Klein].scanName;
                break;
            case 3:
                scanLabelType.text = scanDic[sondenArten.Mittel].scanName;
                break;
            case 4:
                scanLabelType.text = scanDic[sondenArten.Groß].scanName;
                break;
            case 5:
                scanLabelType.text = scanDic[sondenArten.Stark].scanName;
                break;
        } // ScanLabelType

        scanLabelValue.text = scanAmount.ToString();

        pipesValue.text = pipesAmount.ToString();

        CostsReload();
        costsValue.text = costsAmount.ToString();
    }


    void CostsReload()
    {
        

        int drillCosts = drillDic[GetBohrerArtByString(drillLabelType.text)].costsMoney * drillAmount;
        int scanCosts = scanDic[GetSondenArtByString(scanLabelType.text)].costsMoney * scanAmount;
        int pipesCosts = pipesPrice * pipesAmount;

        costsAmount = drillCosts + scanCosts + pipesCosts;
    } // END CostsReload





    private bohrerArten GetBohrerArtByString(string enumString)
    {
        for (int i = 0; i < Enum.GetNames(typeof(bohrerArten)).Length; i++)
        {
            if (((bohrerArten)i).ToString() == enumString) { return (bohrerArten)i; }
        }
        return (bohrerArten)0;
    } // END GetBohrerArtByString

    private sondenArten GetSondenArtByString(string enumString)
    {
        for (int i = 0; i < Enum.GetNames(typeof(sondenArten)).Length; i++)
        {
            if (((sondenArten)i).ToString() == enumString) { return (sondenArten)i; }
        }
        return (sondenArten)0;
    } // END GetSondenArtByString
}
