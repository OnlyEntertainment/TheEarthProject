using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageMaster : MonoBehaviour {

    public Dictionary<string, StorageMain> stoDictionary;


	// Use this for initialization
	void Awake () {

        stoDictionary = StorageMain.GenerateStorage();

	} // END Awake
	

    public void UpgradeStorage()
    {

        stoDictionary["Storage"].currentLevel++;

    } // END UpgradeStorage
}
