using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Index
{
    //////////////////////
    // Static Component //
    //////////////////////

    public static int idCounter = 0;
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
        MINIMIZE = 0,
        GREAT_DROP = 1,
        DROP = 2,
        LOW_DROP = 3,
        IMPERCENTIBLE = 4,
        LOW_INCREASE = 5,
        INCREASE = 6,
        GREAT_INCREASE = 7,
        MAXIMIZE = 8
    }
    public static int[] indexChangeLimitValues = new int[]
    {
        -100,   // MINIMIZE
        -50,    // GREAT_DROP
        -30,    // DROP
        -15,    // LOW_DROP
        0,      // IMPERCEPTIBLE
        15,     // LOW_INCREASE
        30,     // INCREASE
        50,     // GREAT_INCREASE
        100     // MAXIMIZE
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
                return Global.Methods.GetRandomPercentage(indexStateMaxLimitValues[(int)STATE.HIGH], indexStateMaxLimitValues[(int)STATE.VERY_HIGH]) / 100f;
            case STATE.HIGH:
                return Global.Methods.GetRandomPercentage(indexStateMaxLimitValues[(int)STATE.MEDIUM], indexStateMaxLimitValues[(int)STATE.HIGH]) / 100f;
            case STATE.MEDIUM:
                return Global.Methods.GetRandomPercentage(indexStateMaxLimitValues[(int)STATE.LOW], indexStateMaxLimitValues[(int)STATE.MEDIUM]) / 100f;
            case STATE.LOW:
                return Global.Methods.GetRandomPercentage(indexStateMaxLimitValues[(int)STATE.VERY_LOW], indexStateMaxLimitValues[(int)STATE.LOW]) / 100f;
            case STATE.VERY_LOW:
                return Global.Methods.GetRandomPercentage(indexStateMaxLimitValues[(int)STATE.MIN], indexStateMaxLimitValues[(int)STATE.VERY_LOW]) / 100f;
            case STATE.MIN:
            default:
                return indexStateMaxLimitValues[(int)STATE.MIN];
        }
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    bool isMax;
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
            isMax = false;
            if (value < 0.001f)
                this.baseValue = 0f;
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
        FlowChartController.AddIndex(this);
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
        // If minimizing or maximizing changes are implied, there is no place for random results
        if (change == CHANGE.MINIMIZE)
        {                               
            Value = 0f;
            return STATE.MIN;
        }
        else if (change == CHANGE.MAXIMIZE)
        {
            Value = 1f;
            return STATE.MAX;
        }

        if (errorMargin > 100) errorMargin = 100;
        else if (errorMargin < 0) errorMargin = 0;
        float error = 1f + (Global.Methods.GetRandomPercentage(-errorMargin, errorMargin) / 100f);
        Value += (indexChangeLimitValues[(int)change] * error) / 100f;
        return GetIndexState();
    }

    /// <summary>
    /// Changes the base value of the index
    /// </summary>
    /// <param name="change">Degree of the change. The error margin is 20%</param>
    /// <returns>The index state after the operation</returns>
    public STATE ChangeIndexValue(CHANGE change) => ChangeIndexValue(change, ErrorMarginInAnIndexChange); 
    /// <summary>
    /// Changes the base value of the index
    /// </summary>
    /// <param name="change">Exact change</param>
    /// <returns>The index state after the operation</returns>
    public STATE ChangeIndexValue(float change)
    {
        Value -= change;
        return GetIndexState();
    }

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

    protected override float GetIndexValue() => baseValue;

    public override string ToString()
    {
        return "Índice condicionable:[" + ID + "] => " + Name + ": \"" + Description + "\" | Valor Base: (" + Value + ")";
    }
}

public class DependentIndex : Index
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    HashSet<int> influencers; // IDs of th influent indexes
    float realInfluence;

    //////////////////
    // Constructors //
    //////////////////

    public DependentIndex(string name, string description, float value) : base(name, description, value)
    {
        influencers = new HashSet<int>();
    }

    /////////////////////
    // Private Methods //
    /////////////////////

    protected override float GetIndexValue() => baseValue + realInfluence;

    ////////////////////
    // Public Methods //
    ////////////////////

    public void AddDependency(Dependency newDependency)
    {
    }

    public void RemoveDependency(Index i)
    {

    }

    public void SetRealInfluence(float realInfluence) => this.realInfluence = realInfluence;

    public override string ToString()
    {
        string res = "Índice dependiente:[" + ID + "] => " + Name + ": \"" + Description + "\" | Valor Base: (" + baseValue + ") Valor Influído [" + Value + "] Dependencias: ";
        foreach (int d in influencers) res += d + "  ";
        return res;
    }
}
