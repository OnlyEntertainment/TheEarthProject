using UnityEngine;
using System.Collections;

public class ResearchControl : MonoBehaviour {

    // Variablen
    public string researchName;
    public string researchType;
    public int moneyCost;
    public int researchPointsCost;
    public float actValue;

    public bool possibleToActivate = false;
    public bool activated = false;

    public GameObject playerObject;
    public PlayerAttributeControl playerControl;



	// Use this for initialization
	void Start () {

        playerObject = GameObject.Find("01_Player");
        playerControl = playerObject.GetComponent<PlayerAttributeControl>();

        this.name = "05_" + researchName;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetAttributes(string newName, string newResearchType, int costMoney, int costResearchPoints, float newActValue, bool newPosActivate, bool newActivated)
    {

        researchName = newName;
        researchType = newResearchType;
        moneyCost = costMoney;
        researchPointsCost = costResearchPoints;
        actValue = newActValue;
        possibleToActivate = newPosActivate;
        activated = newActivated;

    } // END SetAttributes

    public void SendNewData()
    {
        if (researchType == "Speed")
        {
            
            playerControl.researchDrillingSpeed = actValue;
        }
        else { playerControl.researchDrillingAmount = actValue; }
    }

}
