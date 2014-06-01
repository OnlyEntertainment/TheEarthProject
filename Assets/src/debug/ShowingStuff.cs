using UnityEngine;
using System.Collections;

public class ShowingStuff : MonoBehaviour {
    
    // ---------
    // Variablen

    float timeValue;
    public int fps;
    public int lastFPS;
    public GUIStyle textStyle;

    //++++++++++++++
    // PlayerControl

    public GameObject playerObject;
    public PlayerAttributeControl playerAttributeControlData;

    //++++++++++++++
    // Buildings
    public int buildingsCount = 0;
    public int mass = 0;

    // ---------------------------
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find("01_Player");
        playerAttributeControlData = playerObject.GetComponent<PlayerAttributeControl>();
        
        
        
        timeValue = Time.timeSinceLevelLoad;
        DontDestroyOnLoad(this);
    } // END Start

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - timeValue <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeValue = Time.timeSinceLevelLoad;
            fps = 0;
        }
    } // END Update

    void OnGUI()
    { 
        GUI.Label(new Rect(10, 10, 30, 30), "fps: " + lastFPS, textStyle);
   } // END OnGUI
} // END END
