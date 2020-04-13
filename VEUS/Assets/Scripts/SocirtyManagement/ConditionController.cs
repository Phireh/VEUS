using System;
using System.Collections;
using System.Collections.Generic;

public static class ConditionController
{
    ///////////////
    // Variables //
    ///////////////

    static List<Condition> allConditions = new List<Condition>();

    /////////////
    // Methods //
    /////////////

    public static bool AddCondition(Condition newCondition)
    {
        if (allConditions.Contains(newCondition)) return false; // TODO: Is this too slow. Is it relevant?
        allConditions.Add(newCondition);
        return true;
    }

    public static int ApplyAllConditions()
    {
        int count = 0;
        foreach (Condition c in allConditions)
            if (c.ApplyCondition())
            {
                allConditions.Remove(c);
                count++;
            }
        return count;
    }

    public static int GetNumberOfConditions() { return allConditions.Count; }

}
