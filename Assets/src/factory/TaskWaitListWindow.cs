﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;
using sondenArten = BuildingInterface.SONDENART;



public class TaskWaitListWindow : MonoBehaviour
{

   // public Dictionary<string, int> auftragDic = new Dictionary<string,int>();
    public List<string> taskListType = new List<string>();
    public List<int> taskListAmount = new List<int>();

    public GameObject testContainerObject;
    public GameObject spriteTestObject;

    public FactoryWindow factoryWindowData;

    public int currentAmount = 0;
    public List<GameObject> listOfLabels = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        factoryWindowData = GetComponent<FactoryWindow>();
        testContainerObject = transform.FindChild("FactoryWindowData").gameObject.transform.FindChild("TaskListWindow").gameObject.transform.FindChild("Scroll View").gameObject.transform.FindChild("TaskContainer").gameObject;
            //transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetTasks(string product, int amount)
    {

        if (amount > 0)
        {
            taskListType.Add(product);
            taskListAmount.Add(amount);
          
            
        }
    } // END SetTasks

    public void SetTaskList(int amountResult)
    {
        currentAmount = amountResult;


        if (currentAmount > 0)
        {
            
            
            if (factoryWindowData.taskStarted == false)
            {
                factoryWindowData.SetCurrentTask(taskListType[0], taskListAmount[0]);
            }
        }

    } // END SetTasks


    public void DeleteTasks()
    {

        taskListAmount.RemoveAt(0);
        taskListType.RemoveAt(0);

        if(taskListType.Count > 0 && taskListAmount.Count > 0)
        {

            SetTaskListAgain();
        }

    } // END DeleteTasks

    public void SetTaskListAgain()
    {


            factoryWindowData.SetCurrentTask(taskListType[0], taskListAmount[0]);

    } // END SetTasksAgain


    void SetAnTaskEntry()
    {

        GameObject.Instantiate(spriteTestObject, testContainerObject.transform.position, new Quaternion(0f, 0f, 0f, 0f));

    }

    public void TaskListShowed()
    {

        if(factoryWindowData.currentTaskAmount > 0)
        {

            GameObject newLabel = (GameObject)GameObject.Instantiate(spriteTestObject, testContainerObject.transform.position, new Quaternion(0f, 0f, 0f, 0f));
            UILabel newLabelLabel = newLabel.GetComponent<UILabel>();

            newLabelLabel.text = taskListType[0] + " - " + taskListAmount[0];

        }


    }

}
