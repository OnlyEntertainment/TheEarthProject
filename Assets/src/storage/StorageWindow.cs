using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bodenArten = CellControl.BODENARTEN;

public class StorageWindow : MonoBehaviour
{

    public bool showStorage = true;
    public StorageMaster stoMaster;

    public GameObject storageWindowMenu;


    public enum MaterialType { Cole, Oil, Ore, Gold, Diamond };
    public MaterialType mType;

    public int maxStorageValue = 1000;
    public int currentStorageValue = 0;

    public Dictionary<bodenArten, int> bodenData = new Dictionary<bodenArten, int>();


    // Grafiken
    public UILabel maxStorageLabel;
    public UILabel curStorageLabel;

    public UILabel coleLabelValue;
    public UILabel oreLabelValue;
    public UILabel goldLabelValue;
    public UILabel oilLabelValue;
    public UILabel diamondLabelValue;

    // Use this for initialization
    void Start()
    {

        FillDictionary();

        stoMaster = this.GetComponent<StorageMaster>();

        GameObject storageWindowDataObject = transform.FindChild("StorageWindowData").gameObject;
        maxStorageLabel = storageWindowDataObject.transform.FindChild("LabelMaxStorage").gameObject.transform.FindChild("LabelMaxStorageValue").gameObject.GetComponent<UILabel>();
        curStorageLabel = storageWindowDataObject.transform.FindChild("LabelCurrentStorage").gameObject.transform.FindChild("LabelCurrentStorageValue").gameObject.GetComponent<UILabel>();

        coleLabelValue = storageWindowDataObject.transform.FindChild("LabelCole").gameObject.transform.FindChild("LabelColeValue").gameObject.GetComponent<UILabel>();
        oreLabelValue = storageWindowDataObject.transform.FindChild("LabelOre").gameObject.transform.FindChild("LabelOreValue").gameObject.GetComponent<UILabel>();
        goldLabelValue = storageWindowDataObject.transform.FindChild("LabelGold").gameObject.transform.FindChild("LabelGoldValue").gameObject.GetComponent<UILabel>();
        oilLabelValue = storageWindowDataObject.transform.FindChild("LabelOil").gameObject.transform.FindChild("LabelOilValue").gameObject.GetComponent<UILabel>();
        diamondLabelValue = storageWindowDataObject.transform.FindChild("LabelDiamond").gameObject.transform.FindChild("LabelDiamondValue").gameObject.GetComponent<UILabel>();


        storageWindowMenu = GameObject.FindGameObjectWithTag("MenuStorage");

        StorageShow();
    } // END Start

    // Update is called once per frame
    void Update()
    {

        RecheckCurrentStorageValue();
        ReloadStorageDataInWindow();

    } // END Update


    void FillDictionary()
    {

        bodenData.Add(bodenArten.Kohle, 10);
        bodenData.Add(bodenArten.Erz, 20);
        bodenData.Add(bodenArten.Oel, 30);
        bodenData.Add(bodenArten.Gold, 40);
        bodenData.Add(bodenArten.Diamant, 50);
    } // END FillDictionary

    void ReloadStorageDataInWindow()
    {

        maxStorageLabel.text = maxStorageValue.ToString();
        curStorageLabel.text = currentStorageValue.ToString();

        coleLabelValue.text = bodenData[bodenArten.Kohle].ToString();
        oreLabelValue.text = bodenData[bodenArten.Erz].ToString();
        goldLabelValue.text = bodenData[bodenArten.Gold].ToString();
        oilLabelValue.text = bodenData[bodenArten.Oel].ToString();
        diamondLabelValue.text = bodenData[bodenArten.Diamant].ToString();


    } // END ReloadStorageDataInWindow

    public void StorageShow()
    {

        if (showStorage == false)
        {
            showStorage = true;
            storageWindowMenu.SetActive(true);

            
            ReloadStorageDataInWindow();
        }
        else
        {
            showStorage = false;
            storageWindowMenu.SetActive(false);
        }
    } // END StorageShow

    public int SetStorageUp(bodenArten bArten, int amount)
    {

        if (bodenData.ContainsKey(bArten))
        {

                if (currentStorageValue <maxStorageValue)
                {                    
                    int storedAmount = Mathf.Clamp(amount, 0,(maxStorageValue-currentStorageValue));
                    bodenData[bArten] += storedAmount;
                    currentStorageValue += storedAmount;
                    return (amount-storedAmount);

                }
                return amount;
        }
        else
        {
            return -1;
        }

    } // END SetStorageUp

    public void RecheckCurrentStorageValue()
    {

        int result = bodenData[bodenArten.Kohle] + bodenData[bodenArten.Erz] + bodenData[bodenArten.Gold] + bodenData[bodenArten.Oel] + bodenData[bodenArten.Diamant];

        if (result <= maxStorageValue)
        {
            currentStorageValue = result;
        }
        else
        {
            Debug.Log("ERROR: Falsche Werte im MaxStorage und oder CurStorage");

        }

    } // END RecheckCurrentStorageValue
}