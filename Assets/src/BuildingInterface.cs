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
    
    //General
    public GameObject titleInput;
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
        }
    }

    void UpdateGUIDrillingDepth()
    {
        UISlider slider = drillingDepthSlider.GetComponent<UISlider>();
        slider.numberOfSteps = drillingDepthMax;

        drillingDepthVar.GetComponent<UILabel>().text = ((slider.value * (drillingDepthMax - 1)) + 1).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateGUIDrillType()
    {
        UISlider slider = drillTypeSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(BOHRERART)).Length;

        drillTypeVar.GetComponent<UILabel>().text = ((BOHRERART)(slider.value * (slider.numberOfSteps - 1))).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateGUIProbeType()
    {
        UISlider slider = probeTypeSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(SONDENART)).Length;

        probeTypeVar.GetComponent<UILabel>().text = ((SONDENART)(slider.value * (slider.numberOfSteps - 1))).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateGUITitle()
    {
        UIInput uiInput = titleInput.GetComponent<UIInput>();

        if (!uiInput.isSelected) uiInput.value = building.buildingName;
    }

    public void SetTitle()
    {
        UIInput uiInput = titleInput.GetComponent<UIInput>();
        building.buildingName = uiInput.value;
    }



    public void StartDrilling()
    {
        StartBuilding(Building.BUILDINGSTATUS.Drilling);     
    }

    public void StartProbing()
    {
        StartBuilding(Building.BUILDINGSTATUS.Probing);
    }

    private void StartBuilding(Building.BUILDINGSTATUS buildingStatus)
    {
        building.drillingDepthGoal = (int)((drillingDepthSlider.GetComponent<UISlider>().value * (drillingDepthMax - 1)) + 1);
        building.drillType = (BOHRERART)(drillTypeSlider.GetComponent<UISlider>().value * (drillTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.probeType = (SONDENART)(probeTypeSlider.GetComponent<UISlider>().value * (probeTypeSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.drillingDepthCurrent = 1;
        building.timer = building.timerIntervall;

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
        drillTypeSlider.GetComponent<UISlider>().value = (float)building.drillType / (float)(Enum.GetNames(typeof(BOHRERART)).Length);
        probeTypeSlider.GetComponent<UISlider>().value = (float)building.probeType / (float)(Enum.GetNames(typeof(SONDENART)).Length);

        BuildingWindowSpriteContainer.SetActive(true);
    }
}
