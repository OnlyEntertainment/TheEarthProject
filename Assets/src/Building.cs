using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{

    public bool isActive = false;


    public bool showInterface = false;

    public bool isDrilling = false;






    private Rect windowRect = new Rect(200, 200, 500, 500);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (showInterface)
        //{
        //    GameObject interfaceObject = GameObject.Find("BuildingInterface");
        //    BuildingInterface buildingInterface = interfaceObject.GetComponent<BuildingInterface>();
        //    buildingInterface.buildingObject = gameObject;
        //}
    }

    void OnGUI()
    {

        if (showInterface)
        {
            //windowRect = GUI.Window(0, windowRect, window, "My Test");

        }
    }



    void window(int windowID)
    {
        //GUI.Box(new Rect(0, 0, windowRect.width, windowRect.height),"");

        GUI.Label(new Rect(0, 20, windowRect.width, 20), isDrilling.ToString());



        GUI.DragWindow(new Rect(0, 0, windowRect.width, windowRect.height));
    }

    void OnMouseDown()
    { ShowWindow(); }

    public void ShowWindow()
    {
        GameObject buildingInterfaceObject = GameObject.Find("BuildingInterface");
        if (buildingInterfaceObject == null) Debug.Log("FEHLER");

        buildingInterfaceObject.GetComponent<BuildingInterface>().ShowWindow(gameObject);
    }

}
