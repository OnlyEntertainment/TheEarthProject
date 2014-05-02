using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using BOHRERART = BuildingInterface.BOHRERART;
using SONDENART = BuildingInterface.SONDENART;

public class Building : MonoBehaviour
{
    private GameObject buildingInterfaceObject;
    private BuildingInterface buildingInterface;


    public enum BUILDINGSTATUS { Idle, Drilling, Mining, Probing, OnHold };


    public string buildingName = "Bohrturm";
    public BUILDINGSTATUS buildingStatus = BUILDINGSTATUS.Idle;

    public int drillingDepthCurrent = 0;
    public int drillingDepthGoal = 0;
    public BuildingInterface.BOHRERART drillType = BuildingInterface.BOHRERART.Standard;
    public BuildingInterface.SONDENART probeType = BuildingInterface.SONDENART.Starterkit;



    public GameObject prefabDrillObject;
    private List<GameObject> drillList = new List<GameObject>();


    public float timerIntervall = 5;
    public float timer = 5;


    private GameObject miningCell;
    private CellControl miningCellControl;


    void Start()
    {
        buildingInterfaceObject = GameObject.Find("BuildingInterface");
        buildingInterface = buildingInterfaceObject.GetComponent<BuildingInterface>();
    }

    void Update()
    {
        if (buildingStatus == BUILDINGSTATUS.Drilling)
        {
            Drilling();
        }
        else if (buildingStatus == BUILDINGSTATUS.Mining)
        {
            Mining();

        }



        //if (showInterface)
        //{
        //    GameObject interfaceObject = GameObject.Find("BuildingInterface");
        //    BuildingInterface buildingInterface = interfaceObject.GetComponent<BuildingInterface>();
        //    buildingInterface.buildingObject = gameObject;
        //}
    }

    private void Mining()
    {
        if (miningCell != null && miningCellControl != null)
        {
            timer -= (1 * Time.deltaTime);

            if (timer <= 0)
            {
                timer = timerIntervall;



            }
        }
    }

    private void Drilling()
    {
        if (drillingDepthCurrent <= drillingDepthGoal)
        {
            timer -= (1 * Time.deltaTime);

            if (timer <= 0)
            {
                RaycastHit[] hitEbene = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.position * -1, 5, 1 << 8);//Mathf.Infinity            
                GameObject ebene = null;
                CellControl cell = null;
                Vector3 neuePos;
                GameObject neuerBohrer;

                drillingDepthCurrent++;
                timer = timerIntervall;

                for (int intEbene = 0; intEbene < hitEbene.Length; intEbene++)
                {
                    ebene = hitEbene[intEbene].transform.parent.gameObject;
                    cell = ebene.GetComponent<CellControl>();

                    if (cell.lage == (20 - drillingDepthCurrent + 1)) break;
                }

                neuePos = new Vector3(ebene.transform.position.x, ebene.transform.position.y, prefabDrillObject.transform.position.z);
                neuerBohrer = (GameObject)Instantiate(prefabDrillObject, neuePos, ebene.transform.rotation);

                drillList.Add(neuerBohrer);
                neuerBohrer.transform.position = neuePos;

                if (!canDrill(cell))
                {
                    buildingStatus = BUILDINGSTATUS.Idle;

                    for (int item = 0; item < drillList.Count; item++)
                    {
                        Destroy(drillList[item]);
                    }
                    drillList = new List<GameObject>();
                }
                else if (drillingDepthCurrent > drillingDepthGoal)
                {

                    buildingStatus = BUILDINGSTATUS.Mining;
                    miningCell = ebene;
                    miningCellControl = cell;
                }
            }
        }
    }


    bool canDrill(CellControl cellControl)
    {
        switch (drillType)
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
