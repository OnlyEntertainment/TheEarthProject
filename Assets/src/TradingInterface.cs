using UnityEngine;
using System.Collections;

public class TradingInterface : MonoBehaviour {

    public GameObject tradingInterfaceWindow;

    public UILabel coalStorageVar;
    public UILabel oreStorageVar;
    public UILabel goldStorageVar;
    public UILabel oilStorageVar;
    public UILabel diamondStorageLabel;

    public UISlider coalStorageSlider;
    public UISlider oreStorageSlider;
    public UISlider goldStorageSlider;
    public UISlider oilStorageSlider;
    public UISlider diamondStorageSlider;


    public int coalAmount = 0;
    public int oreAmount = 0;
    public int goldAmount = 0;
    public int oilAmount = 0;
    public int diamondAmount = 0;


    public GameObject storageWindowObject;
    public StorageWindow storageWindow;

	// Use this for initialization
	void Start () 
    {
        storageWindow = storageWindowObject.GetComponent<StorageWindow>();
        

	}
	
	// Update is called once per frame
	void Update () 
    {
        int test = storageWindow.bodenData[CellControl.BODENARTEN.Kohle];
        float slidervalue = coalStorageSlider.value;

        coalStorageVar.GetComponent<UILabel>().text = (slidervalue * test).ToString();
	}

    public void ButtonPressed_Min(CellControl.BODENARTEN bodenart)
    { 


    }

    public void ShowWindow()
    {
        Debug.Log(storageWindow.bodenData[CellControl.BODENARTEN.Kohle]);
        Debug.Log((1 / storageWindow.bodenData[CellControl.BODENARTEN.Kohle]) + 1);
        coalStorageSlider.numberOfSteps = (storageWindow.bodenData[CellControl.BODENARTEN.Kohle]) + 1;
        tradingInterfaceWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        
        tradingInterfaceWindow.SetActive(false);

    }

}
