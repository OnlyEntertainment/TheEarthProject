using UnityEngine;
using System.Collections;

public class CheatConsole : MonoBehaviour {
    
    //Variablen
    // Player
    public GameObject pObject;
    public PlayerAttributeControl pControl;
    public PlayerKeyboardControl pKeyControl;
    // Camera
    public GameObject camObject;
    public ShowingStuff cShowingStuff;

    //

    public float timeIs = 3f;

	// Use this for initialization
	void Start () {

        pObject = GameObject.Find("01_Player");
        pControl = pObject.GetComponent<PlayerAttributeControl>();
        pKeyControl = pObject.GetComponent<PlayerKeyboardControl>();


        camObject = GameObject.Find("00_MainCamera");
        cShowingStuff = camObject.GetComponent<ShowingStuff>();


	}
	
	// Update is called once per frame
	void Update () {

        
        



	}




}
