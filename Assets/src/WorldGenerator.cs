﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using BODENARTEN = CellControl.BODENARTEN;

public class WorldGenerator : MonoBehaviour
{


    public List<GameObject> prefabLagen;
    public int maximaleZellenProLage = 20;

    private

    // Use this for initialization
    void Start()
    {
        float verschubDerErstenZelle = maximaleZellenProLage / 4;
        float gradwechselProZelle = 360f / maximaleZellenProLage;
        float alpha = (2f * Mathf.PI) / maximaleZellenProLage;




        for (int aktuelleLage = 0; aktuelleLage < prefabLagen.Count; aktuelleLage++)
        {
            GameObject objektLage = new GameObject();
            objektLage.name = "Lage " + (aktuelleLage + 1);
            objektLage.transform.parent = gameObject.transform;

            Vector3 aktuellePosition = prefabLagen[aktuelleLage].transform.position;
            Dictionary<int, BODENARTEN> prozentWahrscheinlichkeit = Wahrscheinlichkeiten(aktuelleLage + 1);

            for (int aktuelleZelle = 0; aktuelleZelle < maximaleZellenProLage; aktuelleZelle++)
            {
                aktuellePosition.x = Mathf.Cos((verschubDerErstenZelle + aktuelleZelle) * alpha) * prefabLagen[aktuelleLage].transform.position.y;
                aktuellePosition.y = Mathf.Sin((verschubDerErstenZelle + aktuelleZelle) * alpha) * prefabLagen[aktuelleLage].transform.position.y;
                //float posX = Mathf.Cos(-4+aktuelleZelle + ((Mathf.PI * 2) / maximaleZellenProLage)) * prefabLagen[aktuelleLage].transform.position.y;
                //float posY = Mathf.Sin(-4 + aktuelleZelle + ((Mathf.PI * 2) / maximaleZellenProLage)) * prefabLagen[aktuelleLage].transform.position.y; ;

                GameObject objektZelle = (GameObject)Instantiate(prefabLagen[aktuelleLage]);
                objektZelle.transform.parent = objektLage.transform;
                objektZelle.transform.Rotate(0, 0, gradwechselProZelle * aktuelleZelle, 0);
                objektZelle.transform.position = aktuellePosition;

                CellControl cellControl = objektZelle.GetComponent<CellControl>();
                cellControl.zelle = aktuelleZelle + 1;
                cellControl.lage = aktuelleLage + 1;
                cellControl.bodenart = prozentWahrscheinlichkeit[Mathf.Clamp((int)(UnityEngine.Random.value * 100), 1, 100)];


                cellControl.menge = GetMenge(aktuelleLage + 1);

                //                Kreisbahn: alpha von 0..2*pi  C#-Quelltext 	markieren 
                // 1:
                // 2:
                // 3:
                // 4:
                // 5:
                //        dAlpha = 2*pi/Anzahl; 
                //for (float alpha;alpha < 2*pi;alpha+= dAlpha){   
                //   x = radius*cosinus( alpha); 
                //   y = radius*sinus( alpha); 
                //   Ausgabe...}


            }

        }


    }


    private int GetMenge(int lage)
    {
        int min = 0;
        int max = 0;

        switch (lage)
        {
            case 1:
                min = 100;
                max = 100;
                break;
            case 2:
                min = 100;
                max = 100;
                break;
            case 3:
                min = 100;
                max = 100;
                break;
            case 4:
                min = 100;
                max = 100;
                break;
            case 5:
                min = 100;
                max = 100;
                break;
            case 6:
                min = 100;
                max = 100;
                break;
            case 7:
                min = 100;
                max = 100;
                break;
            case 8:
                min = 100;
                max = 100;
                break;
            case 9:
                min = 100;
                max = 100;
                break;
            case 10:
                min = 100;
                max = 100;
                break;
            case 11:
                min = 100;
                max = 100;
                break;
            case 12:
                min = 100;
                max = 100;
                break;
            case 13:
                min = 100;
                max = 100;
                break;
            case 14:
                min = 100;
                max = 100;
                break;
            case 15:
                min = 100;
                max = 100;
                break;
            case 16:
                min = 2500;
                max = 8000;
                break;
            case 17:
                min = 2000;
                max = 7000;
                break;
            case 18:
                min = 1500;
                max = 6000;
                break;
            case 19:
                min = 1000;
                max = 5000;
                break;
        }
        return (int)((UnityEngine.Random.value * (max - min)) + min); //new System.Random().Next(min,max);
    }

    private Dictionary<int, BODENARTEN> Wahrscheinlichkeiten(int fuerLage)
    {
        Dictionary<BODENARTEN, int> wahrscheinlichkeiten = new Dictionary<BODENARTEN, int>();
        Dictionary<int, BODENARTEN> prozentWahrscheinlichkeit = new Dictionary<int, BODENARTEN>();
        float checkvalue = 0;
        int aktuellePos = 1;

        for (int i = 0; i <= Enum.GetNames(typeof(BODENARTEN)).Length; i++) { wahrscheinlichkeiten[(BODENARTEN)i] = 0; }
        for (int i = 1;  i <= 100;i++) {prozentWahrscheinlichkeit[i] = BODENARTEN.Dreck;}

        switch (fuerLage)
        {
            case 1:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 14;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 3;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 3;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 0;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 40;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 0;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 4;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 6;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 0;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 30;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;

                break;
            case 2:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 8;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 4;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 5;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 3;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 35;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 5;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 5;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 5;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 0;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 30;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;
                break;
            case 3:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 7;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 5;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 5;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 5;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 30;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 8;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 7;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 6;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 2;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 25;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;
                break;
            case 4:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 5;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 12;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 5;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 7;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 25;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 10;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 12;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 12;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 2;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 10;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;
                break;
            case 5:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 5;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 12;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 5;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 7;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 25;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 10;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 12;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 12;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 2;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 10;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;
                break;
            case 6:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 3;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 12;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 12;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 8;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 10;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 13;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 12;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 20;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 5;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 5;
                break;
            case 7:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 3;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 12;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 12;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 8;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 7;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 10;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 17;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 18;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 5;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 8;
                break;
            case 8:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 13;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 12;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 9;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 7;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 13;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 15;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 20;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 5;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 5;
                break;
            case 9:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 13;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 15;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 10;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 7;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 10;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 14;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 20;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 5;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 5;
                break;
            case 10:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 18;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 8;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 5;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 9;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 17;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 9;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 10;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 8;
                break;
            case 11:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 18;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 8;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 5;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 8;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 18;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 9;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 10;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 8;
                break;
            case 12:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 18;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 8;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 5;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 8;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 18;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 6;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 11;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 10;
                break;
            case 13:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 1;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 18;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 4;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 3;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 8;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 15;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 10;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 11;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 15;
                break;
            case 14:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 23;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 4;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 3;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 3;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 10;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 14;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 18;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 10;
                break;
            case 15:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 15;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 30;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 3;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 2;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 3;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 8;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 12;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 20;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 7;
                break;
            case 16:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 14;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 30;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 2;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 1;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 3;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 8;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 12;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 20;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 10;
                break;
            case 17:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 12;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 35;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 2;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 0;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 0;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 8;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 10;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 32;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 1;
                break;
            case 18:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 8;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 30;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 1;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 0;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 0;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 5;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 15;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 40;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 1;
                break;
            case 19:
                wahrscheinlichkeiten[BODENARTEN.Diamant] = 0;
                wahrscheinlichkeiten[BODENARTEN.Kohle] = 5;
                wahrscheinlichkeiten[BODENARTEN.Dreck] = 40;
                wahrscheinlichkeiten[BODENARTEN.Gold] = 1;
                wahrscheinlichkeiten[BODENARTEN.Magma] = 0;
                wahrscheinlichkeiten[BODENARTEN.Oel] = 0;
                wahrscheinlichkeiten[BODENARTEN.Erz] = 3;
                wahrscheinlichkeiten[BODENARTEN.Stein] = 5;
                wahrscheinlichkeiten[BODENARTEN.Wasser] = 46;
                wahrscheinlichkeiten[BODENARTEN.Obsidian] = 0;
                wahrscheinlichkeiten[BODENARTEN.Marmor] = 0;
                break;

            //      Kohle, Diamant, Dreck, Gold, Magma, Oel, Erz, Stein, Wasser 
        }


        for (int i = 0; i <= Enum.GetNames(typeof(BODENARTEN)).Length; i++) { checkvalue += wahrscheinlichkeiten[(BODENARTEN)i]; }
        if (checkvalue != 100) { Debug.Log("Der Checkvalue für die Lage " + fuerLage + " ist nicht korrekt, statt 100 hat dieser den Wert " + checkvalue); return prozentWahrscheinlichkeit; }



        for (int i = 0; i <= Enum.GetNames(typeof(BODENARTEN)).Length; i++)
        {
            for (int j = 0; j < wahrscheinlichkeiten[(BODENARTEN)i]; j++)
            {
                prozentWahrscheinlichkeit[aktuellePos] = (BODENARTEN)i;
                aktuellePos++;
            }
        }

        return prozentWahrscheinlichkeit;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
