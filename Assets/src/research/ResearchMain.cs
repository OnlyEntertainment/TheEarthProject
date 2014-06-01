using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchMain {

    public string researchTitle;  
    public int currentLevel;
    public int maxLevel;
    public List<int> costsMoney;
    public List<int> costsResearch;
    public List<int> valueStep;
    public List<float> researchTime;
    public enum rType { Speed, Amount, Drill, BuildCosts, DrillingPlattform, Scan };
    public rType researchType;


    public ResearchMain (string researchTitleTemp, int currentLevelTemp, int maxLevelTemp, List<int> moneyCostsTemp, List<int> researchCostsTemp, List<int> valueStepTemp, List<float>researchTimeTemp, rType researchTypeTemp)
    {

        researchTitle = researchTitleTemp;
        currentLevel = currentLevelTemp;
        maxLevel = maxLevelTemp;
        costsMoney = moneyCostsTemp;
        costsResearch = researchCostsTemp;
        valueStep = valueStepTemp;
        researchTime = researchTimeTemp;
        researchType = researchTypeTemp;


    }

    public static Dictionary<rType, ResearchMain> GenerateResearch()
    {

        Dictionary<rType, ResearchMain> researchDict = new Dictionary<rType,ResearchMain>();


        researchDict.Add(rType.Speed, new ResearchMain("Speed", 0, 5,new List<int>{250,500,750,1000,2500}, new List<int>{5,10,15,20,25}, new List<int>{5,10,15,20,25}, new List<float>{4.5f,4.0f,3.5f,3.0f,2.5f}, rType.Speed));
        researchDict.Add(rType.Amount, new ResearchMain("Amount", 0, 5, new List<int> { 250, 500, 750, 1000, 2500 }, new List<int> { 5, 10, 15, 20, 25 }, new List<int> { 5, 10, 15, 20, 25 }, new List<float> { 4.5f, 4.0f, 3.5f, 3.0f, 2.5f }, rType.Amount));
        researchDict.Add(rType.BuildCosts, new ResearchMain("Building Cost", 0, 3, new List<int> { 250, 500, 750, 1000, 2500 }, new List<int> { 5, 10, 15, 20, 25 }, new List<int> { 3, 5, 7, 10, 15 }, new List<float> { 3.0f, 5.0f, 7.5f, 10.0f, 15.0f }, rType.BuildCosts));
        researchDict.Add(rType.Drill, new ResearchMain("Drill", 0, 5, new List<int> { 250, 500, 750, 1000, 2500 }, new List<int> { 5, 10, 15, 20, 25 }, new List<int> { 1, 2, 3, 4, 5 }, new List<float> { 5.0f, 4.0f, 3.5f, 3.0f, 2.5f }, rType.Drill));
        researchDict.Add(rType.DrillingPlattform, new ResearchMain("Drilling Plattform", 0, 1, new List<int> { 15000 }, new List<int> { 50 }, new List<int> { 1 }, new List<float> { 10.0f }, rType.DrillingPlattform));
        researchDict.Add(rType.Scan, new ResearchMain("Scan", 0, 5, new List<int> { 250, 500, 750, 1000, 2500 }, new List<int> { 5, 10, 15, 20, 25 }, new List<int> { 1, 2, 3, 4, 5 }, new List<float> { 4.5f, 4.0f, 3.5f, 3.0f, 2.5f }, rType.Scan));

        return researchDict;

    }
    
   

}
