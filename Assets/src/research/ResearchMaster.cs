using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchMaster : MonoBehaviour {


    public Dictionary<rType, ResearchMain> resDictionary;

	// Use this for initialization
	void Awake () {

        resDictionary = ResearchMain.GenerateResearch();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SetUpgrade(rType researchType)
    { 
        

        switch(researchType)
        {
            case rType.Speed:

                resDictionary[rType.Speed].currentLevel++;

                break;
            case rType.Amount:

                resDictionary[rType.Amount].currentLevel++;

                break;
            case rType.Drill:

                resDictionary[rType.Drill].currentLevel++;

                break;
            case rType.DrillingPlattform:

                resDictionary[rType.DrillingPlattform].currentLevel++;

                break;
            case rType.BuildCosts:

                resDictionary[rType.BuildCosts].currentLevel++;

                break;
            case rType.Scan:

                resDictionary[rType.Scan].currentLevel++;

                break;
        }



    }
}
