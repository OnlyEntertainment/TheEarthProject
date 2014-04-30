using UnityEngine;
using System.Collections;

public class PlayerAttributeControl : MonoBehaviour {

    // Variablen
    public int playerMoney = 0;                     // Menge an Geld des Spielers
    public int playerResearchPoints = 0;                 // Menge an Labor/Forschungspunkten des Spielers

    GameObject moneyGameObject;
    GameObject researchPointsGameObject;

    public TextMesh moneyTextMesh;
    public TextMesh researchPointsTextMesh;

    // +++++++
    // Research

    public bool research1 = false;
    public bool research2 = false;
    public bool research3 = false;
    public bool research4 = false;
    public bool research5 = false;
    

    // +++++++

    public float gettingMaterialSpeed = 1.0f;
    public float gettingMaterialAmount = 1.0f;

	// Use this for initialization
	void Start () 
    {

        moneyGameObject = GameObject.FindGameObjectWithTag("Money");
        moneyTextMesh = moneyGameObject.GetComponent<TextMesh>();

        researchPointsGameObject = GameObject.FindGameObjectWithTag("LaborPoints");
        researchPointsTextMesh = researchPointsGameObject.GetComponent<TextMesh>();


	} // END Start
	
	// Update is called once per frame
	void Update () 
    {

        ResearchPointsLoop();
        MoneyLoop();


	} // END Update



    void MoneyLoop()
    {
        moneyTextMesh.text = "Money: " + playerMoney.ToString();
    } // END MoneyLoop


    void ResearchPointsLoop()
    {
        researchPointsTextMesh.text = "LabPoints: " + playerResearchPoints.ToString();
    } // END ResearchPointsLoop



    void ResearchLoop()
    { 
        



    }

    void SetNewGettingMaterialSpeed(float newGettingMaterialSpeed)
    {
        gettingMaterialSpeed = newGettingMaterialSpeed;
        
    }

    void GetNewGettingMaterialSpeed(float newGettingMaterialSpeed)
    {

        if (newGettingMaterialSpeed > gettingMaterialSpeed)
        {
            SetNewGettingMaterialSpeed(newGettingMaterialSpeed);
        }
        else { }
    }


} // END END
