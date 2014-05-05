using UnityEngine;
using System.Collections;
using System;

public class FactoryButtonClick : MonoBehaviour {


    public FactoryWindow facWindow;
    public PlayerAttributeControl pMaster;
    public TaskWaitListWindow taskWindow;
    


	// Use this for initialization
	void Awake () {

        facWindow = GameObject.Find("00_GuiStuff").GetComponent<FactoryWindow>();
        pMaster = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();
        taskWindow = GameObject.Find("00_GuiStuff").GetComponent<TaskWaitListWindow>();
	}
	
	// Update is called once per frame
	public void ButtonBuySmashed () 
    {

        if (pMaster.playerMoney >= Convert.ToInt32(facWindow.costsValue.text))
        {

            taskWindow.SetTasks(facWindow.drillLabelType.text, Convert.ToInt32(facWindow.drillLabelValue.text));
            taskWindow.SetTasks(facWindow.scanLabelType.text, Convert.ToInt32(facWindow.scanLabelValue.text));
            taskWindow.SetTasks("Pipes", Convert.ToInt32(facWindow.pipesValue.text));

            int amountResult = Convert.ToInt32(facWindow.drillLabelValue.text) + Convert.ToInt32(facWindow.scanLabelValue.text) + Convert.ToInt32(facWindow.pipesValue.text);
            if (amountResult > 0)
            {
                taskWindow.SetTaskList(amountResult);

                pMaster.playerMoney -= Convert.ToInt32(facWindow.costsValue.text);
                facWindow.costsAmount = 0;
                facWindow.drillLabelType.text = "Standard";
                facWindow.drillAmount = 0;
                facWindow.scanAmount = 0;
                facWindow.scanLabelType.text = "Starter Kit";
                facWindow.pipesAmount = 0;
            }
        }
    } // END ButtonBuySmashed

    public void ButtonDrillMoreTypeSmashed()
    {

        if(facWindow.drillCurrentShownType < 5)
        {

            facWindow.drillCurrentShownType++;

        }
        else
        {
            facWindow.drillCurrentShownType = 0;

        }

    } // END ButtonDrillMoreTypeSmashed

    public void ButtonDrillLessTypeSmashed()
    {

        if (facWindow.drillCurrentShownType > 0)
        {

            facWindow.drillCurrentShownType--;

        }
        else
        {
            facWindow.drillCurrentShownType = 5;

        }

    } // END ButtonDrillLessTypeSmashed


    public void ButtonDrillLessAmountSmashed()
    {

        if (facWindow.drillAmount > 0)
        {

            facWindow.drillAmount--;

        }
        else
        {
            //facWindow.drillAmount = 5;

        }

    } // END ButtonDrillLessAmountSmashed

    public void ButtonDrillMoreAmountSmashed()
    {

        if (facWindow.drillAmount < 999)
        {

            facWindow.drillAmount++;

        }
        else
        {
            //facWindow.drillAmount = 5;

        }

    } // END ButtonDrillMoreAmountSmashed


    public void ButtonScanMoreTypeSmashed()
    {

        if (facWindow.scanCurrentShownType < 5)
        {

            facWindow.scanCurrentShownType++;

        }
        else
        {
            facWindow.scanCurrentShownType = 0;

        }

    } // END ButtonScanMoreTypeSmashed

    public void ButtonScanLessTypeSmashed()
    {

        if (facWindow.scanCurrentShownType > 0)
        {

            facWindow.scanCurrentShownType--;

        }
        else
        {
            facWindow.scanCurrentShownType = 5;

        }

    } // END ButtonScanLessTypeSmashed

    public void ButtonScanLessAmountSmashed()
    {

        if (facWindow.scanAmount > 0)
        {

            facWindow.scanAmount--;

        }
        else
        {
            //facWindow.scanAmount = 5;

        }

    } // END ButtonScanLessAmountSmashed

    public void ButtonScanMoreAmountSmashed()
    {

        if (facWindow.scanAmount < 999)
        {

            facWindow.scanAmount++;

        }
        else
        {
            //facWindow.scanAmount = 5;

        }

    } // END ButtonScanMoreAmountSmashed


    public void ButtonPipesLessAmountSmashed()
    {

        if (facWindow.pipesAmount > 0)
        {

            facWindow.pipesAmount--;

        }
        else
        {
            //facWindow.pipesAmount = 5;

        }

    } // END ButtonScanLessAmountSmashed

    public void ButtonPipesMoreAmountSmashed()
    {

        if (facWindow.pipesAmount < 999)
        {

            facWindow.pipesAmount++;

        }
        else
        {
            //facWindow.pipesAmount = 5;

        }

    } // END ButtonScanMoreAmountSmashed

    public void ButtonTaskList()
    {

        facWindow.OpenTaskListWindow();

    } // END ButtonBuySmashed



}
