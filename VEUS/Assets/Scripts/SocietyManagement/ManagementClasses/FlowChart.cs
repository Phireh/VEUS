using System;
using System.Collections;
using System.Collections.Generic;

public static class FlowChart
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    static List<Dependency> allDependencies = new List<Dependency>();
    static Dictionary<int, Index> indexDict = new Dictionary<int, Index>();
    static Dictionary<int, List<int>> indexInfluenciesDict = new Dictionary<int, List<int>>();

    ////////////////////
    // Public Methods //
    ////////////////////

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

    //public static int GetNumberOfConditions() { return allConditions.Count; }
    public static Index GetIndexFromID(int id) => indexDict[id];

    public static string GetString()
    {
        string res = "All Indexes:\n";
        foreach (Index i in indexDict.Values) res += i.ToString() + "\n";
        res = "All Dependencies:\n";
        foreach (Dependency d in allDependencies) res += d.ToString() + "\n";
        return res;
    }
}
