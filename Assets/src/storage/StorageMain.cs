using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageMain {

    public string storageName;
    public int currentLevel;
    public int maxLevel;
    public List<int> costsMoney;
    public List<int> valueStep;



    public StorageMain(string storageNameTemp, int currentLevelTemp, int maxLevelTemp, List<int> moneyCostsTemp, List<int> valueStepTemp)
    {

        storageName = storageNameTemp;
        currentLevel = currentLevelTemp;
        maxLevel = maxLevelTemp;
        costsMoney = moneyCostsTemp;      
        valueStep = valueStepTemp;
        


	}
	
	
	public static Dictionary<string, StorageMain> GenerateStorage() {
	
        Dictionary<string, StorageMain> storageDict = new Dictionary<string,StorageMain>();

        storageDict.Add("Storage", new StorageMain("Storage", 0,10, new List<int>{100,200,300,400,500,600,700,800,900,1000}, new List<int>{1000,2000,3000,4000,5000,6000,7000,8000,9000,10000}));


        return storageDict;
	}
}
