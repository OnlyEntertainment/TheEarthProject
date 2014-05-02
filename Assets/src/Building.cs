using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using BOHRERART = BuildingInterface.BOHRERART;
using SONDENART = BuildingInterface.SONDENART;

public class Building : MonoBehaviour
{
    public string buildingName = "Bohrturm";

    public enum BUILDINGSTATUS { Idle, Drilling, Mining, Probing, OnHold };


    //public bool showInterface = false;

    public BUILDINGSTATUS status = BUILDINGSTATUS.Idle;


    public GameObject bohrer;


    public int bohrtiefe = 0;
    public BuildingInterface.BOHRERART bohrerArt = BuildingInterface.BOHRERART.Standard;
    public BuildingInterface.SONDENART sondenArt = BuildingInterface.SONDENART.Starterkit;


    public int bohrTiefeAktuell = 0;
    public float timer = 5;
    public float timerIntervall = 5;

    GameObject buildingInterfaceObject;
    BuildingInterface buildingInterface;


    private GameObject abbauEbene;
    private CellControl abbauCellControl;

    public GameObject drillHolder;


    private List<GameObject> bohrerListe = new List<GameObject>();

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
                    if (bohrTiefeAktuell <= bohrtiefe)
                    {
                        bohrTiefeAktuell++;
                        timer = timerIntervall;
                    }

                    Debug.Log("Startvector = " + gameObject.transform.position);
                    Debug.Log("Direction = " + gameObject.transform.position * -1);
                    Debug.DrawRay(gameObject.transform.position, (gameObject.transform.position * -1), Color.cyan,5);

                    
                    RaycastHit[] hitEbene = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.position * -1,5 , 1 << 8);//Mathf.Infinity
                    Debug.Log("Anzahl = " + hitEbene.Length);

                    GameObject ebene = null;
                    CellControl cell = null;

                    for (int intEbene = 0; intEbene < hitEbene.Length; intEbene++)
                    { 
                    ebene = hitEbene[intEbene].transform.parent.gameObject;                    
                    cell = ebene.GetComponent<CellControl>();

                        if (cell.lage == 20 - bohrTiefeAktuell+1) break;
                    }

                    //GameObject ebene = hitEbene[bohrTiefeAktuell - 1].transform.parent.gameObject;                    
                    //CellControl cell = ebene.GetComponent<CellControl>();
                   
                    //Vector3 neuePos = new Vector3(ebene.transform.position.x - gameObject.transform.position.x, ebene.transform.position.y - gameObject.transform.position.y, bohrer.transform.position.z);
                    Vector3 neuePos = new Vector3(ebene.transform.position.x, ebene.transform.position.y, bohrer.transform.position.z);
                    GameObject neuerBohrer = (GameObject)Instantiate(bohrer, neuePos, ebene.transform.rotation);
                   //neuerBohrer.transform.parent = drillHolder.transform;
                    bohrerListe.Add(neuerBohrer);

                    neuerBohrer.transform.position = neuePos;

                    if (!canDrill(cell))
                    {
                        status = BUILDINGSTATUS.Idle;

                        for (int item = 0; item < bohrerListe.Count; item++)
                        {
                            Destroy(bohrerListe[item]);
                        }
                        bohrerListe = new List<GameObject>();
                    }

                    if (bohrTiefeAktuell > bohrtiefe)
                    {
                        status = BUILDINGSTATUS.Mining;
                        abbauEbene = ebene;
                        abbauCellControl = cell;
                    }



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
        switch (bohrerArt)
        {
            case BOHRERART.Standard:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser)
                { return true; }
                break;
            case BOHRERART.Eisen:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser ||
                    cellControl.bodenart == CellControl.BODENARTEN.Gold)
                { return true; }
                break;
            case BOHRERART.Stahl:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser ||
                    cellControl.bodenart == CellControl.BODENARTEN.Gold ||
                    cellControl.bodenart == CellControl.BODENARTEN.Oel)
                { return true; }
                break;
            case BOHRERART.Chrom:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser ||
                    cellControl.bodenart == CellControl.BODENARTEN.Gold ||
                    cellControl.bodenart == CellControl.BODENARTEN.Oel)
                { return true; }
                break;
            case BOHRERART.Titan:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser ||
                    cellControl.bodenart == CellControl.BODENARTEN.Gold ||
                    cellControl.bodenart == CellControl.BODENARTEN.Oel ||
                    cellControl.bodenart == CellControl.BODENARTEN.Obsidian ||
                    cellControl.bodenart == CellControl.BODENARTEN.Marmor ||
                    cellControl.bodenart == CellControl.BODENARTEN.Diamant)
                { return true; }
                break;
            case BOHRERART.Diamant:
                if (cellControl.bodenart == CellControl.BODENARTEN.Dreck || 
                    cellControl.bodenart == CellControl.BODENARTEN.Kohle ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Stein ||
                    cellControl.bodenart == CellControl.BODENARTEN.Erz ||
                    cellControl.bodenart == CellControl.BODENARTEN.Wasser ||
                    cellControl.bodenart == CellControl.BODENARTEN.Gold ||
                    cellControl.bodenart == CellControl.BODENARTEN.Oel ||
                    cellControl.bodenart == CellControl.BODENARTEN.Magma ||
                    cellControl.bodenart == CellControl.BODENARTEN.Obsidian ||
                    cellControl.bodenart == CellControl.BODENARTEN.Marmor ||
                    cellControl.bodenart == CellControl.BODENARTEN.Diamant)
                { return true; }
                break;
        }
        return false;
    }


    void OnMouseDown()
    { buildingInterface.ShowWindow(gameObject); }

}
