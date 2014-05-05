using UnityEngine;
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

    // Factory
    // Drill
    public DrillMaster dMaster;
    public Dictionary<bohrerArten, DrillMain> drillDic;
    public int drillCurrentShownType = 0;
    public int drillAmount = 0;
    public UILabel drillLabelType;
    public UILabel drillLabelValue;

    // Factory
    // Scan
    public ScanMaster sMaster;
    public Dictionary<sondenArten, ScanMain> scanDic;
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
    public GameObject factoryWindowMenu;

    // Label
    public UILabel costsValue;

    // ProgressBar
    public UISlider progressSlider;
    public float progressTime = 0f;



    // Warteliste
    public TaskWaitListWindow taskWindow;
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



        factoryWindowMenu = GameObject.FindGameObjectWithTag("MenuFactory");
        taskWindowObject = factoryWindowMenu.transform.FindChild("TaskListWindow").gameObject;
        dMaster = GetComponent<DrillMaster>();
        sMaster = GetComponent<ScanMaster>();
        taskWindow = GetComponent<TaskWaitListWindow>();
        drillDic = dMaster.drillDictionary;
        scanDic = sMaster.scanDictionary;
        progressSlider = factoryWindowMenu.transform.FindChild("ProgressBarBuild").gameObject.GetComponent<UISlider>();

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
                }
                else
                {
                    taskStarted = false;
                    taskWindow.DeleteTasks();

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
            currentTaskProgessTime = drillDic[bohrerArten.Standard].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Eisen")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDic[bohrerArten.Eisen].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Stahl")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDic[bohrerArten.Stahl].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Chrom")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDic[bohrerArten.Chrom].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Titan")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDic[bohrerArten.Titan].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Diamant")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = drillDic[bohrerArten.Diamant].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Starter Kit")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Starterkit].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Schwach")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Schwach].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Klein")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Klein].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Mittel")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Mittel].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Groß")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Groß].buildTime;
            progressTime = currentTaskProgessTime;
            speicher1 = progressTime / 100;
            taskStarted = true;
        }
        else if (productType == "Stark")
        {

            currentTaskAmount = amount;
            currentTaskType = productType;
            currentTaskProgessTime = scanDic[sondenArten.Stark].buildTime;
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
            factoryWindowMenu.SetActive(true);
            taskListShow = false;
            taskWindowObject.SetActive(false);

            FactoryWindowReload();
        }
        else
        {
            showFactory = false;
            factoryWindowMenu.SetActive(false);

            taskListShow = false;
            taskWindowObject.SetActive(false);
        }



    } // END FactoryShow

    void FactoryWindowReload()
    {

        switch (drillCurrentShownType)
        {
            case 0:
                drillLabelType.text = drillDic[bohrerArten.Standard].drillName;
                break;
            case 1:
                drillLabelType.text = drillDic[bohrerArten.Eisen].drillName;
                break;
            case 2:
                drillLabelType.text = drillDic[bohrerArten.Stahl].drillName;
                break;
            case 3:
                drillLabelType.text = drillDic[bohrerArten.Chrom].drillName;
                break;
            case 4:
                drillLabelType.text = drillDic[bohrerArten.Titan].drillName;
                break;
            case 5:
                drillLabelType.text = drillDic[bohrerArten.Diamant].drillName;
                break;
        } // DrillLabelType

        drillLabelValue.text = drillAmount.ToString();



        switch (scanCurrentShownType)
        {
            case 0:
                scanLabelType.text = scanDic[sondenArten.Starterkit].scanName;
                break;
            case 1:
                scanLabelType.text = scanDic[sondenArten.Schwach].scanName;
                break;
            case 2:
                scanLabelType.text = scanDic[sondenArten.Klein].scanName;
                break;
            case 3:
                scanLabelType.text = scanDic[sondenArten.Mittel].scanName;
                break;
            case 4:
                scanLabelType.text = scanDic[sondenArten.Groß].scanName;
                break;
            case 5:
                scanLabelType.text = scanDic[sondenArten.Stark].scanName;
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


        int drillCosts = drillDic[GetBohrerArtByString(drillLabelType.text)].costsMoney * drillAmount;
        int scanCosts = scanDic[GetSondenArtByString(scanLabelType.text)].costsMoney * scanAmount;
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
        }
        else
        {
            taskListShow = false;
            taskWindowObject.SetActive(taskListShow);
        }


    }

}
