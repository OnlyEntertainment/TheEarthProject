using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchWindow : MonoBehaviour {

    // Allgemein
    public GameObject hintTextObject;
    public TextMesh hintText;
    public ResearchMaster rMaster;
    public TextMesh tmResearchButtonText;


    // Research
    public bool showResearch = false;
    public int researchTypeCount;



    // Grafiken
    public Texture2D researchButtonDefault;
    public Texture2D researchBackground;
    public GUIStyle researchStyle;
    public GameObject researchButtonText;
    public List<GameObject> pLResearchButtonText;



    // ###########################
	// Use this for initialization
	void Start () {

        rMaster = this.GetComponent<ResearchMaster>();
        researchTypeCount = rMaster.resDictionary.Count;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnGUI()
    { 
    
        if(showResearch == true)
        {

            GUI.backgroundColor = Color.clear;
            GUI.BeginGroup(new Rect(0, 0, 600, 500));
            GUI.Box(new Rect(0, 0, 600, 500), researchBackground);

            if(GUI.Button(new Rect(0,0,130,55), researchButtonDefault))
            { }

            if (GUI.Button(new Rect(0, 70, 130, 55), researchButtonDefault))
            { }

            if (GUI.Button(new Rect(0, 140, 130, 55), researchButtonDefault))
            { }

            if (GUI.Button(new Rect(0, 210, 130, 55), researchButtonDefault))
            { }

            if (GUI.Button(new Rect(0, 280, 130, 55), researchButtonDefault))
            { }


            GUI.EndGroup();
            Debug.Log("juchu");
        }
        else
        { Debug.Log("hmpf"); }


    } // END OnGUI

    public void ResearchShow()
    {

        if(showResearch == false) { showResearch = true; } else { showResearch = false; }


    } // END ResearchShow



    void FillResearchText()
    {

        if(showResearch == true)
        {

            for (int i = 1; i > researchTypeCount; i++)
            {
                pLResearchButtonText.Add(researchButtonText);

                GUI.Button(new Rect(0, 0, 0, 0), "");
                
                tmResearchButtonText = pLResearchButtonText[i].GetComponent<TextMesh>();


                tmResearchButtonText.text = rMaster.resDictionary[(i - 1)].researchTitle + "-" + rMaster.resDictionary[(i-1)].currentLevel;
                tmResearchButtonText.transform.position = new Vector3(0f, 0f, 0f);
            }




        }

    } // END FillResearchText


}
