using UnityEngine;
using System.Collections;

public class PlayerKeyboardControl : MonoBehaviour {

    // Research
    // variablen
    private bool showResearch = false;
    private bool showStorage = false;
    private bool showFactory = false;

    public PlayerAttributeControl playerAttributeControlData;

    public GameObject researchObject;
    public ResearchWindow menuResearchWindowData;
    public StorageWindow menuStorageWindowData;
    public FactoryWindow menuFactoryWindowData;
    // #####
    
    
    // #####

    public float timerHellGod = 0;
    public float timerHellGodSec;

	// Use this for initialization
	void Start () {
        
        playerAttributeControlData = gameObject.GetComponent<PlayerAttributeControl>();

        researchObject = GameObject.Find("00_GuiStuff");
        menuResearchWindowData = researchObject.GetComponent<ResearchWindow>();
        menuStorageWindowData = researchObject.GetComponent<StorageWindow>();
        menuFactoryWindowData = researchObject.GetComponent<FactoryWindow>();

	} // END Start
	
	// Update is called once per frame
	void Update () {




        if (Input.GetKeyDown(KeyCode.F1))
        {
            menuResearchWindowData.ResearchShow();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            menuFactoryWindowData.FactoryShow();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            menuStorageWindowData.StorageShow();
        }


        if (timerHellGod > 0)
        {
            timerHellGod -= 1 * Time.deltaTime;
        }
        else
        {
            
        }

	} // END Update


    public void SendMessage(string message)
    {
        timerHellGod = 5f;
            

    } // END SendMessage


}
