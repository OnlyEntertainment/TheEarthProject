using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchButtonClick : MonoBehaviour
{

    public ResearchWindow resWindow;
    public PlayerAttributeControl pMaster;


    // Use this for initialization
    void Awake()
    {

        resWindow = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<ResearchWindow>();
        pMaster = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();

    } // END Awake

    // Update is called once per frame
    void Update()
    {

    } // END Update

    public void ButtonSmashed()
    {

        Dictionary<rType, ResearchMain> rMasterDic = resWindow.rMaster.resDictionary;

        switch (gameObject.name)
        {
            case "ButtonAmount":
                ResearchMain researchAmount = rMasterDic[rType.Amount];
                if (resWindow.researchingStarted == false)
                {
                    if (researchAmount.currentLevel < researchAmount.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchAmount.costsMoney[researchAmount.currentLevel] && pMaster.playerResearchPoints >= researchAmount.costsResearch[researchAmount.currentLevel])
                        {
                            resWindow.currentResearchType = rType.Amount;
                            resWindow.researchTime = researchAmount.researchTime[researchAmount.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchAmount.costsMoney[researchAmount.currentLevel];
                            pMaster.playerResearchPoints -= researchAmount.costsResearch[researchAmount.currentLevel];
                        }

                    }
                }

                break;
            case "ButtonBuildCosts":
                ResearchMain researchBuildCosts = rMasterDic[rType.BuildCosts];
                if (resWindow.researchingStarted == false)
                {
                    if (researchBuildCosts.currentLevel < researchBuildCosts.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchBuildCosts.costsMoney[researchBuildCosts.currentLevel] && pMaster.playerResearchPoints >= researchBuildCosts.costsResearch[researchBuildCosts.currentLevel])
                        {
                            resWindow.currentResearchType = rType.BuildCosts;
                            resWindow.researchTime = researchBuildCosts.researchTime[researchBuildCosts.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchBuildCosts.costsMoney[researchBuildCosts.currentLevel];
                            pMaster.playerResearchPoints -= researchBuildCosts.costsResearch[researchBuildCosts.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonDrill":
                ResearchMain researchDrill = rMasterDic[rType.Drill];
                if (resWindow.researchingStarted == false)
                {
                    if (researchDrill.currentLevel < researchDrill.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchDrill.costsMoney[researchDrill.currentLevel] && pMaster.playerResearchPoints >= researchDrill.costsResearch[researchDrill.currentLevel])
                        {
                            resWindow.currentResearchType = rType.Drill;
                            resWindow.researchTime = researchDrill.researchTime[researchDrill.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchDrill.costsMoney[researchDrill.currentLevel];
                            pMaster.playerResearchPoints -= researchDrill.costsResearch[researchDrill.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonSpeed":
                ResearchMain researchSpeed = rMasterDic[rType.Speed];
                if (resWindow.researchingStarted == false)
                {
                    if (researchSpeed.currentLevel < researchSpeed.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchSpeed.costsMoney[researchSpeed.currentLevel] && pMaster.playerResearchPoints >= researchSpeed.costsResearch[researchSpeed.currentLevel])
                        {
                            resWindow.currentResearchType = rType.Speed;
                            resWindow.researchTime = researchSpeed.researchTime[researchSpeed.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchSpeed.costsMoney[researchSpeed.currentLevel];
                            pMaster.playerResearchPoints -= researchSpeed.costsResearch[researchSpeed.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonDrillPlattform":
                ResearchMain researchDrillPlattform = rMasterDic[rType.DrillingPlattform];
                if (resWindow.researchingStarted == false)
                {
                    if (researchDrillPlattform.currentLevel < researchDrillPlattform.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchDrillPlattform.costsMoney[researchDrillPlattform.currentLevel] && pMaster.playerResearchPoints >= researchDrillPlattform.costsResearch[researchDrillPlattform.currentLevel])
                        {
                            resWindow.currentResearchType = rType.DrillingPlattform;
                            resWindow.researchTime = researchDrillPlattform.researchTime[researchDrillPlattform.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchDrillPlattform.costsMoney[researchDrillPlattform.currentLevel];
                            pMaster.playerResearchPoints -= researchDrillPlattform.costsResearch[researchDrillPlattform.currentLevel];
                        }

                    }
                }
                break;
            case "ButtonScan":
                ResearchMain researchScan = rMasterDic[rType.Scan];
                if (resWindow.researchingStarted == false)
                {
                    if (researchScan.currentLevel < researchScan.maxLevel)
                    {

                        if (pMaster.playerMoney >= researchScan.costsMoney[researchScan.currentLevel] && pMaster.playerResearchPoints >= researchScan.costsResearch[researchScan.currentLevel])
                        {

                            resWindow.currentResearchType = rType.Scan;
                            resWindow.researchTime = researchScan.researchTime[researchScan.currentLevel];
                            resWindow.speicher1 = resWindow.researchTime / 100;
                            resWindow.researchingStarted = true;

                            pMaster.playerMoney -= researchScan.costsMoney[researchScan.currentLevel];
                            pMaster.playerResearchPoints -= researchScan.costsResearch[researchScan.currentLevel];
                        }

                    }
                }
                break;
        }

    }

}
