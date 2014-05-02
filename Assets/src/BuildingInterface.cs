using UnityEngine;
using System.Collections;
using System;

public class BuildingInterface : MonoBehaviour
{

    public enum BOHRERART { Standard, Eisen, Stahl, Chrom, Titan, Diamant };
    public enum SONDENART { Starterkit, Schwach, Klein, Mittel, Groß, Stark };

    public GameObject isDrillingVar;

    public GameObject buildingObject = null;
    Building building = null;
    public GameObject BuildingWindowSpriteContainer;

    public int maxBohrTiefe = 3;

    public GameObject titleInput;

    public GameObject bohrTiefeVar;
    public GameObject bohrTiefeSlider;
    public int bohrTiefeMax;


    public GameObject bohrerArtVar;
    public GameObject bohrerArtSlider;
    public GameObject bohrerButton;

    public GameObject sondenArtVar;
    public GameObject sondenArtSlider;
    public GameObject sondenButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (buildingObject != null)
        {


            UpdateBohrtiefe();
            UpdateBohrerArt();
            UpdateSondenArt();
            UpdateTitle();


            isDrillingVar.GetComponent<UILabel>().text = building.status.ToString();

            //if (building.status != Building.BUILDINGSTATUS.Idle)
            //{
            //    bohrerButton.GetComponent<UIButton>().enabled = false;
            //    sondenButton.GetComponent<UIButton>().enabled = false;
            //}
            //else
            //{
            //    bohrerButton.GetComponent<UIButton>().enabled = true;
            //    sondenButton.GetComponent<UIButton>().enabled = true;
            //}
        }

    }

    void UpdateBohrtiefe()
    {
        UISlider slider = bohrTiefeSlider.GetComponent<UISlider>();
        slider.numberOfSteps = maxBohrTiefe;

        bohrTiefeVar.GetComponent<UILabel>().text = ((slider.value * (maxBohrTiefe - 1)) + 1).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateBohrerArt()
    {
        UISlider slider = bohrerArtSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(BOHRERART)).Length;

        bohrerArtVar.GetComponent<UILabel>().text = ((BOHRERART)(slider.value * (slider.numberOfSteps - 1))).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateSondenArt()
    {
        UISlider slider = sondenArtSlider.GetComponent<UISlider>();
        slider.numberOfSteps = Enum.GetNames(typeof(SONDENART)).Length;

        sondenArtVar.GetComponent<UILabel>().text = ((SONDENART)(slider.value * (slider.numberOfSteps - 1))).ToString();// +"-" + slider.value.ToString();
    }

    void UpdateTitle()
    {
        UIInput uiInput = titleInput.GetComponent<UIInput>();

        if (!uiInput.isSelected) uiInput.value = building.buildingName;
    }

    public void SetTitle()
    { 
        UIInput uiInput = titleInput.GetComponent<UIInput>();
        building.buildingName = uiInput.value;
    }



    public void Bohren()
    {
        Debug.Log("Bohren");

        building.status = Building.BUILDINGSTATUS.Drilling;

        building.bohrtiefe = (int)((bohrTiefeSlider.GetComponent<UISlider>().value * (maxBohrTiefe - 1)) + 1);
        building.bohrerArt = (BOHRERART)(bohrerArtSlider.GetComponent<UISlider>().value * (bohrerArtSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.sondenArt = (SONDENART)(sondenArtSlider.GetComponent<UISlider>().value * (sondenArtSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.bohrTiefeAktuell = 1;
        building.timer = building.timerIntervall;


    }

    public void Sondieren()
    {
        Debug.Log("Sondieren");
        building.status = Building.BUILDINGSTATUS.Probing;

        building.bohrtiefe = (int)((bohrTiefeSlider.GetComponent<UISlider>().value * (maxBohrTiefe - 1)) + 1);
        building.bohrerArt = (BOHRERART)(bohrerArtSlider.GetComponent<UISlider>().value * (bohrerArtSlider.GetComponent<UISlider>().numberOfSteps - 1));
        building.sondenArt = (SONDENART)(sondenArtSlider.GetComponent<UISlider>().value * (sondenArtSlider.GetComponent<UISlider>().numberOfSteps - 1));
    }

    public void CloseWindow()
    {
        //building.showInterface = false;
        BuildingWindowSpriteContainer.SetActive(false);
    }

    public void ShowWindow(GameObject transferItem)
    {
        BuildingWindowSpriteContainer.SetActive(true);
        buildingObject = transferItem;
        building = buildingObject.GetComponent<Building>();
        //building.showInterface = false;

        bohrTiefeSlider.GetComponent<UISlider>().value = (float)(((float)building.bohrtiefe - 1f) / ((float)maxBohrTiefe - 1f));
        bohrerArtSlider.GetComponent<UISlider>().value = (float)building.bohrerArt / (float)(Enum.GetNames(typeof(BOHRERART)).Length);
        sondenArtSlider.GetComponent<UISlider>().value = (float)building.sondenArt / (float)(Enum.GetNames(typeof(SONDENART)).Length);

    }
}
