using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bodenArten = CellControl.BODENARTEN;

public class StorageButtonClickTwo : MonoBehaviour {

    public StorageWindow stoWindow;
    public PlayerAttributeControl pMaster;
    public StorageWindow stoWindowSecond;


    // Use this for initialization
    void Awake()
    {

        stoWindow = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
        pMaster = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();
        stoWindowSecond = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
    } // END Start


    public void StorageMaterialTypeNext()
    {

        stoWindowSecond.ChangeShowMaterialType();

    } // END StorageMaterialTypeNext

    public void StorageMaterialTypeBack()
    {
        stoWindowSecond.ChangeShowMaterialType();



    } // END StorageMaterialTypeBack


    public void StorageOpenMaterialWindow()
    {
        if (stoWindowSecond.showMaterialWindow == true)
        {
            stoWindowSecond.showMaterialWindow = false;
        }
        else
        {
            stoWindowSecond.showMaterialWindow = true;
        }



    } // END StorageOpenMaterialWindow
}
