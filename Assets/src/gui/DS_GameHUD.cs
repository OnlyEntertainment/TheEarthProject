using UnityEngine;
using System.Collections;

public class DS_GameHUD : MonoBehaviour
{

    private bool istAmBauen = false;

    public GameObject worldGen;
    public GameObject prefabGebaeude;
    private GameObject instanzGebaeude;

    private Color colorInit;
    public Color colorAllowedToBuild;
    public Color colorDeniedToBuild;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (istAmBauen)
        {

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            {

                Destroy(instanzGebaeude);
                istAmBauen = false;
                instanzGebaeude = null;
                return;
            }

            Vector3 posMaus = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 posNull = new Vector2(0, 0);

            float radius = prefabGebaeude.transform.position.y;
            float winkel = (Mathf.Atan((posNull.x - posMaus.x) / (posNull.y - posMaus.y)) * 180 / Mathf.PI);
            float winkelteil = 360f / 20f; //ToDo die 20 ersetzten durch die echten teile
            float alphaD = (2f * Mathf.PI) / 20; //ToDo die 20 ersetzten durch die echten teile


            if (posMaus.x >= posNull.x && posMaus.y <= posNull.y) winkel = winkel * -1 + 180; //Q 1
            else if (posMaus.x <= posNull.x && posMaus.y <= posNull.y) winkel = (90 - winkel) + 90; //Q 2
            else if (posMaus.x >= posNull.x && posMaus.y >= posNull.y) winkel = (90 - winkel) + 270; //Q 3
            else winkel = winkel * -1;

            int volleTeile = (int)(winkel / winkelteil);
            if (winkel % winkelteil >= (winkelteil / 2)) volleTeile += 1;

            Vector3 newPosition = prefabGebaeude.transform.position;
            newPosition.x = Mathf.Cos((volleTeile + 5) * alphaD) * radius;
            newPosition.y = Mathf.Sin((volleTeile + 5) * alphaD) * prefabGebaeude.transform.position.y;

            Vector3 rayPosition = prefabGebaeude.transform.position;
            rayPosition.x = Mathf.Cos((volleTeile + 5) * alphaD) * (prefabGebaeude.transform.position.y + 1);
            rayPosition.y = Mathf.Sin((volleTeile + 5) * alphaD) * (prefabGebaeude.transform.position.y + 1);

            instanzGebaeude.transform.position = newPosition;
            instanzGebaeude.transform.localEulerAngles = new Vector3(0, 0, volleTeile * winkelteil);


            //Debug.DrawRay(rayPosition, newPosition * -1, Color.black);

            RaycastHit rayHitOtherBuilding;

            instanzGebaeude.renderer.material.color = colorDeniedToBuild;

            if (!Physics.Raycast(rayPosition, newPosition * -1, out rayHitOtherBuilding, 1f))
            {
                RaycastHit rayHitGround;

                GameObject groundCell = null;
                CellControl groundCellInfos = null;

                //Debug.DrawRay(newPosition, newPosition * -1, Color.cyan);
                if (Physics.Raycast(newPosition, newPosition * -1, out rayHitGround, 1f))
                {
                    groundCell = rayHitGround.transform.parent.gameObject;
                    groundCellInfos = (CellControl)groundCell.GetComponent<CellControl>();
                    //Debug.Log("Transform = " + groundCell.ToString());
                    //Debug.Log("ZellenTyp = " + groundCellInfos.bodenart.ToString());

                    if (groundCellInfos.bodenart != CellControl.BODENARTEN.Magma &&
                        groundCellInfos.bodenart != CellControl.BODENARTEN.Wasser &&
                        groundCellInfos.bodenart != CellControl.BODENARTEN.Oel)
                    {
                        instanzGebaeude.renderer.material.color = colorAllowedToBuild;


                        if (Input.GetMouseButton(0))
                        {
                            instanzGebaeude.transform.position = new Vector3(instanzGebaeude.transform.position.x, instanzGebaeude.transform.position.y, 0);
                            instanzGebaeude.transform.parent = worldGen.transform;
                            instanzGebaeude.collider.enabled = true;
                            instanzGebaeude.renderer.material.color = colorInit;
                            istAmBauen = false;
                            instanzGebaeude = null;
                        }
                    }
                }
            }
        }

    }

    void OnGUI()
    {
        if (!istAmBauen)
        {
            if (GUI.Button(new Rect(100, 100, 100, 100), "Bauen"))
            {
                istAmBauen = true;
                instanzGebaeude = (GameObject)Instantiate(prefabGebaeude);
                instanzGebaeude.collider.enabled = false;
                colorInit = instanzGebaeude.renderer.material.color;


            }
        }
    }
}
