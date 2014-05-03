using UnityEngine;
using System.Collections;

public class FactoryButtonClick : MonoBehaviour {


    public FactoryWindow facWindow;
    public PlayerAttributeControl pMaster;


	// Use this for initialization
	void Awake () {

        facWindow = GameObject.Find("00_GuiStuff").GetComponent<FactoryWindow>();
        pMaster = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();

	}
	
	// Update is called once per frame
	public void ButtonBuySmashed () 
    {
	    


	}

    public void ButtonDrillMoreTypeSmashed()
    {



    }

    public void ButtonDrillLessTypeSmashed()
    {



    }
}
