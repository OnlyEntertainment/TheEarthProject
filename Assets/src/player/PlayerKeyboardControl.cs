﻿using UnityEngine;
using System.Collections;

public class PlayerKeyboardControl : MonoBehaviour {

    // Research
    // variablen
    private bool showResearch = false;

    public PlayerAttributeControl pControl;

    public GameObject menuResearch;
    public ResearchWindow menuResearchWindow;
    // #####
    
    
    // #####

    public float timerHellGod = 0;
    public float timerHellGodSec;

	// Use this for initialization
	void Start () {
        
        pControl = gameObject.GetComponent<PlayerAttributeControl>();

        menuResearch = GameObject.Find("00_GuiStuff");
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
            
        }

	} // END Update


    public void SendMessage(string message)
    {
        timerHellGod = 5f;
            

    } // END SendMessage


}
