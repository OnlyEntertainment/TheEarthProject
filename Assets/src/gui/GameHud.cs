using UnityEngine;
using System.Collections;

public class GameHud : MonoBehaviour {

    public GameObject playerObject;
    public PlayerAttributeControl pAttributeControl;

    public GameObject labelMoneyObject;
    public GameObject labelRpObject;
    public UILabel labelMoneyLabel;
    public UILabel labelRpLabel;

	// Use this for initialization
	void Start () {

        playerObject = GameObject.Find("01_Player");
        pAttributeControl = playerObject.GetComponent<PlayerAttributeControl>();

        labelMoneyObject = GameObject.FindGameObjectWithTag("Money");
        labelRpObject = GameObject.FindGameObjectWithTag("Research");

        labelMoneyLabel = labelMoneyObject.GetComponent<UILabel>();
        labelRpLabel = labelRpObject.GetComponent<UILabel>();


	}
	
	// Update is called once per frame
	void Update () {


        HudAnzeige();
	}


    void HudAnzeige()
    {

        labelMoneyLabel.text = "Money: " + pAttributeControl.playerMoney;
        labelRpLabel.text = "ResPoi: " + pAttributeControl.playerResearchPoints;

    }

}
