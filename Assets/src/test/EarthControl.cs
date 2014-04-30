using UnityEngine;
using System.Collections;
using System;


public class EarthControl : MonoBehaviour {

    // Variablen

    public GameObject cellObject;

    public int cellNumber = 0;
    public int cellX = 0;
    public int cellY = 0;


    public System.Random rnd = new System.Random();


	// Use this for initialization
	void Start () 
    {

        if (cellNumber == 100)
        {

        }
        else
        {

            GenerateGrid();

        }



	} // END Start
	
	// Update is called once per frame
	void Update () 
    {





	} // END Update

    void GenerateGrid()
    { 
        
        for (int counterX = 0; counterX < 10; counterX++)
        {
            for (int counterY = 0; counterY < 10; counterY++)
            {
                cellX = counterX;
                cellY = counterY;

                cellNumber++;

                int rowCellType = rnd.Next(0, 7);
                GameObject gObject =  (GameObject)GameObject.Instantiate(cellObject, new Vector3(0.5f * counterX, 0.5f * counterY, 0), new Quaternion(0f, 0f, 0f, 0f));
                
                CellControl gObjectCellControl = gObject.GetComponentInChildren<CellControl>();
                //gObjectCellControl.cellType = rowCellType;
                //gObjectCellControl.row = counterY;
                //gObjectCellControl.cellNumber = cellNumber;

            }


        }

    }



}
