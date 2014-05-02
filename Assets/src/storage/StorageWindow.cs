using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageWindow : MonoBehaviour {


    public StorageMaster stoMaster;

    public enum MaterialType { Cole, Oil, Ore, Gold, Diamond};
    public MaterialType mType;

    public int maxStorageValue = 1000;
    public int currentStorageValue = 0;

    public Dictionary<MaterialType, int> materialData = new Dictionary<MaterialType,int>();
    


	// Use this for initialization
	void Start () {

        FillDictionary();

        stoMaster = this.GetComponent<StorageMaster>();

        
	} // END Start
	
	// Update is called once per frame
	void Update () {
	
	} // END Update


    void FillDictionary()
    {

        materialData.Add(MaterialType.Cole, 0);
        materialData.Add(MaterialType.Ore, 0);
        materialData.Add(MaterialType.Oil, 0);
        materialData.Add(MaterialType.Gold, 0);
        materialData.Add(MaterialType.Diamond, 0);
    } // END FillDictionary






}
