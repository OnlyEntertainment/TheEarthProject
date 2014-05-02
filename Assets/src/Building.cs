using UnityEngine;
using System.Collections;

using BOHRERART = BuildingInterface.BOHRERART;
using SONDENART = BuildingInterface.SONDENART;

public class Building : MonoBehaviour
{
    public string buildingName = "Bohrturm";

    public enum BUILDINGSTATUS { Idle, Drilling,Mining, Probing, OnHold };


    //public bool showInterface = false;

    public BUILDINGSTATUS status = BUILDINGSTATUS.Idle;


    public GameObject bohrer;


    public int bohrtiefe = 0;
    public BuildingInterface.BOHRERART bohrerArt = BuildingInterface.BOHRERART.Standard;
    public BuildingInterface.SONDENART sondenArt = BuildingInterface.SONDENART.Starterkit;


    public int bohrTiefeAktuell = 0;
    public float timer = 10;

    GameObject buildingInterfaceObject;
    BuildingInterface buildingInterface;

    // Use this for initialization
    void Start()
    {
        buildingInterfaceObject = GameObject.Find("BuildingInterface");
        buildingInterface = buildingInterfaceObject.GetComponent<BuildingInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status == BUILDINGSTATUS.Drilling)
        {
            if (bohrTiefeAktuell <= bohrtiefe)
            {
                timer -= (1 * Time.deltaTime);

                if (timer <= 0)
                {

                    if (bohrTiefeAktuell < bohrtiefe)
                    { 
                        bohrTiefeAktuell++; 
                        timer = 10; 
                    }

                    RaycastHit[] hitEbene = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.position * -1, Mathf.Infinity, 1 << 8);
                    Debug.Log("Ebenen = " + hitEbene.Length);
                    if (hitEbene.Length > 0)
                    {
                        GameObject ebene = hitEbene[bohrTiefeAktuell - 1].transform.parent.gameObject;
                        Debug.Log(ebene.name);
                        CellControl cell = ebene.GetComponent<CellControl>();
                        Debug.Log("Aktuelle Bohrtiefe = " + bohrTiefeAktuell);
                        Debug.Log("Aktuelle Zelle = " + cell.bodenart.ToString());

                    }

                    //TODo Prüfung ob man überhaupt durchbohren darf....
                    if (



                    
                    //                    GameObject neuerBohrer = Instantiate(bohrer,new Vector3(gameObject.transform.position.x);

                }
            }
        }



        //if (showInterface)
        //{
        //    GameObject interfaceObject = GameObject.Find("BuildingInterface");
        //    BuildingInterface buildingInterface = interfaceObject.GetComponent<BuildingInterface>();
        //    buildingInterface.buildingObject = gameObject;
        //}
    }



    bool canDrill(CellControl cellControl)
    {
        //switch (bohrerArt)
        //{ 
        //    case BOHRERART.Standard:
        //    case BOHRERART.Eisen:
        //    case BOHRERART.Stahl:
        //    case BOHRERART.Chrom:
        //    case BOHRERART.Titan:
        //        if (cellControl.bodenart == CellControl.BODENARTEN.Magma ||

        //            ) return false;
        //            break;
        //    case BOHRERART.Diamant:                
        //        break;
        //}
        return true;
    }


    void OnMouseDown()
    { buildingInterface.ShowWindow(gameObject); }

}
