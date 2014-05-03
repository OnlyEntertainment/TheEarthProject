using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageMaster : MonoBehaviour {

    public Dictionary<string, StorageMain> stoDictionary;


	void Awake () {

        stoDictionary = StorageMain.GenerateStorage();

	} // END Awake
	

}
