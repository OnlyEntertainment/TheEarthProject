using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartLoop : MonoBehaviour {

    // Variablen
    //---------
    // Research

    public GameObject researchPrefab;
    public string[,] researchArray = new string[5, 7];


    public int i;

	// Use this for initialization
	void Start () {

        Researching();
        GenerateResearch();
        GameObject.Destroy(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Researching()
    {

        researchArray[0, 0] = "Speed L2";
        researchArray[0, 1] = "Speed";
        researchArray[0, 2] = "100";
        researchArray[0, 3] = "0";
        researchArray[0, 4] = "1.25";
        researchArray[0, 5] = "yes";
        researchArray[0, 6] = "no";

        researchArray[1, 0] = "Speed L3";
        researchArray[1, 1] = "Speed";
        researchArray[1, 2] = "250";
        researchArray[1, 3] = "10";
        researchArray[1, 4] = "1.50";
        researchArray[1, 5] = "no";
        researchArray[1, 6] = "no";

        researchArray[2, 0] = "Speed L4";
        researchArray[2, 1] = "Speed";
        researchArray[2, 2] = "500";
        researchArray[2, 3] = "30";
        researchArray[2, 4] = "1.75";
        researchArray[2, 5] = "no";
        researchArray[2, 6] = "no";

        researchArray[3, 0] = "Amount L2";
        researchArray[3, 1] = "Amount";
        researchArray[3, 2] = "100";
        researchArray[3, 3] = "0";
        researchArray[3, 4] = "1.25";
        researchArray[3, 5] = "yes";
        researchArray[3, 6] = "no";

        researchArray[4, 0] = "Amount L3";
        researchArray[4, 1] = "Amount";
        researchArray[4, 2] = "175";
        researchArray[4, 3] = "10";
        researchArray[4, 4] = "1.50";
        researchArray[4, 5] = "no";
        researchArray[4, 6] = "no";

    }

    void GenerateResearch()
    {

        i = researchArray.GetLength(0);

        for (int countTheLoop = 0; countTheLoop < i; countTheLoop++)
        {
            //GameObject.Instantiate(researchPrefab);
            GameObject newObject = (GameObject)GameObject.Instantiate(researchPrefab, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            ResearchControl rControl = newObject.GetComponent<ResearchControl>();

            rControl.researchName = researchArray[countTheLoop, 0];

            rControl.researchType = researchArray[countTheLoop, 1];

            string middle = researchArray[countTheLoop, 2];
            rControl.moneyCost = int.Parse(middle);

            middle = researchArray[countTheLoop, 3];
            rControl.researchPointsCost = int.Parse(middle);

            middle = researchArray[countTheLoop, 4];
            rControl.actValue = float.Parse(middle);

            middle = researchArray[countTheLoop, 5];
            if (middle == "yes")
            { rControl.possibleToActivate = true; }
            else
            { rControl.possibleToActivate = false; }

            middle = researchArray[countTheLoop, 6];
            if (middle == "yes")
            { rControl.activated = true; }
            else
            { rControl.activated = false; }
            Debug.Log(countTheLoop);
        }

        Debug.Log("wuche");

    }

}
