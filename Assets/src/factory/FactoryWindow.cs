using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;

public class FactoryWindow : MonoBehaviour {


    // Standard
    public bool showFactory = true;


    // Factory
    public Dictionary<bohrerArten, DrillMain> drillDic;

    public int drillAmount = 0;
    public int scanAmount = 0;
    public int pipesAmount = 0;

    public int costsAmount = 0;

    // Links
    public GameObject factoryWindowMenu;
    public DrillMaster dMaster;

    // Label
    public UILabel drillLabelType;
    public UILabel drillLabelValue;
    public UILabel scanLabelType;
    public UILabel scanLabelValue;
    public UILabel pipesValue;

    public UILabel costsValue;


	// Use this for initialization
	void Start () {


        

        factoryWindowMenu = GameObject.FindGameObjectWithTag("MenuFactory");
        dMaster = GetComponent<DrillMaster>();
        drillDic = dMaster.drillDictionary;

        GameObject drillDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("DrillData").gameObject;
        drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        drillLabelValue = drillDataObject.transform.FindChild("LabelDrillValue").gameObject.GetComponent<UILabel>();

        GameObject scanDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("ScanData").gameObject;
        scanLabelType = scanDataObject.transform.FindChild("LabelScanType").gameObject.GetComponent<UILabel>();
        scanLabelValue = scanDataObject.transform.FindChild("LabelScanValue").gameObject.GetComponent<UILabel>();

        GameObject pipesDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("PipesData").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        pipesValue = pipesDataObject.transform.FindChild("LabelPipesValue").gameObject.GetComponent<UILabel>();

        GameObject kostenDataObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("LabelKostenValue").gameObject;
        //drillLabelType = drillDataObject.transform.FindChild("LabelDrillType").gameObject.GetComponent<UILabel>();
        costsValue = kostenDataObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void FactoryShow()
    {

        if (showFactory == false)
        {
            showFactory = true;
            factoryWindowMenu.SetActive(true);

            FactoryWindowReload();
        }
        else
        {
            showFactory = false;
            factoryWindowMenu.SetActive(false);
        }



    } // END FactoryShow

    void FactoryWindowReload()
    {


    }
}
