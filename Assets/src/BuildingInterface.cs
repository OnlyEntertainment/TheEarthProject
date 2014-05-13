using UnityEngine;
using System.Collections;
using System;

public class BuildingInterface : MonoBehaviour
{

    public enum BOHRERART { Standard, Eisen, Stahl, Chrom, Titan, Diamant };
    public enum SONDENART { Starterkit, Schwach, Klein, Mittel, Groß, Stark };

    //public GameObject isDrillingVar;


    public GameObject buildingObject = null;
    Building building = null;
    public GameObject BuildingWindowSpriteContainer;
    public GameObject GUIStuff;
    public StorageWindow storageWindow;

    

    //General
    public GameObject titleInput;
    public GameObject statusVar;
    public int drillingDepthMax = 3;

    //Drill
    public GameObject drillingDepthVar;
    public GameObject drillingDepthSlider;


    public GameObject drillTypeVar;
    public GameObject drillTypeSlider;

    public GameObject drillButton;

    //Probe
    public GameObject probeTypeVar;
    public GameObject probeTypeSlider;

    public GameObject probeButton;


    void Start()
    {
        //%
        storageWindow = GUIStuff.GetComponent<StorageWindow>();
    }

    void Update()
    {
        if (buildingObject != null)
        {
            if (building.buildingStatus != Building.BUILDINGSTATUS.Idle)
            {
                drillButton.GetComponent<UIButton>().enabled = false;
                probeButton.GetComponent<UIButton>().enabled = false;
            }
            else
            {
                drillButton.GetComponent<UIButton>().enabled = true;
                probeButton.GetComponent<UIButton>().enabled = true;
            }

            UpdateGUIDrillingDepth();
            UpdateGUIDrillType();
            UpdateGUIProbeType();
            UpdateGUITitle();
            UpdateGUIStatus();
        }
    }

    void UpdateGUIDrillingDepth()
    {
        UISlider slider = drillingDepthSlider.GetComponent<UISlider>();
        slider.numberOfSteps = drillingDepthMax;

        drillingDepthVar.GetComponent<UILabel>().text = ((slider.value * (drillingDepthMax - 1)) + 1).ToString() + " ("+storageWindow.pipesAmount+")"; ;// +"-" + slider.value.ToString();
    }

    void UpdateGUIDrillType()
    {
        UISlider slider = drillTypeSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(BOHRERART)).Length;
        BOHRERART drillType =  (BOHRERART)(slider.value * (slider.numberOfSteps - 1));

        drillTypeVar.GetComponent<UILabel>().text = drillType.ToString() + " ("+GetDrillAmount(drillType)+")";// +"-" + slider.value.ToString();
    }

    void UpdateGUIProbeType()
    {
        UISlider slider = probeTypeSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(SONDENART)).Length;
        SONDENART probeType = (SONDENART)(slider.value * (slider.numberOfSteps - 1));

        probeTypeVar.GetComponent<UILabel>().text = probeType.ToString() + " ("+GetProbeAmount(probeType)+")";// +"-" + slider.value.ToString();
    }

    void UpdateGUITitle()
    {
        UIInput uiInput = titleInput.GetComponent<UIInput>();
        if (!uiInput.isSelected) uiInput.value = building.buildingName;
    }

    void UpdateGUIStatus()
    {
        UILabel uiLabel = statusVar.GetComponent<UILabel>();
        uiLabel.text = building.buildingStatus.ToString();

    }

    public void SetTitle()
    {
        UIInput uiInput = titleInput.GetComponent<UIInput>();
        building.buildingName = uiInput.value;
    }



    public void StartDrilling()
    {
        //DrillMaster

        int drillingDepth = (int)((drillingDepthSlider.GetComponent<UISlider>().value * (drillingDepthMax - 1)) + 1);
        BOHRERART drillType = (BOHRERART)(drillTypeSlider.GetComponent<UISlider>().value * (drillTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));

        if (drillingDepth <= storageWindow.pipesAmount && GetDrillAmount(drillType) > 0)
        {
            storageWindow.pipesAmount -= drillingDepth;
            ReduceDrillAmount(drillType);

            building.timer = building.timerIntervallDrilling;
            StartBuilding(Building.BUILDINGSTATUS.Drilling);
        }

    }

    public void StartProbing()
    {
        SONDENART probeType = (SONDENART)(probeTypeSlider.GetComponent<UISlider>().value * (probeTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));

        drillingDepthSlider.GetComponent<UISlider>().value = (float)(((float)GetProbingDepthGoal(probeType) - 1f) / ((float)drillingDepthMax - 1f));

        int drillingDepth = (int)((drillingDepthSlider.GetComponent<UISlider>().value * (drillingDepthMax - 1)) + 1);

        //if (drillingDepth <= storageWindow.pipesAmount && GetProbeAmount(probeType) > 0)
            if (GetProbeAmount(probeType) > 0)
        {

            //storageWindow.pipesAmount -= drillingDepth;
            ReduceProbeAmount(probeType);

            building.timer = building.timerIntervallProbing;
            // TODO building.drillingDepthGoal Setzten aufgrund der Sonde
            StartBuilding(Building.BUILDINGSTATUS.Probing);
        }

    }

    private void StartBuilding(Building.BUILDINGSTATUS buildingStatus)
    {
        
        building.drillingDepthGoal = (int)((drillingDepthSlider.GetComponent<UISlider>().value * (drillingDepthMax - 1)) + 1);
        building.drillType = (BOHRERART)(drillTypeSlider.GetComponent<UISlider>().value * (drillTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.probeType = (SONDENART)(probeTypeSlider.GetComponent<UISlider>().value * (probeTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.drillingDepthCurrent = 1;

        building.probingDepthGoal = GetProbingDepthGoal(building.probeType);
       building.probingShowAmountMax= GetProbingShowAmountMax(building.probeType);

        building.buildingStatus = buildingStatus;
    }

    public void CloseWindow()
    {
        BuildingWindowSpriteContainer.SetActive(false);
        buildingObject = null;
        building = null;

    }

    public void ShowWindow(GameObject transferItem)
    {
        buildingObject = transferItem;
        building = buildingObject.GetComponent<Building>();

        drillingDepthSlider.GetComponent<UISlider>().value = (float)(((float)building.drillingDepthGoal - 1f) / ((float)drillingDepthMax - 1f));


        drillTypeSlider.GetComponent<UISlider>().value = (float)(building.drillType) / (drillTypeSlider.GetComponent<UISlider>().numberOfSteps - 1);
        probeTypeSlider.GetComponent<UISlider>().value = (float)(building.probeType) * (1 / (probeTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));
        //probeTypeSlider.GetComponent<UISlider>().value = (float)(building.probeType+1) / (float)(Enum.GetNames(typeof(SONDENART)).Length);

        BuildingWindowSpriteContainer.SetActive(true);
    }

    private int GetDrillAmount(BOHRERART drillType)
    { 
        switch (drillType)
            {
            case BOHRERART.Chrom:
                    return storageWindow.drillChromAmount;
                break;
            case BOHRERART.Diamant:
                return storageWindow.drillDiamondAmount;
                break;
            case BOHRERART.Eisen:
                return storageWindow.drillEisenAmount;
                break;
            case BOHRERART.Stahl:
                return storageWindow.drillStahlAmount;
                break;
            case BOHRERART.Standard:
                return storageWindow.drillStandardAmount;
                break;
            case BOHRERART.Titan:
                return storageWindow.drillTitanAmount;
                break;
        }
        return 0;
    }

    private void ReduceDrillAmount(BOHRERART drillType) { ReduceDrillAmount(drillType, 1); }
    private void ReduceDrillAmount(BOHRERART drillType, int amount)
    {
        switch (drillType)
        {
            case BOHRERART.Chrom:
                storageWindow.drillChromAmount-=amount;
                break;
            case BOHRERART.Diamant:
                storageWindow.drillDiamondAmount -= amount;
                break;
            case BOHRERART.Eisen:
                storageWindow.drillEisenAmount -= amount;
                break;
            case BOHRERART.Stahl:
                storageWindow.drillStahlAmount -= amount;
                break;
            case BOHRERART.Standard:
                storageWindow.drillStandardAmount -= amount;
                break;
            case BOHRERART.Titan:
                storageWindow.drillTitanAmount -= amount;
                break;
        }
        
    }

    private int GetProbeAmount(SONDENART probeType)
    {
        switch (probeType)
        {
            case SONDENART.Starterkit:
                return storageWindow.scanStarterKitAmount;
                break;
            case SONDENART.Stark:
                return storageWindow.scanStarkAmount;
                break;
            case SONDENART.Schwach:
                return storageWindow.scanSchwachAmount;
                break;
            case SONDENART.Mittel:
                return storageWindow.scanMittelAmount;
                break;
            case SONDENART.Klein:
                return storageWindow.scanKleinAmount;
                break;
            case SONDENART.Groß:
                return storageWindow.scanGrossAmount;
                break;
        }
        return 0;
    }

    private void ReduceProbeAmount(SONDENART probeType) { ReduceProbeAmount(probeType, 1); }
    private void ReduceProbeAmount(SONDENART probeType, int amount)
    {
        switch (probeType)
        {
            case SONDENART.Starterkit:
                storageWindow.scanStarterKitAmount -= amount;
                break;
            case SONDENART.Stark:
                storageWindow.scanStarkAmount -= amount;
                break;
            case SONDENART.Schwach:
                storageWindow.scanSchwachAmount -= amount;
                break;
            case SONDENART.Mittel:
                storageWindow.scanMittelAmount -= amount;
                break;
            case SONDENART.Klein:
                storageWindow.scanKleinAmount -= amount;
                break;
            case SONDENART.Groß:
                storageWindow.scanGrossAmount -= amount;
                break;
        }
    }

    private int GetProbingDepthGoal(SONDENART probeType)
    {
        switch (probeType)
        {
            //Max 20 Ebenen
            case SONDENART.Starterkit:
                return 4;
                break;
            case SONDENART.Schwach:
                return 8;
                break;
            case SONDENART.Klein:
                return 12;
                break;
            case SONDENART.Mittel:
                return 16;
                break;
            case SONDENART.Groß:
                return 20;
                break;
            case SONDENART.Stark:
                return 20;
                break;
        }

        return 0;
    }

    private int GetProbingShowAmountMax(SONDENART probeType)
    {
        switch (probeType)
        {
            //Max 20 Ebenen
            case SONDENART.Starterkit:
                return 2;
                break;
            case SONDENART.Schwach:
                return 4;
                break;
            case SONDENART.Klein:
                return 6;
                break;
            case SONDENART.Mittel:
                return 8;
                break;
            case SONDENART.Groß:
                return 10;
                break;
            case SONDENART.Stark:
                return 15;
                break;
        }
        return 0;
    }

}


