using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bodenArten = CellControl.BODENARTEN;

public class StorageWindow : MonoBehaviour
{

    public bool showStorage = true;
    public StorageMaster storageMasterData;

    public GameObject storageWindowMenuObject;


    public enum MaterialType { Cole, Oil, Ore, Gold, Diamond };
    public MaterialType materialType;

    public int maxStorageValue = 1000;
    public int currentStorageValue = 0;

    public Dictionary<bodenArten, int> bodenArtenDictionary = new Dictionary<bodenArten, int>();

    // MaterialWindow
    public GameObject matWindowObject;
    public UILabel label1;
    public UILabel label2;
    public UILabel label3;
    public UILabel label4;
    public UILabel label5;
    public UILabel label6;
    public UILabel label1Value;
    public UILabel label2Value;
    public UILabel label3Value;
    public UILabel label4Value;
    public UILabel label5Value;
    public UILabel label6Value;

    public UILabel label7Pipes;
    public UILabel label7PipesValue;

    public UILabel labelShowType;
    public bool showTypeInMaterialWindow = true;

    public int drillStandardAmount = 0;
    public int drillEisenAmount = 0;
    public int drillStahlAmount = 0;
    public int drillChromAmount = 0;
    public int drillTitanAmount = 0;
    public int drillDiamondAmount = 0;

    public int scanStarterKitAmount = 0;
    public int scanSchwachAmount = 0;
    public int scanKleinAmount = 0;
    public int scanMittelAmount = 0;
    public int scanGrossAmount = 0;
    public int scanStarkAmount = 0;

    public int pipesAmount = 0;

    public bool showMaterialWindow = false;


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

        storageMasterData = this.GetComponent<StorageMaster>();
        matWindowObject = transform.FindChild("StorageWindowData").gameObject.transform.FindChild("MaterialWindow").gameObject;
        label1 = matWindowObject.transform.FindChild("Label1").gameObject.GetComponent<UILabel>();
        label1Value = matWindowObject.transform.FindChild("Label1").gameObject.transform.FindChild("Label1Value").gameObject.GetComponent<UILabel>();
        label2 = matWindowObject.transform.FindChild("Label2").gameObject.GetComponent<UILabel>();
        label2Value = matWindowObject.transform.FindChild("Label2").gameObject.transform.FindChild("Label2Value").gameObject.GetComponent<UILabel>();
        label3 = matWindowObject.transform.FindChild("Label3").gameObject.GetComponent<UILabel>();
        label3Value = matWindowObject.transform.FindChild("Label3").gameObject.transform.FindChild("Label3Value").gameObject.GetComponent<UILabel>();
        label4 = matWindowObject.transform.FindChild("Label4").gameObject.GetComponent<UILabel>();
        label4Value = matWindowObject.transform.FindChild("Label4").gameObject.transform.FindChild("Label4Value").gameObject.GetComponent<UILabel>();
        label5 = matWindowObject.transform.FindChild("Label5").gameObject.GetComponent<UILabel>();
        label5Value = matWindowObject.transform.FindChild("Label5").gameObject.transform.FindChild("Label5Value").gameObject.GetComponent<UILabel>();
        label6 = matWindowObject.transform.FindChild("Label6").gameObject.GetComponent<UILabel>();
        label6Value = matWindowObject.transform.FindChild("Label6").gameObject.transform.FindChild("Label6Value").gameObject.GetComponent<UILabel>();

        label7Pipes = matWindowObject.transform.FindChild("Label7Pipes").gameObject.GetComponent<UILabel>();
        label7PipesValue = matWindowObject.transform.FindChild("Label7Pipes").gameObject.transform.FindChild("Label7PipesValue").gameObject.GetComponent<UILabel>();

        labelShowType = matWindowObject.transform.FindChild("LabelShowType").gameObject.GetComponent<UILabel>();

        GameObject storageWindowDataObject = transform.FindChild("StorageWindowData").gameObject;
        maxStorageLabel = storageWindowDataObject.transform.FindChild("LabelMaxStorage").gameObject.transform.FindChild("LabelMaxStorageValue").gameObject.GetComponent<UILabel>();
        curStorageLabel = storageWindowDataObject.transform.FindChild("LabelCurrentStorage").gameObject.transform.FindChild("LabelCurrentStorageValue").gameObject.GetComponent<UILabel>();

        coleLabelValue = storageWindowDataObject.transform.FindChild("LabelCole").gameObject.transform.FindChild("LabelColeValue").gameObject.GetComponent<UILabel>();
        oreLabelValue = storageWindowDataObject.transform.FindChild("LabelOre").gameObject.transform.FindChild("LabelOreValue").gameObject.GetComponent<UILabel>();
        goldLabelValue = storageWindowDataObject.transform.FindChild("LabelGold").gameObject.transform.FindChild("LabelGoldValue").gameObject.GetComponent<UILabel>();
        oilLabelValue = storageWindowDataObject.transform.FindChild("LabelOil").gameObject.transform.FindChild("LabelOilValue").gameObject.GetComponent<UILabel>();
        diamondLabelValue = storageWindowDataObject.transform.FindChild("LabelDiamond").gameObject.transform.FindChild("LabelDiamondValue").gameObject.GetComponent<UILabel>();


        storageWindowMenuObject = GameObject.FindGameObjectWithTag("MenuStorage");

        StorageShow();
    } // END Start

    // Update is called once per frame
    void Update()
    {

        RecheckCurrentStorageValue();
        ReloadStorageDataInWindow();
        ShowMaterialWindow();

    } // END Update


    void FillDictionary()
    {

        bodenArtenDictionary.Add(bodenArten.Kohle, 10);
        bodenArtenDictionary.Add(bodenArten.Erz, 20);
        bodenArtenDictionary.Add(bodenArten.Oel, 30);
        bodenArtenDictionary.Add(bodenArten.Gold, 40);
        bodenArtenDictionary.Add(bodenArten.Diamant, 50);
    } // END FillDictionary

    void ReloadStorageDataInWindow()
    {

        maxStorageLabel.text = maxStorageValue.ToString();
        curStorageLabel.text = currentStorageValue.ToString();

        coleLabelValue.text = bodenArtenDictionary[bodenArten.Kohle].ToString();
        oreLabelValue.text = bodenArtenDictionary[bodenArten.Erz].ToString();
        goldLabelValue.text = bodenArtenDictionary[bodenArten.Gold].ToString();
        oilLabelValue.text = bodenArtenDictionary[bodenArten.Oel].ToString();
        diamondLabelValue.text = bodenArtenDictionary[bodenArten.Diamant].ToString();
        label7Pipes.text = "Pipes";
        label7PipesValue.text = pipesAmount.ToString();

    } // END ReloadStorageDataInWindow

    public void StorageShow()
    {

        if (showStorage == false)
        {
            showStorage = true;
            storageWindowMenuObject.SetActive(true);


            ReloadStorageDataInWindow();
        }
        else
        {
            showStorage = false;
            storageWindowMenuObject.SetActive(false);
        }
    } // END StorageShow

    public int SetStorageUp(bodenArten bArten, int amount)
    {

        if (bodenArtenDictionary.ContainsKey(bArten))
        {

            if (currentStorageValue < maxStorageValue)
            {
                int storedAmount = Mathf.Clamp(amount, 0, (maxStorageValue - currentStorageValue));
                bodenArtenDictionary[bArten] += storedAmount;
                currentStorageValue += storedAmount;
                return (amount - storedAmount);

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

        int result = bodenArtenDictionary[bodenArten.Kohle] + bodenArtenDictionary[bodenArten.Erz] + bodenArtenDictionary[bodenArten.Gold] + bodenArtenDictionary[bodenArten.Oel] + bodenArtenDictionary[bodenArten.Diamant];

        if (result <= maxStorageValue)
        {
            currentStorageValue = result;
        }
        else
        {
            Debug.Log("ERROR: Falsche Werte im MaxStorage und oder CurStorage");

        }

    } // END RecheckCurrentStorageValue

    void ShowMaterialWindow()
    {

        if (showMaterialWindow == true)
        {

            matWindowObject.SetActive(true);
            if (showTypeInMaterialWindow == true)
            {
                labelShowType.text = "Drill";
                label1.text = "Standard";
                label2.text = "Eisen";
                label3.text = "Stahl";
                label4.text = "Chrom";
                label5.text = "Titan";
                label6.text = "Diamant";

                label1Value.text = drillStandardAmount.ToString();
                label2Value.text = drillEisenAmount.ToString();
                label3Value.text = drillStahlAmount.ToString();
                label4Value.text = drillChromAmount.ToString();
                label5Value.text = drillTitanAmount.ToString();
                label6Value.text = drillDiamondAmount.ToString();

                label7Pipes.text = "Pipes";
                label7PipesValue.text = pipesAmount.ToString();
            }
            else
            {
                labelShowType.text = "Scan";
                label1.text = "Starter Kit";
                label2.text = "Schwach";
                label3.text = "Klein";
                label4.text = "Mittel";
                label5.text = "Groß";
                label6.text = "Stark";

                label1Value.text = scanStarterKitAmount.ToString();
                label2Value.text = scanSchwachAmount.ToString();
                label3Value.text = scanKleinAmount.ToString();
                label4Value.text = scanMittelAmount.ToString();
                label5Value.text = scanGrossAmount.ToString();
                label6Value.text = scanStarkAmount.ToString();

                label7Pipes.text = "Pipes";
                label7PipesValue.text = pipesAmount.ToString();
            }
        }
        else
        {

            matWindowObject.SetActive(false);
        }

    } // END ShowMaterialWindow

    public void ChangeShowMaterialType()
    {

        if (showTypeInMaterialWindow == true)
        {
            showTypeInMaterialWindow = false;
        }
        else
        {
            showTypeInMaterialWindow = true;
        }
    } // END ChangeShowMaterialType

    public void SetMaterialWindowDataUp(string product, int amount)
    {


        switch(product)
        {
            case "Standard":
                drillStandardAmount += amount;
                break;
            case "Eisen":
                drillEisenAmount += amount;
                break;
            case "Stahl":
                drillStahlAmount += amount;
                break;
            case "Chrom":
                drillChromAmount += amount;
                break;
            case "Titan":
                drillTitanAmount += amount;
                break;
            case "Diamant":
                drillDiamondAmount+= amount;
                break;
            case "Starter Kit":
                scanStarterKitAmount += amount;
                break;
            case "Schwach":
                scanSchwachAmount += amount;
                break;
            case "Klein":
                scanKleinAmount += amount;
                break;
            case "Mittel":
                scanMittelAmount += amount;
                break;
            case "Groß":
                scanGrossAmount += amount;
                break;
            case "Stark":
                scanStarkAmount += amount;
                break;
            case "Pipes":
                pipesAmount += amount;
                break;
        }

    } // END SetMaterialWindowDataUp
}