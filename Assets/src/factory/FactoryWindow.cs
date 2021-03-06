﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;
using sondenArten = BuildingInterface.SONDENART;

public class FactoryWindow : MonoBehaviour
{

    // Standard
    public bool showFactory = true;

    // Factory
    // Allgemein
    public int costsAmount = 0;
    public StorageWindow storageWindowData;

    // Factory
    // Drill
    public DrillMaster drillMasterData;
    public Dictionary<bohrerArten, DrillMain> drillDictionary;
    public int drillCurrentShownType = 0;
    public int drillAmount = 0;
    public UILabel drillLabelType;
    public UILabel drillLabelValue;

    // Factory
    // Scan
    public ScanMaster scanMasterData;
    public Dictionary<sondenArten, ScanMain> scanDictionary;
    public int scanCurrentShownType = 0;
    public int scanAmount = 0;
    public UILabel scanLabelType;
    public UILabel scanLabelValue;

    // Factory
    // Pipes
    public int pipesAmount = 0;
    public int pipesPrice = 150;      // Baukosten pro Stück
    public float pipesTime = 5f;     // Bauzeit
    public UILabel pipesValue;

    // Links
    public GameObject factoryWindowMenuObject;

    // Label
    public UILabel costsValue;

    // ProgressBar
    public UISlider progressSlider;
    public float progressTime = 0f;



    // Warteliste
    public TaskWaitListWindow taskWaitListWindowData;
    public GameObject taskWindowObject;
    public bool taskStarted = false;
    public int currentTaskAmount = 0;
    public float currentTaskProgessTime = 0f;
    public string currentTaskType = "";
    public float taskResult = 0f;
    public float speicher1 = 0f;
    public bool taskListShow = true;
    public GameObject getLabelPrefab;


    // Use this for initialization
    void Start()
    {



        factoryWindowMenuObject = GameObject.FindGameObjectWithTag("MenuFactory");
        taskWindowObject = factoryWindowMenuObject.transform.FindChild("TaskListWindow").gameObject;
        storageWindowData = GetComponent<StorageWindow>();
        drillMasterData = GetComponent<DrillMaster>();
        scanMasterData = GetComponent<ScanMaster>();
        taskWaitListWindowData = GetComponent<TaskWaitListWindow>();
        drillDictionary = drillMasterData.drillDictionary;
        scanDictionary = scanMasterData.scanDictionary;
        progressSlider = factoryWindowMenuObject.transform.FindChild("ProgressBarBuild").gameObject.GetComponent<UISlider>();

        GameObject drillDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("DrillData").gameObject;
        drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        drillLabelValue = drillDataObject.transform.FindChild("LabelDrillValue").gameObject.GetComponent<UILabel>();

        GameObject scanDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("ScanData").gameObject;
        scanLabelType = scanDataObject.transform.FindChild("LabelScanType").gameObject.GetComponent<UILabel>();
        scanLabelValue = scanDataObject.transform.FindChild("LabelScanValue").gameObject.GetComponent<UILabel>();

        GameObject pipesDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("PipesData").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        pipesValue = pipesDataObject.transform.FindChild("LabelPipesValue").gameObject.GetComponent<UILabel>();

        GameObject kostenDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("LabelKosten").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        costsValue = kostenDataObject.transform.FindChild("LabelKostenValue").gameObject.GetComponent<UILabel>();

        FactoryShow();
        FactoryWindowReload();
    } // END Start

    // Update is called once per frame
    void Update()
    {

        if (taskStarted == true)
        {
            if (progressTime > 0f && currentTaskAmount > 0)
            {



                progressTime -= 1 * Time.deltaTime;

                taskResult = (1 - ((progressTime / speicher1) / 100));


                progressSlider.value = taskResult;
                FactoryWindowReload();




            }
            else
            {

                if (currentTaskAmount > 0)
                {
                    currentTaskAmount--;
                    progressTime = currentTaskProgessTime;
                    storageWindowData.SetMaterialWindowDataUp(currentTaskType, 1);
                }
                else
                {
                    taskStarted = false;
                    //stoWindow.SetMaterialWindowDataUp(currentTaskType, 1);
                    taskWaitListWindowData.DeleteTasks();

                }

            }
        }

        
        FactoryWindowReload();
    } // END Update

    public void SetCurrentTask(string productType, int amount)
    {


        if (productType == "Standard")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Standard].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Eisen")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Eisen].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Stahl")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Stahl].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Chrom")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Chrom].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Titan")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Titan].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Diamant")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDictionary[bohrerArten.Diamant].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Starter Kit")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Starterkit].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Schwach")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Schwach].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Klein")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Klein].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Mittel")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Mittel].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Groß")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Groß].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Stark")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDictionary[sondenArten.Stark].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Pipes")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = pipesTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }

    } // END SetCurrentTask


    public void FactoryShow()
    {

        if (showFactory == false)
        {
            showFactory = true;
            factoryWindowMenuObject.SetActive(true);
            taskListShow = false;
            taskWindowObject.SetActive(false);

            FactoryWindowReload();
        }
        else
        {
            showFactory = false;
            factoryWindowMenuObject.SetActive(false);

            taskListShow = false;
            taskWindowObject.SetActive(false);
        }



    } // END FactoryShow

    void FactoryWindowReload()
    {

        switch (drillCurrentShownType)
        {
            case 0:
                drillLabelType.text = drillDictionary[bohrerArten.Standard].drillName;
                break;
            case 1:
                drillLabelType.text = drillDictionary[bohrerArten.Eisen].drillName;
                break;
            case 2:
                drillLabelType.text = drillDictionary[bohrerArten.Stahl].drillName;
                break;
            case 3:
                drillLabelType.text = drillDictionary[bohrerArten.Chrom].drillName;
                break;
            case 4:
                drillLabelType.text = drillDictionary[bohrerArten.Titan].drillName;
                break;
            case 5:
                drillLabelType.text = drillDictionary[bohrerArten.Diamant].drillName;
                break;
        } // DrillLabelType

        drillLabelValue.text = drillAmount.ToString();



        switch (scanCurrentShownType)
        {
            case 0:
                scanLabelType.text = scanDictionary[sondenArten.Starterkit].scanName;
                break;
            case 1:
                scanLabelType.text = scanDictionary[sondenArten.Schwach].scanName;
                break;
            case 2:
                scanLabelType.text = scanDictionary[sondenArten.Klein].scanName;
                break;
            case 3:
                scanLabelType.text = scanDictionary[sondenArten.Mittel].scanName;
                break;
            case 4:
                scanLabelType.text = scanDictionary[sondenArten.Groß].scanName;
                break;
            case 5:
                scanLabelType.text = scanDictionary[sondenArten.Stark].scanName;
                break;
        } // ScanLabelType

        scanLabelValue.text = scanAmount.ToString();

        pipesValue.text = pipesAmount.ToString();

        CostsReload();
        costsValue.text = costsAmount.ToString();



        taskWindowObject.SetActive(taskListShow);


    } // END FactoryWindowReload

    void CostsReload()
    {


        int drillCosts = drillDictionary[GetBohrerArtByString(drillLabelType.text)].costsMoney * drillAmount;
        int scanCosts = scanDictionary[GetSondenArtByString(scanLabelType.text)].costsMoney * scanAmount;
        int pipesCosts = pipesPrice * pipesAmount;

        costsAmount = drillCosts + scanCosts + pipesCosts;
    } // END CostsReload

    private bohrerArten GetBohrerArtByString(string enumString)
    {
        for (int i = 0; i < Enum.GetNames(typeof(bohrerArten)).Length; i++)
        {
            if (((bohrerArten)i).ToString() == enumString) { return (bohrerArten)i; }
        }
        return (bohrerArten)0;
    } // END GetBohrerArtByString

    private sondenArten GetSondenArtByString(string enumString)
    {
        for (int i = 0; i < Enum.GetNames(typeof(sondenArten)).Length; i++)
        {
            if (((sondenArten)i).ToString() == enumString) { return (sondenArten)i; }
        }
        return (sondenArten)0;
    } // END GetSondenArtByString

    public void OpenTaskListWindow()
    {

        if (taskListShow == false)
        {

            taskListShow = true;
            taskWindowObject.SetActive(taskListShow);
            taskWaitListWindowData.TaskListShowed();
        }
        else
        {
            taskListShow = false;
            taskWindowObject.SetActive(taskListShow);
        }


    }

}
