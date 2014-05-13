using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;
using bArten = BuildingInterface.BOHRERART;
using sArten = BuildingInterface.SONDENART;

public class PlayerAttributeControl : MonoBehaviour {

    // Variablen
    public int playerMoney = 0;                     // Menge an Geld des Spielers
    public int playerResearchPoints = 0;                 // Menge an Labor/Forschungspunkten des Spielers

    GameObject moneyGameObject;
    GameObject researchPointsGameObject;


    // +++++++
    // Research

    

    // +++++++

    public float researchDrillingSpeed = 1.0f;
    public float researchDrillingAmount = 1.0f;
    public float researchScanSpeed = 1.0f;
    public bArten researchDrillType = bArten.Standard;
    public sArten researchScanType = sArten.Starterkit;
    public bool researchOffShore = false;
    public float researchBuildCosts = 1.0f;

	// Use this for initialization
	void Start () 
    {

        moneyGameObject = GameObject.FindGameObjectWithTag("Money");


        //researchPointsGameObject = GameObject.FindGameObjectWithTag("LaborPoints");



	} // END Start
	
	// Update is called once per frame
	void Update () 
    {

        ResearchPointsLoop();
        MoneyLoop();


	} // END Update



    void MoneyLoop()
    {
       // moneyTextMesh.text = "Money: " + playerMoney.ToString();
    } // END MoneyLoop


    void ResearchPointsLoop()
    {
       // researchPointsTextMesh.text = "LabPoints: " + playerResearchPoints.ToString();
    } // END ResearchPointsLoop



    void ResearchLoop()
    { 
        



    }

    void SetNewGettingMaterialSpeed(float newGettingMaterialSpeed)
    {
        researchDrillingSpeed = newGettingMaterialSpeed;
        
    }

    void GetNewGettingMaterialSpeed(float newGettingMaterialSpeed)
    {

        if (newGettingMaterialSpeed > researchDrillingSpeed)
        {
            SetNewGettingMaterialSpeed(newGettingMaterialSpeed);
        }
        else { }
    }


} // END END
