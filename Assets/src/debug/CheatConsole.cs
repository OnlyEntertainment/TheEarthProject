using UnityEngine;
using System.Collections;

public class CheatConsole : MonoBehaviour {
    
    //Variablen
    // Player
    public GameObject playerObject;
    public PlayerAttributeControl playerControlData;
    public PlayerKeyboardControl playerKeyControlData;
    // Camera
    public GameObject cameraObject;
    public ShowingStuff cameraShowingStuffData;

    //

    public float timeIs = 3f;

	// Use this for initialization
	void Start () {

        playerObject = GameObject.Find("01_Player");
        playerControlData = playerObject.GetComponent<PlayerAttributeControl>();
        playerKeyControlData = playerObject.GetComponent<PlayerKeyboardControl>();


        cameraObject = GameObject.Find("00_MainCamera");
        cameraShowingStuffData = cameraObject.GetComponent<ShowingStuff>();


	}
	
	// Update is called once per frame
	void Update () {

        
        



	}




}
