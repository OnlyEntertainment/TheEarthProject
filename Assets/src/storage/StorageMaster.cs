using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageMaster : MonoBehaviour {

    public Dictionary<string, StorageMain> storageDictionary;


	void Awake () {

        storageDictionary = StorageMain.GenerateStorage();

	} // END Awake
	

}
