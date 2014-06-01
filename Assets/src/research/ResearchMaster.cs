using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using rType = ResearchMain.rType;

public class ResearchMaster : MonoBehaviour {


    public Dictionary<rType, ResearchMain> researchDictionary;

	// Use this for initialization
	void Awake () {

        researchDictionary = ResearchMain.GenerateResearch();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SetUpgrade(rType researchType)
    { 
        

        switch(researchType)
        {
            case rType.Speed:

                researchDictionary[rType.Speed].currentLevel++;

                break;
            case rType.Amount:

                researchDictionary[rType.Amount].currentLevel++;

                break;
            case rType.Drill:

                researchDictionary[rType.Drill].currentLevel++;

                break;
            case rType.DrillingPlattform:

                researchDictionary[rType.DrillingPlattform].currentLevel++;

                break;
            case rType.BuildCosts:

                researchDictionary[rType.BuildCosts].currentLevel++;

                break;
            case rType.Scan:

                researchDictionary[rType.Scan].currentLevel++;

                break;
        }



    }
}
