using System;
using System.Collections;
using System.Collections.Generic;

public class Index
{
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

    /// <summary>
    /// Used along with the ChamgeIndexValueMethod()
    /// </summary>
    public enum CHANGE
    {
        GREAT_DROP = 0,
        DROP = 1,
        LOW_DROP = 2,
        LOW_INCREASE = 3,
        INCREASE = 4,
        GREAT_INCREASE = 5
    }

    bool isMin;
    bool isMax;
    string name;
    string description;
    float value;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

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
    public float Value
    {
        get { return value; }
        set {
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

    /////////////////////
    /// Constructors ///
    ////////////////////

    public Index()
    {
        Name = "Index Name";
        Description = "This Index represents something";
        Value = 0.5f;
    }

    public Index(string name, string description, float value)
    {
        Name = name;
        Description = description;
        Value = value;
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////

    public void DecrementIndexValue(float amount)
    {
        if (amount > 0f)
        {
            isMax = false;
            Value -= amount;
        }
    }

    public void IncrementIndexValue(float amount)
    {
        if (amount > 0f)
        {
            isMin = false;
            Value += amount;
        }
    }

    /// <summary>
    /// Changes de value of the indage
    /// </summary>
    /// <param name="change">Degree of the change</param>
    /// <returns>The index state after the change</returns>
    public STATE ChangeIndexValue(CHANGE change)
    {
        switch (change)
        {
            case CHANGE.GREAT_INCREASE:
                Value *= 2f;
                break;
            case CHANGE.INCREASE:
                Value *= 1.5f;
                break;
            case CHANGE.LOW_INCREASE:
                Value *= 1.25f;
                break;
            case CHANGE.LOW_DROP:
                Value *= 0.8f;
                break;
            case CHANGE.DROP:
                Value *= 0.666f;
                break;
            case CHANGE.GREAT_DROP:
            default:
                Value *= 0.5f;
                break;
        }
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
        else if (value > 0.8f) return STATE.VERY_HIGH;
        else if (value > 0.6f) return STATE.HIGH;
        else if (value > 0.4f) return STATE.MEDIUM;
        else if (value > 0.2f) return STATE.LOW;
        else if (value > 0f) return STATE.MIN;
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
        Random rand = new Random();
        switch (state)
        {
            case STATE.MAX:
                return 1f;
            case STATE.VERY_HIGH:
                return rand.Next(80, 100) / 100f;
            case STATE.HIGH:
                return rand.Next(60, 80) / 100f;
            case STATE.MEDIUM:
                return rand.Next(40, 60) / 100f;
            case STATE.LOW:
                return rand.Next(20, 40) / 100f;
            case STATE.VERY_LOW:
                return rand.Next(0, 20) / 100f;
            case STATE.MIN:
            default:
                return 0f;
        }
    }
}
