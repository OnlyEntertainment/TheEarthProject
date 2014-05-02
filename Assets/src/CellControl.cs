using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CellControl : MonoBehaviour
{

    // Variablen

    public int lage;
    public int zelle;

    public BODENARTEN bodenart;
    public float menge = 0;


    //public int cellNumber;

    //public int amount = 0;
    //public bool labPointsBool = false;
    //public int labPoints = 0;

    public enum BODENARTEN { Kohle, Diamant, Dreck, Gold, Magma, Oel, Erz, Stein, Wasser, Obsidian, Marmor };


     
    //

    public TextureContainer texContainer;

    void Awake()
    {

        

    }

    // Use this for initialization
    void Start()
    {
        GameObject texContainerObject = GameObject.Find("00_TextureContainer");
        texContainer = texContainerObject.GetComponentInChildren<TextureContainer>();


        //texContainer = texContainerObject.GetComponent<TextureContainer>();

        LoadTexture();
    }

    // Update is called once per frame
    void Update()
    {

        //LoadTexture();

    }


    void LoadTexture()
    {

        switch (bodenart)
        {
            case BODENARTEN.Dreck:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[0]);
                break;
            case BODENARTEN.Wasser:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[1]);
                break;
            case BODENARTEN.Stein:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[2]);
                break;
            case BODENARTEN.Magma:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[3]);
                break;
            case BODENARTEN.Erz:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[4]);
                break;
            case BODENARTEN.Kohle:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[5]);
                break;
            case BODENARTEN.Gold:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[6]);
                break;
            case BODENARTEN.Diamant:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[7]);
                break;
            case BODENARTEN.Oel:
                gameObject.transform.GetChild(0).renderer.material.SetTexture(0, texContainer.textureArray[8]);
                break;
                
        }
    }

  


}
