using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchWindow : MonoBehaviour {

    // Allgemein
    public ResearchMaster researchMasterData;
    public PlayerAttributeControl playerAttributeControlData;
    
    // Research
    public bool showResearch = true;
    public int researchTypeCount;
    public bool researchingStarted = false;
    public float researchTime = 0f;
    public float researchResult = 0f;
    public float speicher1 = 0f;
    public rType currentResearchType;

    // Grafik
    public GameObject researchWindowMenuObject;

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

        researchMasterData = this.GetComponent<ResearchMaster>();
        researchTypeCount = researchMasterData.researchDictionary.Count;
        playerAttributeControlData = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();

        researchWindowMenuObject = GameObject.FindGameObjectWithTag("MenuResearch");

        

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
                researchMasterData.SetUpgrade(currentResearchType);
                ResearchWindowReload();

                if(currentResearchType == rType.Speed)
                {
                    playerAttributeControlData.researchDrillingSpeed = researchMasterData.researchDictionary[rType.Speed].valueStep[researchMasterData.researchDictionary[rType.Speed].currentLevel];
                }
                else if (currentResearchType == rType.Amount)
                {
                    playerAttributeControlData.researchDrillingAmount = researchMasterData.researchDictionary[rType.Amount].valueStep[researchMasterData.researchDictionary[rType.Amount].currentLevel];

                }
                else if (currentResearchType == rType.Scan)
                {
                    playerAttributeControlData.researchScanSpeed = researchMasterData.researchDictionary[rType.Scan].valueStep[researchMasterData.researchDictionary[rType.Scan].currentLevel];

                }
                else if (currentResearchType == rType.Drill)
                {
                   // playerMaster.researchDrillType = rMaster.resDictionary[rType.Drill].valueStep[rMaster.resDictionary[rType.Drill].currentLevel];

                }








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
            researchWindowMenuObject.SetActive(true);

            ResearchWindowReload();
        } 
        else
        { 
            showResearch = false;
            researchWindowMenuObject.SetActive(false);
        }

        

    } // END ResearchShow

    public void ResearchWindowReload()
    {
        buttonSpeedLabel.text = researchMasterData.researchDictionary[rType.Speed].researchTitle + " - " + researchMasterData.researchDictionary[rType.Speed].currentLevel;
        buttonAmountLabel.text = researchMasterData.researchDictionary[rType.Amount].researchTitle + " - " + researchMasterData.researchDictionary[rType.Amount].currentLevel;
        buttonDrillLabel.text = researchMasterData.researchDictionary[rType.Drill].researchTitle + " - " + researchMasterData.researchDictionary[rType.Drill].currentLevel;
        buttonBuildCostsLabel.text = researchMasterData.researchDictionary[rType.BuildCosts].researchTitle + " - " + researchMasterData.researchDictionary[rType.BuildCosts].currentLevel;
        buttonScan.text = researchMasterData.researchDictionary[rType.Scan].researchTitle + " - " + researchMasterData.researchDictionary[rType.Scan].currentLevel;
        buttonDrillPlattformLabel.text = researchMasterData.researchDictionary[rType.DrillingPlattform].researchTitle + " - " + researchMasterData.researchDictionary[rType.DrillingPlattform].currentLevel;


        progressbarSlider.value = researchResult;
    }   // END ResearchShow


}
