using UnityEngine;
using System.Collections;
using System;

public class FactoryButtonClick : MonoBehaviour {


    public FactoryWindow factoryWindowData;
    public PlayerAttributeControl playerAttributeControlData;
    public TaskWaitListWindow taskWaitListWindowData;
    


	// Use this for initialization
	void Awake () {

        factoryWindowData = GameObject.Find("00_GuiStuff").GetComponent<FactoryWindow>();
        playerAttributeControlData = GameObject.Find("01_Player").GetComponent<PlayerAttributeControl>();
        taskWaitListWindowData = GameObject.Find("00_GuiStuff").GetComponent<TaskWaitListWindow>();
	}
	
	// Update is called once per frame
	public void ButtonBuySmashed () 
    {

        if (playerAttributeControlData.playerMoney >= Convert.ToInt32(factoryWindowData.costsValue.text))
        {

            taskWaitListWindowData.SetTasks(factoryWindowData.drillLabelType.text, Convert.ToInt32(factoryWindowData.drillLabelValue.text));
            taskWaitListWindowData.SetTasks(factoryWindowData.scanLabelType.text, Convert.ToInt32(factoryWindowData.scanLabelValue.text));
            taskWaitListWindowData.SetTasks("Pipes", Convert.ToInt32(factoryWindowData.pipesValue.text));

            int amountResult = Convert.ToInt32(factoryWindowData.drillLabelValue.text) + Convert.ToInt32(factoryWindowData.scanLabelValue.text) + Convert.ToInt32(factoryWindowData.pipesValue.text);
            if (amountResult > 0)
            {
                taskWaitListWindowData.SetTaskList(amountResult);

                playerAttributeControlData.playerMoney -= Convert.ToInt32(factoryWindowData.costsValue.text);
                factoryWindowData.costsAmount = 0;
                factoryWindowData.drillLabelType.text = "Standard";
                factoryWindowData.drillAmount = 0;
                factoryWindowData.scanAmount = 0;
                factoryWindowData.scanLabelType.text = "Starter Kit";
                factoryWindowData.pipesAmount = 0;
            }
        }
    } // END ButtonBuySmashed

    public void ButtonDrillMoreTypeSmashed()
    {

        if(factoryWindowData.drillCurrentShownType < 5)
        {

            factoryWindowData.drillCurrentShownType++;

        }
        else
        {
            factoryWindowData.drillCurrentShownType = 0;

        }

    } // END ButtonDrillMoreTypeSmashed

    public void ButtonDrillLessTypeSmashed()
    {

        if (factoryWindowData.drillCurrentShownType > 0)
        {

            factoryWindowData.drillCurrentShownType--;

        }
        else
        {
            factoryWindowData.drillCurrentShownType = 5;

        }

    } // END ButtonDrillLessTypeSmashed


    public void ButtonDrillLessAmountSmashed()
    {

        if (factoryWindowData.drillAmount > 0)
        {

            factoryWindowData.drillAmount--;

        }
        else
        {
            //facWindow.drillAmount = 5;

        }

    } // END ButtonDrillLessAmountSmashed

    public void ButtonDrillMoreAmountSmashed()
    {

        if (factoryWindowData.drillAmount < 999)
        {

            factoryWindowData.drillAmount++;

        }
        else
        {
            //facWindow.drillAmount = 5;

        }

    } // END ButtonDrillMoreAmountSmashed


    public void ButtonScanMoreTypeSmashed()
    {

        if (factoryWindowData.scanCurrentShownType < 5)
        {

            factoryWindowData.scanCurrentShownType++;

        }
        else
        {
            factoryWindowData.scanCurrentShownType = 0;

        }

    } // END ButtonScanMoreTypeSmashed

    public void ButtonScanLessTypeSmashed()
    {

        if (factoryWindowData.scanCurrentShownType > 0)
        {

            factoryWindowData.scanCurrentShownType--;

        }
        else
        {
            factoryWindowData.scanCurrentShownType = 5;

        }

    } // END ButtonScanLessTypeSmashed

    public void ButtonScanLessAmountSmashed()
    {

        if (factoryWindowData.scanAmount > 0)
        {

            factoryWindowData.scanAmount--;

        }
        else
        {
            //facWindow.scanAmount = 5;

        }

    } // END ButtonScanLessAmountSmashed

    public void ButtonScanMoreAmountSmashed()
    {

        if (factoryWindowData.scanAmount < 999)
        {

            factoryWindowData.scanAmount++;

        }
        else
        {
            //facWindow.scanAmount = 5;

        }

    } // END ButtonScanMoreAmountSmashed


    public void ButtonPipesLessAmountSmashed()
    {

        if (factoryWindowData.pipesAmount > 0)
        {

            factoryWindowData.pipesAmount--;

        }
        else
        {
            //facWindow.pipesAmount = 5;

        }

    } // END ButtonScanLessAmountSmashed

    public void ButtonPipesMoreAmountSmashed()
    {

        if (factoryWindowData.pipesAmount < 999)
        {

            factoryWindowData.pipesAmount++;

        }
        else
        {
            //facWindow.pipesAmount = 5;

        }

    } // END ButtonScanMoreAmountSmashed

    public void ButtonTaskList()
    {

        factoryWindowData.OpenTaskListWindow();

    } // END ButtonBuySmashed



}
