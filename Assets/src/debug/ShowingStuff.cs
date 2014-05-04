using UnityEngine;
using System.Collections;

public class ShowingStuff : MonoBehaviour {
    
    // ---------
    // Variablen

    float timeA;
    public int fps;
    public int lastFPS;
    public GUIStyle textStyle;

    //++++++++++++++
    // PlayerControl

    public GameObject pObject;
    public PlayerAttributeControl pControl;

    //++++++++++++++
    // Buildings
    public int buildingsCount = 0;
    public int mass = 0;

    // ---------------------------
    // Use this for initialization
    void Start()
    {
        pObject = GameObject.Find("01_Player");
        pControl = pObject.GetComponent<PlayerAttributeControl>();
        
        
        
        timeA = Time.timeSinceLevelLoad;
        DontDestroyOnLoad(this);
    } // END Start

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }
    } // END Update

    void OnGUI()
    { 
        GUI.Label(new Rect(10, 10, 30, 30), "fps: " + lastFPS, textStyle);
   } // END OnGUI
} // END END
