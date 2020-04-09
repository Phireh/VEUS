using System;
using System.Collections;
using System.Collections.Generic;

public class Index
{
    public static Random rand = new Random();

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
        99,    // VERY_HIGH
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

    ///////////////////////
    // Private Variables //
    ///////////////////////

    bool isMin;
    bool isMax;
    string name;
    string description;
    float baseValue;
    float value;
    List<Dependency> dependencies;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    // Name of the index [10 characters or less]
    public string Name
    {
        get { return name; }
        private set { if (value.Length < 21) name = value; } // Names can be 20 characters long as much
    }
    // Description of the index
    public string Description
    {
        get { return description; }
        private set { description = value; }
    }
    // Value of the index [0..1] (0 - 100%)
    public float BaseValue
    {
        get { return baseValue; }
        private set
        {
            if (value < 0.001) baseValue = 0f;
            else if (value > 0.999) baseValue = 1f;
            else baseValue = value;
            UpdateDependentValue();
        }
    }
    public float Value
    {
        get { return value; }
        private set
        {
            isMin = false; isMax = false;
            if (value < 0.001f)
            {
                this.value = 0f;
                isMin = true;
            }
            else if (value > 0.999f)
            {
                this.value = 1f;
                isMax = true;
            }
            else this.value = value;
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
        dependencies = new List<Dependency>();
        Name = name;
        Description = description;
        BaseValue = value; // Must be done aftter dependencies is initiallized, otherwise it will throw a exception
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    /// <summary>
    /// Updates the dependent value. This value is the result of calculating the
    /// influence of the dependencies on the base value of the index
    /// </summary>
    void UpdateDependentValue()
    {
        float aux = BaseValue;
        foreach (Dependency d in this.dependencies)
        {
            switch (d.DependencyType)
            {
                case Dependency.TYPE.ADDITION:
                    aux += (d.Influence / 100f) * d.Influencer.Value;
                    break;
                case Dependency.TYPE.SUBSTRACTION:
                    aux += (d.Influence / 100f) * d.Influencer.Value;
                    break;
                case Dependency.TYPE.REVERSE_SUBSTRACTION:
                    aux -= (d.Influence - d.Influence * d.Influencer.Value);
                    break;
                case Dependency.TYPE.REVERSE_ADDITION:
                default:
                    aux -= (d.Influence - d.Influence * d.Influencer.Value);
                    break;
            }
        }
        Value = aux;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    /// <summary>
    /// Adds a new dependency to the Index. Dependencies influence the Value of the index
    /// </summary>
    /// <param name="newDependency">The new dependency</param>
    public void AddDependency(Dependency newDependency)
    {
        dependencies.Add(newDependency);
        UpdateDependentValue();
    }

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
        float error = 1f + (rand.Next(-errorMargin, errorMargin) / 100f);
        BaseValue += (indexChangeLimitValues[(int)change] * error) / 100f;
        return GetIndexState();
    }

    /// <summary>
    /// Changes the base value of the index
    /// </summary>
    /// <param name="change">Degree of the change. The error margin is 20%</param>
    /// <returns></returns>
    public STATE ChangeIndexValue(CHANGE change) { return ChangeIndexValue(change, 20); }

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
                return rand.Next(indexStateMaxLimitValues[(int)STATE.HIGH], indexStateMaxLimitValues[(int)STATE.VERY_HIGH]) / 100f;
            case STATE.HIGH:
                return rand.Next(indexStateMaxLimitValues[(int)STATE.MEDIUM], indexStateMaxLimitValues[(int)STATE.HIGH]) / 100f;
            case STATE.MEDIUM:
                return rand.Next(indexStateMaxLimitValues[(int)STATE.LOW], indexStateMaxLimitValues[(int)STATE.MEDIUM]) / 100f;
            case STATE.LOW:
                return rand.Next(indexStateMaxLimitValues[(int)STATE.VERY_LOW], indexStateMaxLimitValues[(int)STATE.LOW]) / 100f;
            case STATE.VERY_LOW:
                return rand.Next(indexStateMaxLimitValues[(int)STATE.MIN], indexStateMaxLimitValues[(int)STATE.VERY_LOW]) / 100f;
            case STATE.MIN:
            default:
                return indexStateMaxLimitValues[(int)STATE.MIN];
        }
    }
}
