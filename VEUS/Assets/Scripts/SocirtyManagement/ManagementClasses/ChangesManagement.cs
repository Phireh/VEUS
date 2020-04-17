using System;
using System.Collections;
using System.Collections.Generic;

public class ChangesManagement
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    List<Change> allChanges;

    /////////////////
    // Constructor //
    /////////////////

    public ChangesManagement()
    {
        allChanges = new List<Change>();
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public bool AddValueChange<T>(Action<T> setter, T newValue)
    {
        ValueChange<T> newChange = new ValueChange<T>(setter, newValue);
        if (allChanges.Contains(newChange) || !newValue.GetType().BaseType.IsEnum) return false;
        allChanges.Add(newChange);
        return true;
    }

    public bool RemoveValueChange<T>(Action<T> setter, T newValue)
    {
        ValueChange<T> newChange = new ValueChange<T>(setter, newValue);
        if (allChanges.Contains(newChange) || !newValue.GetType().BaseType.IsEnum) return false;
        allChanges.Add(newChange);
        return true;
    }

    public override string ToString()
    {
        string res = "Number of pending changes: " + allChanges.Count + "\n";
        foreach (Change c in allChanges) res += c.ToString() + "   ";
        return res;
    }
}
