using UnityEngine;
using System.Collections;

public class CheatConsole : MonoBehaviour {
    
    //Variablen
    // Player
    public GameObject pObject;
    public PlayerAttributeControl pControl;
    public PlayerKeyboardControl pKeyControl;
    // Camera
    public GameObject camObject;
    public ShowingStuff cShowingStuff;

    //

    public float timeIs = 3f;

	// Use this for initialization
	void Start () {

        pObject = GameObject.Find("01_Player");
        pControl = pObject.GetComponent<PlayerAttributeControl>();
        pKeyControl = pObject.GetComponent<PlayerKeyboardControl>();


        camObject = GameObject.Find("00_MainCamera");
        cShowingStuff = camObject.GetComponent<ShowingStuff>();


	}
	
	// Update is called once per frame
	void Update () {

        
        



	}


    void OnGUI()
    {
        GUI.BeginGroup(new Rect(600,65,100,300));

            if(GUI.Button(new Rect(10,10,80,20), "Buy Drill"))
            {

                BuyNewDrill();


            }
            if(GUI.Button(new Rect(10,40,80,20), "Sell"))
            {
                SellMaterial();
            }

            if (GUI.Button(new Rect(10, 70, 80, 20), "Buy Res.P."))
            {
                BuyLabPoints();
            }

        GUI.EndGroup();


        GUI.Label(new Rect(Screen.width - 150, 10, 150, 30), "Time: " + timeIs);


    }


    void BuyNewDrill()
    {
        int result = 1;

        if(pControl.playerMoney >= 750)
        {

            cShowingStuff.buildingsCount += result;
            pControl.playerMoney -= 750;
        }
        else
        { pKeyControl.SendMessage("Cost 750 Money, you dont have that"); }


    }

    void WorkTime()
    {
        int result = 0;


        result = (int)((cShowingStuff.buildingsCount * 3) * pControl.gettingMaterialAmount);
        cShowingStuff.mass += result;
        
    }

    void SellMaterial()
    {
        int result = 0;



        result = (int)(cShowingStuff.mass * 10);
        cShowingStuff.mass = 0;

        pControl.playerMoney += result;

    }

    void BuyLabPoints()
    {
        int result = 0;

        if (pControl.playerMoney >= 500)
        {
            result = 10;
            pControl.playerResearchPoints += result;
            pControl.playerMoney -= 500;
        }
        else { pKeyControl.SendMessage("Not enough money, need 500");  }
    }


}
