using System;
using System.Collections;
using System.Collections.Generic;

public static class FlowChartController
{
    ///////////////
    // Variables //
    ///////////////

    static List<Condition> allConditions = new List<Condition>();
    static List<Dependency> allDependencies = new List<Dependency>();
    static Dictionary<int, Index> indexDict = new Dictionary<int, Index>();
    static Dictionary<int, List<int>> indexInfluenciesDict = new Dictionary<int, List<int>>();

    /////////////
    // Methods //
    /////////////

    public static bool AddCondition(Condition newCondition)
    {
        if (allConditions.Contains(newCondition)) return false; // TODO: Is this too slow. Is it relevant?
        allConditions.Add(newCondition);
        return true;
    }
    public static bool AddIndex(Index i)
    {
        if (indexDict.ContainsKey(i.ID)) return false;
        indexDict.Add(i.ID, i);
        indexInfluenciesDict.Add(i.ID, new List<int>());
        return true;
    }
    public static bool AddDependency(Dependency d)
    {
        if (indexInfluenciesDict[d.From.ID].Contains(d.To.ID)) return false;
        indexInfluenciesDict[d.From.ID].Add(d.To.ID);
        allDependencies.Add(d);
        return true;
    }

    public static bool RemoveDependency(Dependency d)
    {
        if (!indexInfluenciesDict[d.From.ID].Contains(d.To.ID)) return false;
        else indexInfluenciesDict[d.From.ID].Remove(d.To.ID);
        return true;
    }

    public static int GetNumberOfConditions() { return allConditions.Count; }
    public static Index GetIndexFromID(int id) => indexDict[id];

    public static int ApplyAllConditions()
    {
        int count = 0;
        List<Condition> toRemove = new List<Condition>();
        foreach (Condition c in allConditions)
            if (c.ApplyCondition())
            {
                toRemove.Add(c);
                count++;
            }
        foreach (Condition c in toRemove)
            allConditions.Remove(c);
        return count;
    }
    public static void ApplyAllDependencies() {
        foreach (Dependency d in allDependencies)
            d.ApplyInfluence();
    }

    
}
