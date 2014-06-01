using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bodenArten = CellControl.BODENARTEN;

public class StorageButtonClickTwo : MonoBehaviour {

    public StorageWindow storageWindowData;
    public PlayerAttributeControl playerAttributeControlData;
    public StorageWindow storageWindowSecondData;


    // Use this for initialization
    void Awake()
    {

        storageWindowData = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
        playerAttributeControlData = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();
        storageWindowSecondData = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
    } // END Start


    public void StorageMaterialTypeNext()
    {

        storageWindowSecondData.ChangeShowMaterialType();

    } // END StorageMaterialTypeNext

    public void StorageMaterialTypeBack()
    {
        storageWindowSecondData.ChangeShowMaterialType();



    } // END StorageMaterialTypeBack


    public void StorageOpenMaterialWindow()
    {
        if (storageWindowSecondData.showMaterialWindow == true)
        {
            storageWindowSecondData.showMaterialWindow = false;
        }
        else
        {
            storageWindowSecondData.showMaterialWindow = true;
        }



    } // END StorageOpenMaterialWindow
}
