using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using BOHRERART = BuildingInterface.BOHRERART;
using SONDENART = BuildingInterface.SONDENART;

public class Building : MonoBehaviour
{
    private GameObject buildingInterfaceObject;
    private BuildingInterface buildingInterface;
    private StorageWindow storageWindow;

    public enum BUILDINGSTATUS { Idle, Drilling, Mining, Probing, OnHold };


    public string buildingName = "Bohrturm";
    public BUILDINGSTATUS buildingStatus = BUILDINGSTATUS.Idle;

    public int drillingDepthCurrent = 0;
    public int drillingDepthGoal = 0;    
    public BuildingInterface.BOHRERART drillType = BuildingInterface.BOHRERART.Standard;

    public int probingShowAmountMax = 0;
    public int probingDepthGoal = 0;
    public BuildingInterface.SONDENART probeType = BuildingInterface.SONDENART.Starterkit;



    public GameObject prefabDrillObject;
    public GameObject prefabProbeOject;
    private List<GameObject> drillList = new List<GameObject>();

    public int miningAmount = 5;
    public float timerIntervallDrilling = 5;
    public float timerIntervallProbing = 10;
    public float timer = 5;


    private GameObject miningCell;
    private CellControl miningCellControl;


    void Start()
    {
        buildingInterfaceObject = GameObject.Find("BuildingInterface");
        buildingInterface = buildingInterfaceObject.GetComponent<BuildingInterface>();
        storageWindow = buildingInterface.storageWindow;
    }

    void Update()
    {
        switch (buildingStatus)
        {
            case BUILDINGSTATUS.Drilling: 
                Drilling(); 
                break;
            case BUILDINGSTATUS.Mining:
                Mining();
                break;
            case BUILDINGSTATUS.OnHold:
                OnHold();
                break;
            case BUILDINGSTATUS.Probing:
                Probing();
                break;
        }
    


        //if (showInterface)
        //{
        //    GameObject interfaceObject = GameObject.Find("BuildingInterface");
        //    BuildingInterface buildingInterface = interfaceObject.GetComponent<BuildingInterface>();
        //    buildingInterface.buildingObject = gameObject;
        //}
    }

    private void DestroyBuilding(string message)
    {
        buildingStatus = BUILDINGSTATUS.Idle;

        for (int item = 0; item < drillList.Count; item++)
        {
            Destroy(drillList[item]);
        }
        drillList = new List<GameObject>();
    }

    private void Mining()
    {
        if (miningCell != null && miningCellControl != null)
        {
            timer -= (1 * Time.deltaTime);

            if (timer <= 0)
            {
                if (miningCellControl.menge <= 0) { DestroyBuilding("Rohstoff erschöpft"); }

                timer = timerIntervallDrilling;

                int amount = (int)Mathf.Clamp(miningAmount, 0, miningCellControl.menge);

                int notStored = storageWindow.SetStorageUp(miningCellControl.bodenart, amount);

                if (notStored == -1) DestroyBuilding("Rohstoff hat keinen Wert");

                Debug.Log("Rohstoff = " + miningCellControl.bodenart.ToString());
                Debug.Log("Menge = " + amount.ToString());
                Debug.Log("Rest = " + notStored.ToString());

                if (notStored > 0) { buildingStatus = BUILDINGSTATUS.OnHold; return; }
                miningCellControl.menge -= amount - notStored;


            }
        }
    }

    private void OnHold()
    {
        if (miningCell != null && miningCellControl != null)
        {
            timer -= (1 * Time.deltaTime);

            if (timer <= 0)
            {
                timer = timerIntervallDrilling;

                buildingStatus = BUILDINGSTATUS.Mining;
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
                GameObject layer = null;
                CellControl cell = null;
                Vector3 newPos;
                GameObject newDrill;

                drillingDepthCurrent++;
                timer = timerIntervallDrilling;

                for (int intEbene = 0; intEbene < hitEbene.Length; intEbene++)
                {
                    layer = hitEbene[intEbene].transform.parent.gameObject;
                    cell = layer.GetComponent<CellControl>();

                    if (cell.lage == (20 - drillingDepthCurrent + 1)) break;
                }

                newPos = new Vector3(layer.transform.position.x, layer.transform.position.y, prefabDrillObject.transform.position.z);
                newDrill = (GameObject)Instantiate(prefabDrillObject, newPos, layer.transform.rotation);

                drillList.Add(newDrill);
                newDrill.transform.position = newPos;

                if (cell.isHidden) { cell.isHidden = false; cell.LoadTexture(); }
                if (!canDrill(cell)) { DestroyBuilding("Gestein zu Hart --> Abbruch"); }
                else if (drillingDepthCurrent > drillingDepthGoal)
                {

                    buildingStatus = BUILDINGSTATUS.Mining;
                    miningCell = layer;
                    miningCellControl = cell;
                }
            }
        }
    }

    private void Probing()
    {
        if (drillingDepthCurrent <= probingDepthGoal)
        {
            timer -= (1 * Time.deltaTime);

            if (timer <= 0)
            {
                RaycastHit[] hitEbene = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.position * -1, 5, 1 << 8);//Mathf.Infinity            
                GameObject layer = null;
                CellControl cell = null;
                Vector3 newPos;
                GameObject newProbe;

                drillingDepthCurrent++;
                timer = timerIntervallProbing;

                for (int intEbene = 0; intEbene < hitEbene.Length; intEbene++)
                {
                    layer = hitEbene[intEbene].transform.parent.gameObject;
                    cell = layer.GetComponent<CellControl>();

                    if (cell.lage == (20 - drillingDepthCurrent + 1)) break;
                }

                newPos = new Vector3(layer.transform.position.x, layer.transform.position.y, prefabProbeOject.transform.position.z);
                newProbe = (GameObject)Instantiate(prefabProbeOject, newPos, layer.transform.rotation);

                drillList.Add(newProbe);
                newProbe.transform.position = newPos;

                
                if (cell.isHidden) { cell.isHidden = false; cell.LoadTexture(); }
                if (cell.lage >= 20 - probingShowAmountMax) { cell.showAmount = true; }

                if (drillingDepthCurrent > probingDepthGoal)
                {
                    buildingStatus = BUILDINGSTATUS.Idle;
                    DestroyBuilding("Sondieren fertig");
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
