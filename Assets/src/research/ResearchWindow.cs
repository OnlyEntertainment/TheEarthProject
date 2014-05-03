using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchWindow : MonoBehaviour {

    // Allgemein
    public ResearchMaster rMaster;
    public PlayerAttributeControl playerMaster;
    
    // Research
    public bool showResearch = true;
    public int researchTypeCount;
    public bool researchingStarted = false;
    public float researchTime = 0f;
    public float researchResult = 0f;
    public float speicher1 = 0f;
    public rType currentResearchType;

    // Grafik
    public GameObject researchWindowMenu;

    // Buttons
    public UILabel buttonSpeedLabel;
    public UILabel buttonAmountLabel;
    public UILabel buttonDrillLabel;
    public UILabel buttonBuildCostsLabel;
    public UILabel buttonDrillPlattformLabel;
    public UILabel buttonScan;

    // ProgressBar
    public UISlider progressbarSlider;
    public UILabel researchTimeLabel;
   
    
    
    
    
    // ###########################
	// Use this for initialization
	void Start () {

        rMaster = this.GetComponent<ResearchMaster>();
        researchTypeCount = rMaster.resDictionary.Count;
        playerMaster = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();

        researchWindowMenu = GameObject.FindGameObjectWithTag("MenuResearch");

        

        GameObject childHolder = gameObject.transform.FindChild("ResearchWindowData").gameObject;

        researchTimeLabel = childHolder.transform.FindChild("ResearchTime").gameObject.GetComponent<UILabel>();

        buttonSpeedLabel = childHolder.transform.FindChild("ButtonSpeed").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();
        buttonAmountLabel = childHolder.transform.FindChild("ButtonAmount").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();
        buttonDrillLabel = childHolder.transform.FindChild("ButtonDrill").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();
        buttonBuildCostsLabel = childHolder.transform.FindChild("ButtonBuildCosts").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();
        buttonDrillPlattformLabel = childHolder.transform.FindChild("ButtonDrillPlattform").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();
        buttonScan = childHolder.transform.FindChild("ButtonScan").gameObject.transform.FindChild("Label").gameObject.GetComponent<UILabel>();

        progressbarSlider = gameObject.transform.FindChild("ResearchWindowData").gameObject.transform.FindChild("ProgressBarResearch").gameObject.transform.FindChild("Control - Colored Progress Bar").gameObject.GetComponent<UISlider>();

        ResearchShow();
	} // END Start
	
	// Update is called once per frame
	void Update () {
	
        if(researchingStarted == true)
        {

            if(researchTime > 0)
            {
                //float speicher100 = researchTime;
                //float speicher1 = researchTime / 100;

                researchTime -= 1 * Time.deltaTime;
                researchResult = (1 - ((researchTime / speicher1) / 100));

                progressbarSlider.value = researchResult;
                ResearchWindowReload();
                researchTimeLabel.text = researchTime.ToString();
            }
            else
            {
                rMaster.SetUpgrade(currentResearchType);
                ResearchWindowReload();
                researchingStarted = false;
            }
            

        }
        else
        {
            


        }
        


	} // END Update


    public void ResearchShow()
    {

        if(showResearch == false) 
        { 
            showResearch = true;
            researchWindowMenu.SetActive(true);

            ResearchWindowReload();
        } 
        else
        { 
            showResearch = false;
            researchWindowMenu.SetActive(false);
        }

        

    } // END ResearchShow

    public void ResearchWindowReload()
    {
        buttonSpeedLabel.text = rMaster.resDictionary[rType.Speed].researchTitle + " - " + rMaster.resDictionary[rType.Speed].currentLevel;
        buttonAmountLabel.text = rMaster.resDictionary[rType.Amount].researchTitle + " - " + rMaster.resDictionary[rType.Amount].currentLevel;
        buttonDrillLabel.text = rMaster.resDictionary[rType.Drill].researchTitle + " - " + rMaster.resDictionary[rType.Drill].currentLevel;
        buttonBuildCostsLabel.text = rMaster.resDictionary[rType.BuildCosts].researchTitle + " - " + rMaster.resDictionary[rType.BuildCosts].currentLevel;
        buttonScan.text = rMaster.resDictionary[rType.Scan].researchTitle + " - " + rMaster.resDictionary[rType.Scan].currentLevel;
        buttonDrillPlattformLabel.text = rMaster.resDictionary[rType.DrillingPlattform].researchTitle + " - " + rMaster.resDictionary[rType.DrillingPlattform].currentLevel;


        progressbarSlider.value = researchResult;
    }   // END ResearchShow


}
