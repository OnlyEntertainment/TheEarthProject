using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bodenArten = CellControl.BODENARTEN;


public class StorageButtonClick : MonoBehaviour
{

    public StorageWindow storageWindowData;
    public PlayerAttributeControl playerAttributeControllData;
    public StorageWindow storageWindowSecondData;


    // Use this for initialization
    void Awake()
    {

        storageWindowData = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
        playerAttributeControllData = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();
        storageWindowSecondData = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<StorageWindow>();
    } // END Start

    // Update is called once per frame
    void Update()
    {

    }

    public void StorageButtonClicked()
    {

        Dictionary<string, StorageMain> rMasterDic = storageWindowData.storageMasterData.storageDictionary;

        if (rMasterDic["Storage"].currentLevel < rMasterDic["Storage"].maxLevel)
        {

            if (playerAttributeControllData.playerMoney >= rMasterDic["Storage"].costsMoney[rMasterDic["Storage"].currentLevel])
            {

                playerAttributeControllData.playerMoney -= rMasterDic["Storage"].costsMoney[rMasterDic["Storage"].currentLevel];
                storageWindowData.maxStorageValue += rMasterDic["Storage"].valueStep[rMasterDic["Storage"].currentLevel];
                rMasterDic["Storage"].currentLevel++;



            }
        }


    } // END StorageButtonClick

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
