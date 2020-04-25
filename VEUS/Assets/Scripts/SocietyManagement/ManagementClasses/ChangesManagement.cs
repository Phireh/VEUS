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
        if (allChanges.Contains(newChange)) // || !newValue.GetType().BaseType.IsEnum
        {
            Global.Methods.PrintError("This value change was added previously: " + newChange);
            return false;
        }
        allChanges.Add(newChange);
        Global.Methods.PrintInfo("New value change added: " + newChange);
        return true;
    }

    public bool AddIndexChange(Index target, Index.CHANGE change)
    {
        IndexChange newChange = new IndexChange(target, change);
        if (allChanges.Contains(newChange))
        {
            Global.Methods.PrintError("This index change was added previously: " + newChange);
            return false;
        }
        allChanges.Add(newChange);
        Global.Methods.PrintInfo("New value change added: " + newChange);
        return true;
    }

    public bool RemoveValueChange<T>(Action<T> setter, T newValue)
    {
        ValueChange<T> newChange = new ValueChange<T>(setter, newValue);
        if (allChanges.Contains(newChange) || !newValue.GetType().BaseType.IsEnum) return false;
        allChanges.Add(newChange);
        return true;
    }

    public int ApplyAllChanges()
    {
        int count = 0;
        foreach (Change c in allChanges)
        {
            Global.Methods.PrintInfo("Applying the change " + c);
            c.ApplyChange();
            count++;
        }
        allChanges.Clear();
        return count;
    }

    public override string ToString()
    {
        string res = "Number of pending changes: " + allChanges.Count + "\n";
        foreach (Change c in allChanges) res += c.ToString() + "   ";
        return res;
    }
}
