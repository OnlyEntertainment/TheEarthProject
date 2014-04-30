using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchMaster : MonoBehaviour {


    public Dictionary<int, ResearchMain> resDictionary;

	// Use this for initialization
	void Start () {

        resDictionary = ResearchMain.GenerateResearch();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
