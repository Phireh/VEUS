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

    bool isMin;
    bool isMax;
    string name;
    // Name of the index [10 characters or less]
    public string Name
    {
        get { return name; }
        set { if (value.Length < 11) name = value; }
    }
    string description;
    // Description of the index
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    float value;
    // Value of the index [0..1]
    public float Value
    {
        get { return value; }
        set {
            isMin = false; isMax = false;
            if (value <= 0f)
            {
                this.value = 0f;
                isMin = true;
            }
            else if (value >= 1f)
            {
                this.value = 1f;
                isMax = true;
            }
            else this.value = value;
        }
    }

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

    public void DecrementIndexValue(float amount)
    {
        if (amount > 0f)
        {
            isMax = false;
            value -= amount;
            if (value <= 0f)
            {
                value = 0f;
                isMin = true;
            }
            else isMin = false;
        }
    }

    public void IncrementIndexValue(float amount)
    {
        if (amount > 0f)
        {
            isMin = false;
            value += amount;
            if (value >= 1f)
            {
                value = 1f;
                isMax = true;
            }
            else isMax = false;
        }
    }

    /// <summary>
    /// Returns the index state depending on its value
    /// MIN [0%] | VERY_LOW (0% - 20%] | LOW (20% - 40%] | MEDIUM (40% -60%] | 
    /// HIGH (60% - 80%] | VERY_HIGH (80% - 100%) | MAX [100%]
    /// </summary>
    /// <returns></returns>
    public STATE GetIndexState()
    {
        if (isMax) return STATE.MAX;
        else if (value > 0.8f) return STATE.VERY_HIGH;
        else if (value > 0.6f) return STATE.HIGH;
        else if (value > 0.4f) return STATE.MEDIUM;
        else if (value > 0.2f) return STATE.LOW;
        else if (value > 0f) return STATE.MIN;
        else return STATE.MIN; // isMin
    }
}
