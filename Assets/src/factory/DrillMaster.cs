using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;

public class DrillMaster : MonoBehaviour {

    public Dictionary<bohrerArten, DrillMain> drillDictionary;

	void Awake () {

        drillDictionary = DrillMain.GenerateDrills();
	
    } // Awake
	

}
