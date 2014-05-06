using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameTime : MonoBehaviour {


    public float standardDayTime = 2f;
    public float currentDayTime = 0f;


    public DateTime date = new DateTime(2000, 1,1);

	// Use this for initialization
	void Start () 
    {
        currentDayTime = standardDayTime;



	} // END Start
	
	// Update is called once per frame
	void Update () 
    {




        if(currentDayTime > 0)
        {

            currentDayTime -= 1 * Time.deltaTime;

        }
        else
        {

            date = date.AddDays(1d);
            currentDayTime = standardDayTime;
        }


        


	} // END Update


    void OnGUI()
    {

        GUI.Label(new Rect(0, 0, 100, 30), date.Day + "." + date.Month + "." + date.Year);
    }

}
