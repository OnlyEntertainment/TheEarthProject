using UnityEngine;
using System.Collections;

public class DS_GameHUD : MonoBehaviour
{

    private bool istAmBauen = false;

    private GameObject instanzGebaeude;

    public GameObject prefabGebaeude;
    //Dein Vater und deine Mudda

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (istAmBauen)
        { 

            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = mousePos.x;
            float mouseY = mousePos.y;

            Vector2 punktMaus = new Vector2(mouseX,mouseY);
            Vector2 punkt0 = new Vector2(0,0);

            float radius = prefabGebaeude.transform.position.y;
            float winkel = (Mathf.Atan((punkt0.x-punktMaus.x)/(punkt0.y-punktMaus.y)) * 180/Mathf.PI);

            if (punktMaus.x >= punkt0.x && punktMaus.y <= punkt0.y) winkel = winkel*-1+180; //Q 1
            else if (punktMaus.x <= punkt0.x && punktMaus.y <= punkt0.y) winkel =(90-winkel)+90; //Q 2
            else if (punktMaus.x >= punkt0.x && punktMaus.y >= punkt0.y) winkel =(90-winkel)+270; //Q 3
            else winkel = winkel *-1;  


            Debug.Log("Winkel = " + winkel);

            //float intAlpha = 0;
            //float radius = prefabGebaeude.transform.position.y;
            //Vector2 punkt0 = new Vector2(0,0);

            //int addition = 0;
            //if (mousePos.x > 0 && mousePos.y > 0) { intAlpha = 0; }
            //else if (mousePos.x < 0 && mousePos.y > 0) { intAlpha = 90; punkt0 = new Vector2(0, radius); }
            //else if (mousePos.x < 0 && mousePos.y < 0) { intAlpha = 180; punkt0 = new Vector2(-radius, 0); }
            //else if (mousePos.x > 0 && mousePos.y < 0) { intAlpha = 270; punkt0 = new Vector2(0, -radius); }


            ////if (mousePos.x > 0 && mousePos.y > 0) { addition = 0; intAlpha = 0; }
            ////else if (mousePos.x < 0 && mousePos.y > 0) { mouseX *= -1; addition = 5; ;intAlpha = 90; punkt0 = new Vector2(0, radius); }
            ////else if (mousePos.x < 0 && mousePos.y < 0) { mouseX *= -1; mouseY *= -1; addition = 10; intAlpha = 180; punkt0 = new Vector2(-radius, 0); }
            ////else if (mousePos.x > 0 && mousePos.y < 0) { mouseY *= -1; addition = 15; intAlpha = 270; punkt0 = new Vector2(0, -radius); }

            ////Debug.DrawRay(new Vector3(0, 0, 0), new Vector3(transform.position.y, 0, 0)*20, Color.red, 10);
            ////Debug.Log((camera.ScreenToWorldPoint(Input.mousePosition)));
            ////Debug.Log("Alpha = " + Mathf.Atan((mouseY - 0) / (mouseX - prefabGebaeude.transform.position.y)));
            ////Debug.Log("Cos Alpha = " + prefabGebaeude.transform.position.y);
            ////Debug.Log("Sin Alpha = "+Vector3.Distance(new Vector3(transform.position.y,0,0),new Vector3(mouseX,mouseY,0)));

            
            //Vector2 punktA = new Vector2(radius, 0);
            //Vector2 punktMaus = new Vector2(mouseX, mouseY);
            //float gegenkathete = Vector2.Distance(punktA, punktMaus);


            //Debug.Log("PunktA = " + punktA);
            //Debug.Log("PunktMaus = " + punktMaus);
            //Debug.Log("Gegenkathete = " + gegenkathete);

            //Debug.Log("0,0 zu Maus = " + Vector2.Distance(punkt0,punktMaus));
            //Debug.Log("0,0 zu Punkt A = " + Vector2.Distance(punkt0, punktA));

            //float hypothenuse = 0;
            //if (Vector2.Distance(new Vector2(0, 0), punktMaus) > Vector2.Distance(new Vector2(0, 0), punktA))
            //{ hypothenuse = Vector2.Distance(punkt0, punktMaus); }
            //else
            //{ hypothenuse = Vector2.Distance(punkt0, punktA); }
            //Debug.Log("Hypothenuse = " + hypothenuse);
            
            //float gegenhypo = gegenkathete/hypothenuse;
            //Debug.Log("gegenhypo = " + gegenhypo);

            ////Debug.Log("Alpha = " + (Mathf.Asin(gegenhypo)*Mathf.Rad2Deg));
            //Debug.Log("NewAlpha = " + (intAlpha + (Mathf.Asin(gegenhypo) * Mathf.Rad2Deg)));




            //float alpha = (2f * Mathf.PI) / 20;
            ////(camera.ScreenToWorldPoint(Input.mousePosition).x)
            


            float winkelteil = 360f / 20f;

            int volleTeile = (int)(winkel / winkelteil);
            float rest = winkel%winkelteil;

            Debug.Log(volleTeile);
            Debug.Log(rest);
            float neuerWinkel = volleTeile*winkelteil;
            if (rest >= (winkelteil / 2)) volleTeile += 1;

            float alphaD = (2f * Mathf.PI) / 20;

            Vector3 newPosition = prefabGebaeude.transform.position;
            newPosition.x = Mathf.Cos((volleTeile+5)*alphaD) *prefabGebaeude.transform.position.y;
            newPosition.y = Mathf.Sin((volleTeile+5)*alphaD) *prefabGebaeude.transform.position.y;
            //newPosition.z = 0;

            instanzGebaeude.transform.position = newPosition;
            instanzGebaeude.transform.LookAt(new Vector3(0, 0, 0));

            if (Input.GetMouseButton(1))
            {
                istAmBauen = false;
                instanzGebaeude = null;
            }

        }
        else
        {

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


            }
        }
    }
}
