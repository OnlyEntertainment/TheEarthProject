using UnityEngine;
using System.Collections;
using System;

public class BuildingInterface : MonoBehaviour
{

    enum BOHRERART { Standard, Eisen, Stahl, Chrom, Titan, Diamant };
    enum SONDENART { Starterkit, Schwach, Klein, Mittel, Groß, Stark };

    public GameObject isDrillingVar;

    public GameObject buildingObject = null;
    Building building = null;
    public GameObject BuildingWindowSpriteContainer;

    public int maxBohrTiefe = 3;

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

            isDrillingVar.GetComponent<UILabel>().text = building.isDrilling.ToString();

            if (building.isDrilling)
            {
                bohrerButton.GetComponent<UIButton>().enabled = false;
                sondenButton.GetComponent<UIButton>().enabled = false;
            }
            else
            {
                bohrerButton.GetComponent<UIButton>().enabled = true;
                sondenButton.GetComponent<UIButton>().enabled = true;
            }
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





    public void Bohren()
    {
        Debug.Log("Bohren");
        building.isDrilling = true;
    }

    public void Sondieren()
    {
        Debug.Log("Sondieren");
        building.isDrilling = true;
    }

    public void CloseWindow()
    {
        building.showInterface = false;
        BuildingWindowSpriteContainer.SetActive(false);
    }

    public void ShowWindow(GameObject transferItem)
    {
        BuildingWindowSpriteContainer.SetActive(true);
        buildingObject = transferItem;
        building = buildingObject.GetComponent<Building>();
        building.showInterface = false;

    }
}
