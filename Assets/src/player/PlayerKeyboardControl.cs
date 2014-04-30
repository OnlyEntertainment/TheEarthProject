using UnityEngine;
using System.Collections;

public class PlayerKeyboardControl : MonoBehaviour {

    // Research
    // variablen
    private bool showResearch = false;

    public PlayerAttributeControl pControl;
    public GameObject hintTextObject;
    public TextMesh hintText;

    public GameObject menuResearch;
    public ResearchWindow menuResearchWindow;
    // #####
    
    
    // #####

    public float timerHellGod = 0;
    public float timerHellGodSec;

	// Use this for initialization
	void Start () {
        
        pControl = gameObject.GetComponent<PlayerAttributeControl>();
        hintTextObject = GameObject.FindGameObjectWithTag("Hint");
        hintText = hintTextObject.GetComponent<TextMesh>();

        menuResearch = GameObject.FindGameObjectWithTag("MenuResearch");
        menuResearchWindow = menuResearch.GetComponent<ResearchWindow>();
        

	} // END Start
	
	// Update is called once per frame
	void Update () {




        if (Input.GetKeyDown(KeyCode.F))
        {
            menuResearchWindow.ResearchShow();
        }

        if (timerHellGod > 0)
        {
            timerHellGod -= 1 * Time.deltaTime;
        }
        else
        {
            hintText.text = "";
        }

	} // END Update


    void OnGUI()
    {
        

        //if (showResearch == false)
        //{ 
        
        //}
        //else
        //{
        //    GUI.BeginGroup(new Rect(100, 100, 600, 500));
        //    GUI.backgroundColor = Color.clear;
        //    GUI.Box(new Rect(0, 0, 600, 500), researchBackground);
        //    if (GUI.Button(new Rect(50, 100, 129, 53), new GUIContent(speed1Button, "Money: " + res1Cont.moneyCost.ToString() + "\n" + "Research: " + res1Cont.researchPointsCost.ToString())))
        //    {
                
        //        if (research1 == false)
        //        {
        //            if (res1Cont.possibleToActivate == true)
        //            {
        //                if (pControl.playerMoney >= res1Cont.moneyCost)
        //                {
        //                    research1 = true;
        //                    res1Cont.activated = true;
        //                    pControl.playerMoney -= res1Cont.moneyCost;
        //                    pControl.playerResearchPoints -= res1Cont.researchPointsCost;
        //                    res2Cont.possibleToActivate = true;
        //                    res1Cont.SendNewData();
        //                    SendMessage("You researched '" + res1Cont.researchName + "'");
        //                    pControl.research1 = true;
        //                }
        //            }
        //            else { SendMessage("Not Possible"); }
        //        }
        //        else
        //        { SendMessage("You still got it!"); }
        //    }
        //    if (GUI.Button(new Rect(50, 175, 129, 53), new GUIContent(speed2Button, "Money: " + res2Cont.moneyCost.ToString() + " " + "Research: " + res2Cont.researchPointsCost.ToString())))
        //    {
        //        if (research2 == false)
        //        {
        //            if (res2Cont.possibleToActivate == true)
        //            {
        //                if (pControl.playerMoney >= res2Cont.moneyCost)
        //                {
        //                    research2 = true;
        //                    res2Cont.activated = true;
        //                    pControl.playerMoney -= res2Cont.moneyCost;
        //                    pControl.playerResearchPoints -= res2Cont.researchPointsCost;
        //                    res3Cont.possibleToActivate = true;
        //                    res2Cont.SendNewData();
        //                    SendMessage("You researched '" + res2Cont.researchName + "'");
        //                    pControl.research2 = true;
        //                }
        //                else { SendMessage("Nope") ;}
        //            } else { SendMessage("Not Possible"); }
        //        }
        //        else { SendMessage("You still got it!"); }
        //    }
        //    if (GUI.Button(new Rect(50, 250, 129, 53), new GUIContent(speed3Button, "Money: " + res3Cont.moneyCost.ToString() + " " + "Research: " + res3Cont.researchPointsCost.ToString())))
        //    {
        //        if (research3 == false)
        //        {
        //            if (res3Cont.possibleToActivate == true)
        //            {
        //                if (pControl.playerMoney >= res3Cont.moneyCost)
        //                {
        //                    research3 = true;
        //                    res3Cont.activated = true;
        //                    pControl.playerMoney -= res3Cont.moneyCost;
        //                    pControl.playerResearchPoints -= res3Cont.researchPointsCost;
        //                    res3Cont.SendNewData();
        //                    SendMessage("You researched '" + res3Cont.researchName + "'");
        //                    pControl.research3 = true;
        //                }
        //                else { SendMessage("Nope"); }
        //            }
        //            else { SendMessage("Not Possible"); }
        //        }
        //        else { SendMessage("You still got it!"); }
        //    }
        //    if (GUI.Button(new Rect(180, 100, 129, 53), new GUIContent(amount1Button, "Money: " + res4Cont.moneyCost.ToString() + " " + "Research: " + res4Cont.researchPointsCost.ToString())))
        //    {
        //        if (research4 == false)
        //        {
        //            if (res4Cont.possibleToActivate == true)
        //            {
        //                if (pControl.playerMoney >= res4Cont.moneyCost)
        //                {
        //                    research4 = true;
        //                    res4Cont.activated = true;
        //                    pControl.playerMoney -= res4Cont.moneyCost;
        //                    pControl.playerResearchPoints -= res4Cont.researchPointsCost;
        //                    res5Cont.possibleToActivate = true;
        //                    res4Cont.SendNewData();
        //                    SendMessage("You researched '" + res4Cont.researchName + "'");
        //                    pControl.research4 = true;
        //                }
        //                else { SendMessage("Nope"); }
        //            }
        //            else { SendMessage("Not Possible"); }
        //        }
        //        else
        //        { SendMessage("You still got it!"); }
        //    }
        //    if (GUI.Button(new Rect(180, 175, 129, 53), new GUIContent(amount2Button, "Money: " + res5Cont.moneyCost.ToString() + " " + "Research: " + res5Cont.researchPointsCost.ToString())))
        //    {
        //        if (research5 == false)
        //        {
        //            if (res5Cont.possibleToActivate == true)
        //            {
        //                if (pControl.playerMoney >= res5Cont.moneyCost)
        //                {
        //                    research5 = true;
        //                    res5Cont.activated = true;
        //                    pControl.playerMoney -= res5Cont.moneyCost;
        //                    pControl.playerResearchPoints -= res5Cont.researchPointsCost;
        //                    res5Cont.SendNewData();
        //                    SendMessage("You researched '" + res5Cont.researchName + "'");
        //                    pControl.research5 = true;
        //                }
        //                else { SendMessage("Nope"); }
        //            }
        //            else { SendMessage("Not Possible"); }
        //        }
        //        else { SendMessage("You still got it!"); }
        //    }
        //    GUI.Label(new Rect(25, 255, 100, 100), GUI.tooltip, Camera.main.GetComponent<ShowingStuff>().textStyle);
        //    GUI.EndGroup();
            
        //}

        
    } // END OnGUI

    public void SendMessage(string message)
    {
        timerHellGod = 5f;
            hintText.text = message;

    } // END SendMessage


}
