using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using sondenArten = BuildingInterface.SONDENART;

public class ScanMaster : MonoBehaviour {

    public Dictionary<sondenArten, ScanMain> scanDictionary;


	// Use this for initialization
	void Awake () {

        scanDictionary = ScanMain.GenerateScan();

	}
	
}
