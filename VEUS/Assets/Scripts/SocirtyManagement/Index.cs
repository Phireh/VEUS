using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Index
{
    //////////////////////
    // Static Component //
    //////////////////////

    public static int idCounter = 0;
    public static Dictionary<int, Index> indexesDict = new Dictionary<int, Index>();
    static int errorMarginInAnIndexChange = 20;
    /// <summary>
    /// ChangeIndexValue has a parameter to introduce random variations in the resul oof the operation.
    /// The biggest this variable gets, the greater the variations will be (default = 20; 0 => fixed changes)
    /// </summary>
    public static int ErrorMarginInAnIndexChange
    {
        get { return errorMarginInAnIndexChange; }
        set
        {
            if (value < 0) errorMarginInAnIndexChange = 0;
            else if (value > 100) errorMarginInAnIndexChange = 100;
            else errorMarginInAnIndexChange = value;
        }
    }

    /// <summary>
    /// Describes the value of the index
    /// </summary>
    public enum STATE
    {
        MIN = 0,
        VERY_LOW = 1,
        LOW = 2,
        MEDIUM = 3,
        HIGH = 4,
        VERY_HIGH = 5,
        MAX = 6
    }
    public static int[] indexStateMaxLimitValues = new int[]
    {
        0,      // MIN
        20,     // VERY_LOW
        40,     // LOW
        60,     // MEDIUM
        80,     // HIGH
        99,     // VERY_HIGH
        100     // MAX
    };
    /// <summary>
    /// Used along with the ChamgeIndexValueMethod()
    /// </summary>
    public enum CHANGE
    {
        GREAT_DROP = 0,
        DROP = 1,
        LOW_DROP = 2,
        IMPERCENTIBLE = 3,
        LOW_INCREASE = 4,
        INCREASE = 5,
        GREAT_INCREASE = 6
    }
    public static int[] indexChangeLimitValues = new int[]
    {
        -50,    // GREAT_DROP
        -30,    // DROP
        -15,    // LOW_DROP
        0,      // IMPERCEPTIBLE
        15,     // LOW_INCREASE
        30,     // INCREASE
        50,     // GREAT_INCREASE
    };

    /// <summary>
    /// Returns a float between two values determined by the state
    /// </summary>
    /// <param name="state">State to determine the value range</param>
    /// <returns>
    /// MIN [0] | VERY_LOW (0,0.2] | LOW (0.2,0.4] | MEDIUM (0.4,0.6] | 
    /// HIGH (0.6,0.8] | VERY_HIGH (0.8,1) | MAX [1]
    /// </returns>
    public static float GetRoughValueFromState(STATE state)
    {
        switch (state)
        {
            case STATE.MAX:
                return indexStateMaxLimitValues[(int)STATE.MAX] / 100f;
            case STATE.VERY_HIGH:
                return GlobalMethods.GetRandom(indexStateMaxLimitValues[(int)STATE.HIGH], indexStateMaxLimitValues[(int)STATE.VERY_HIGH]) / 100f;
            case STATE.HIGH:
                return GlobalMethods.GetRandom(indexStateMaxLimitValues[(int)STATE.MEDIUM], indexStateMaxLimitValues[(int)STATE.HIGH]) / 100f;
            case STATE.MEDIUM:
                return GlobalMethods.GetRandom(indexStateMaxLimitValues[(int)STATE.LOW], indexStateMaxLimitValues[(int)STATE.MEDIUM]) / 100f;
            case STATE.LOW:
                return GlobalMethods.GetRandom(indexStateMaxLimitValues[(int)STATE.VERY_LOW], indexStateMaxLimitValues[(int)STATE.LOW]) / 100f;
            case STATE.VERY_LOW:
                return GlobalMethods.GetRandom(indexStateMaxLimitValues[(int)STATE.MIN], indexStateMaxLimitValues[(int)STATE.VERY_LOW]) / 100f;
            case STATE.MIN:
            default:
                return indexStateMaxLimitValues[(int)STATE.MIN];
        }
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    bool isMin, isMax;
    protected float baseValue;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public int ID { get; private set; } // ID repesentind the index
    public string Name { get; private set; } // Name of the index
    public string Description { get; private set; } // Description of the index
    public float Value
    {
        get { return GetIndexValue(); }
        set
        {
            isMin = false; isMax = false;
            if (value < 0.001f)
            {
                this.baseValue = 0f;
                isMin = true;
            }
            else if (value > 0.999f)
            {
                this.baseValue = 1f;
                isMax = true;
            }
            else this.baseValue = value;
        }
    }

    //////////////////
    // Constructors //
    //////////////////

    /// <summary>
    /// Creates a new index. Dependency free
    /// </summary>
    /// <param name="name">Name of the index</param>
    /// <param name="description">Description of the index</param>
    /// <param name="value">Independent value of the index</param>
    public Index(string name, string description, float value)
    {
        Name = name;
        Description = description;
        Value = value; // Must be done aftter dependencies is initiallized, otherwise it will throw a exception
        ID = idCounter++;
        indexesDict.Add(ID, this);
    }

    /////////////////////
    // Private Methods //
    /////////////////////

    protected abstract float GetIndexValue();

    ////////////////////
    // Public Methods //
    ////////////////////

    /// <summary>
    /// Changes the base value of the index
    /// </summary>
    /// <param name="change">Degree of the change</param>
    /// <param name="errorMargin">Error allowed in the operation (to make it a bit more random)</param>
    /// <returns></returns>
    public STATE ChangeIndexValue(CHANGE change, int errorMargin)
    {
        if (errorMargin > 100) errorMargin = 100;
        else if (errorMargin < 0) errorMargin = 0;
        float error = 1f + (GlobalMethods.GetRandom(-errorMargin, errorMargin) / 100f);
        Value += (indexChangeLimitValues[(int)change] * error) / 100f;
        return GetIndexState();
    }

    /// <summary>
    /// Changes the base value of the index
    /// </summary>
    /// <param name="change">Degree of the change. The error margin is 20%</param>
    /// <returns></returns>
    public STATE ChangeIndexValue(CHANGE change) { return ChangeIndexValue(change, ErrorMarginInAnIndexChange); }

    /// <summary>
    /// Returns the index state depending on its value
    /// </summary>
    /// <returns>
    /// MIN [0%] | VERY_LOW (0% - 20%] | LOW (20% - 40%] | MEDIUM (40% -60%] | 
    /// HIGH (60% - 80%] | VERY_HIGH (80% - 100%) | MAX [100%]
    /// </returns>
    public STATE GetIndexState()
    {
        if (isMax) return STATE.MAX;
        else if (Value > 0.8f) return STATE.VERY_HIGH;
        else if (Value > 0.6f) return STATE.HIGH;
        else if (Value > 0.4f) return STATE.MEDIUM;
        else if (Value > 0.2f) return STATE.LOW;
        else if (Value > 0f) return STATE.VERY_LOW;
        else /*if (isMin)*/ return STATE.MIN;
    }

}

public class ConditionableIndex : Index
{
    public ConditionableIndex(string name, string description, float value) : base(name, description, value) { }

    protected override float GetIndexValue() { return baseValue; }

    public override string ToString()
    {
        return "_" + ID + "_ => " + Name + ": \"" + Description + "\" | Valor Base: (" + Value + ")";
    }
}

public class DependentIndex : ConditionableIndex
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    List<Dependency> dependencies; // List of Dependency objects affecting the index
    HashSet<int> influencers; // IDs of th influent indexes

    //////////////////
    // Constructors //
    //////////////////

    public DependentIndex(string name, string description, float value) : base(name, description, value)
    {
        this.dependencies = new List<Dependency>();
        influencers = new HashSet<int>();
    }

    /////////////////////
    // Private Methods //
    /////////////////////

    protected override float GetIndexValue()
    {
        float aux = baseValue;
        foreach (Dependency d in dependencies)
            aux += d.RealInfluence;
        return aux;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public void AddDependency(Dependency newDependency)
    {
        int influencerID = newDependency.Influencer.ID;
        if (!influencers.Contains(influencerID))
        {
            dependencies.Add(newDependency);
            influencers.Add(influencerID);
        }
        else GlobalMethods.PrintError("El índice _" + influencerID + "_ ya ejercía influencia sobre _" + ID + "_");
    }

    public void RemoveDependency(Index i)
    {
        if (influencers.Contains(i.ID))
        {
            foreach (Dependency d in dependencies)
                if (d.Influencer.ID == i.ID)
                {
                    dependencies.Remove(d);
                    influencers.Remove(i.ID);
                    break;
                }
        }
        else GlobalMethods.PrintError("El índice _" + i.ID + "_ no ejercía influencia sobre _" + ID + "_");
    }

    public override string ToString()
    {
        string res = "_" + ID + "_ => " + Name + ": \"" + Description + "\" | Valor Base: (" + baseValue + ") Valor Influído [" + Value + "] Dependencies: ";
        foreach (Dependency d in dependencies) res += d.Influencer.ID + " - ";
        return res;
    }
}
