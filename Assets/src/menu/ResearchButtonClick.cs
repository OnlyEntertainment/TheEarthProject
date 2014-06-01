using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchButtonClick : MonoBehaviour
{

    public ResearchWindow researchWindowData;
    public PlayerAttributeControl playerAttributeControlData;


    // Use this for initialization
    void Awake()
    {

        researchWindowData = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<ResearchWindow>();
        playerAttributeControlData = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();

    } // END Awake

    // Update is called once per frame
    void Update()
    {

    } // END Update

    public void ButtonSmashed()
    {

        Dictionary<rType, ResearchMain> rMasterDic = researchWindowData.researchMasterData.researchDictionary;

        switch (gameObject.name)
        {
            case "ButtonAmount":
                ResearchMain researchAmount = rMasterDic[rType.Amount];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchAmount.currentLevel < researchAmount.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchAmount.costsMoney[researchAmount.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchAmount.costsResearch[researchAmount.currentLevel])
                        {
                            researchWindowData.currentResearchType = rType.Amount;
                            researchWindowData.researchTime = researchAmount.researchTime[researchAmount.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchAmount.costsMoney[researchAmount.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchAmount.costsResearch[researchAmount.currentLevel];
                        }

                    }
                }

                break;
            case "ButtonBuildCosts":
                ResearchMain researchBuildCosts = rMasterDic[rType.BuildCosts];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchBuildCosts.currentLevel < researchBuildCosts.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchBuildCosts.costsMoney[researchBuildCosts.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchBuildCosts.costsResearch[researchBuildCosts.currentLevel])
                        {
                            researchWindowData.currentResearchType = rType.BuildCosts;
                            researchWindowData.researchTime = researchBuildCosts.researchTime[researchBuildCosts.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchBuildCosts.costsMoney[researchBuildCosts.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchBuildCosts.costsResearch[researchBuildCosts.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonDrill":
                ResearchMain researchDrill = rMasterDic[rType.Drill];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchDrill.currentLevel < researchDrill.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchDrill.costsMoney[researchDrill.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchDrill.costsResearch[researchDrill.currentLevel])
                        {
                            researchWindowData.currentResearchType = rType.Drill;
                            researchWindowData.researchTime = researchDrill.researchTime[researchDrill.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchDrill.costsMoney[researchDrill.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchDrill.costsResearch[researchDrill.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonSpeed":
                ResearchMain researchSpeed = rMasterDic[rType.Speed];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchSpeed.currentLevel < researchSpeed.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchSpeed.costsMoney[researchSpeed.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchSpeed.costsResearch[researchSpeed.currentLevel])
                        {
                            researchWindowData.currentResearchType = rType.Speed;
                            researchWindowData.researchTime = researchSpeed.researchTime[researchSpeed.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchSpeed.costsMoney[researchSpeed.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchSpeed.costsResearch[researchSpeed.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonDrillPlattform":
                ResearchMain researchDrillPlattform = rMasterDic[rType.DrillingPlattform];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchDrillPlattform.currentLevel < researchDrillPlattform.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchDrillPlattform.costsMoney[researchDrillPlattform.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchDrillPlattform.costsResearch[researchDrillPlattform.currentLevel])
                        {
                            researchWindowData.currentResearchType = rType.DrillingPlattform;
                            researchWindowData.researchTime = researchDrillPlattform.researchTime[researchDrillPlattform.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchDrillPlattform.costsMoney[researchDrillPlattform.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchDrillPlattform.costsResearch[researchDrillPlattform.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonScan":
                ResearchMain researchScan = rMasterDic[rType.Scan];
                if (researchWindowData.researchingStarted == false)
                {
                    if (researchScan.currentLevel < researchScan.maxLevel)
                    {

                        if (playerAttributeControlData.playerMoney >= researchScan.costsMoney[researchScan.currentLevel] && playerAttributeControlData.playerResearchPoints >= researchScan.costsResearch[researchScan.currentLevel])
                        {

                            researchWindowData.currentResearchType = rType.Scan;
                            researchWindowData.researchTime = researchScan.researchTime[researchScan.currentLevel];
                            researchWindowData.speicher1 = researchWindowData.researchTime / 100;
                            researchWindowData.researchingStarted = true;

                            playerAttributeControlData.playerMoney -= researchScan.costsMoney[researchScan.currentLevel];
                            playerAttributeControlData.playerResearchPoints -= researchScan.costsResearch[researchScan.currentLevel];
                        }

                    }
                }
                break;
        }

    }

}
