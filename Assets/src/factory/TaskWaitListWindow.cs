using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using bohrerArten = BuildingInterface.BOHRERART;
using sondenArten = BuildingInterface.SONDENART;

public class TaskWaitListWindow : MonoBehaviour
{

   // public Dictionary<string, int> auftragDic = new Dictionary<string,int>();
    public List<string> taskListType = new List<string>();
    public List<int> taskListAmount = new List<int>();

    public FactoryWindow facWindow;

    // Use this for initialization
    void Start()
    {
        facWindow = GetComponent<FactoryWindow>();
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

        if (amountResult > 0)
        {

            if (facWindow.taskStarted == false)
            {
                facWindow.SetCurrentTask(taskListType[0], taskListAmount[0]);
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


            facWindow.SetCurrentTask(taskListType[0], taskListAmount[0]);

    } // END SetTasksAgain

}
