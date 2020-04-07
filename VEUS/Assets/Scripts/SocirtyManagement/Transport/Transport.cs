using System.Collections;
using System.Collections.Generic;

public class Transport 
{
    ////////////////////////
    /// Static Variables ///
    ////////////////////////

    public static int baseRoadCapacity = 250;
    public static int baseCycleLaneCapacity = 100;
    public static int baseStreetCapacity = 1000;
    public static int baseSubwayCapacity = 75;
    public static float baseRoadSafety = 0.6f;
    public static float baseCycleLaneSafety = 0.75f;
    public static float baseStreetSafety = 1f;
    public static float baseSubwaySafety = 0.9f;
    public static float baseRoadPollution = 0.9f;
    public static float baseCycleLanePollution = 0.2f;
    public static float baseStreetPollution = 0.1f;
    public static float baseSubwayPollution = 0.35f;
    public static float baseRoadSpeed = 20f;
    public static float baseCycleLaneSpeed = 3f;
    public static float baseStreetSpeed = 1f;
    public static float baseSubwaySpeed = 10f;

    /// <summary>
    /// Different ways of transport
    /// </summary>
    public enum TYPE
    {
        CAR = 0,
        BIKE = 1,
        FEET = 2,
        TRAIN = 3
    }
    /// <summary>
    /// Amplified capacity in comparison with the original
    /// </summary>
    public enum EXPANSION
    {
        NONE = 0,
        SMALL = 1,
        LARGE = 2
    }
    /// <summary>
    /// State of the way of transport. A bad state implies less security and speed
    /// </summary>
    public enum WEAR
    {
        NONE = 0,
        PARTIALLY = 1,
        COMPLEATLY = 2
    }

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    EXPANSION expansion;
    WEAR wear;
    TYPE transportType;
    Index safety;
    float speed;
    int capacity;
    Index polluting;
    float baseCapacity;
    float baseSpeed;
    float baseSafety;
    float basePolluting;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////
   
    public EXPANSION Expansion
    {
        get { return expansion; }
        private set { expansion = value; }
    }
    public WEAR Wear
    {
        get { return wear; }
        private set { wear = value; }
    }
    // Type of the transport
    public TYPE TransportType
    {
        get { return transportType; }
        private set { transportType = value; }
    }
    // Is it safe to use? [Index]
    public Index Safety
    {
        get { return safety; }
        private set { if (value.Value > 0 && value.Value <= 1) safety = value; }
    }
    // Does it take too long? [> 0 (Divides the default travel time by walk)]
    public float Speed
    {
        get { return speed; }
        private set { if (value > 0) speed = value; }
    }
    // How many people can use it at the same time
    public int Capacity
    {
        get { return capacity; }
        private set { if (value > 0) capacity = value; }
    }
    
    // How much does the transport pollute the air and noise [Index]
    public Index Polluting
    {
        get { return polluting; }
        private set { if (value.Value > 0 && value.Value <= 1) polluting = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////
    
    /// <summary>
    /// [NOT RECOMMENDED CONSTRUCTOR] Creates a Transport with the passed values
    /// </summary>
    /// <param name="transportType">Type of transport</param>
    /// <param name="safetyValue">Initial safety value</param>
    /// <param name="capacity">Initial amount of people that can use it</param>
    /// <param name="speed">Initial traavelling speed</param>
    /// <param name="pollutingValue">Initial polluting level</param>
    /// <param name="expansion">Level of expansion of the transport (if it is not max it's possible to increment the capacity)</param>
    /// <param name="wear">Level of wear of the transport (if bad, it can improve | if good, it can get worse)</param>
    public Transport(TYPE transportType, float safetyValue, int capacity, float speed, float pollutingValue, EXPANSION expansion, WEAR wear)
    {
        SetInitialValues(transportType, safetyValue, capacity, speed, pollutingValue, expansion, wear);
    }

    /// <summary>
    /// [RECOMMENDED CONSTRUCTOR] Creates a Transport in base at the passed values and the prestablished base values
    /// for each type of transport
    /// </summary>
    /// <param name="transportType">Type of the transport</param>
    /// <param name="expansion">Level of expansion of the transport</param>
    /// <param name="wear">Level of wear of the transport</param>
    public Transport(TYPE transportType, EXPANSION expansion, WEAR wear)
    {
        float safetyValue;
        int capacity;
        float speed;
        float pollutingValue;
        switch (transportType)
        {
            case TYPE.FEET:
                capacity = baseStreetCapacity;
                speed = baseStreetSpeed;
                safetyValue = baseStreetSafety;
                pollutingValue = baseSubwayPollution;
                break;
            case TYPE.BIKE:
                speed = baseCycleLaneSpeed;
                capacity = baseCycleLaneCapacity;
                safetyValue = baseCycleLaneSafety;
                pollutingValue = baseCycleLanePollution;
                break;
            case TYPE.CAR:
                capacity = baseRoadCapacity;
                safetyValue = baseCycleLaneSafety;
                speed = baseCycleLaneSpeed;
                pollutingValue = baseCycleLanePollution;
                break;
            case TYPE.TRAIN:
            default:
                capacity = baseSubwayCapacity;
                safetyValue = baseSubwaySafety;
                speed = baseSubwaySpeed;
                pollutingValue = baseSubwayPollution;
                break;
        }
        SetInitialValues(transportType, safetyValue, capacity, speed, pollutingValue, expansion, wear);
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetInitialValues(TYPE transportType, float safetyValue, int capacity, float speed, float pollutingValue, EXPANSION expansion, WEAR wear)
    {
        string n;
        switch (transportType)
        {
            case TYPE.FEET:
                n = "caminando";
                break;
            case TYPE.BIKE:
                n = "en bici";
                break;
            case TYPE.CAR:
                n = "en coche";
                break;
            case TYPE.TRAIN:
            default:
                n = "en tren";
                break;
        }
        TransportType = transportType;
        Safety = new Index("Seguridad", "Representa como de seguro es desplazarse " + n, safetyValue);
        Polluting = new Index("Contaminante", "Representa como de contaminante es despalzarse " + n, pollutingValue);
        Expansion = EXPANSION.NONE;
        Wear = WEAR.NONE;
        int i = 0;
        while (i < (int) wear)
        {
            Erode();
            i++;
        }
        i = 0;
        while (i < (int) expansion)
        {
            Expand();
            i++;
        }

        this.baseSafety = safetyValue;
        this.baseCapacity = Capacity = capacity;
        this.baseSpeed = Speed = speed;
        this.basePolluting = pollutingValue;
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////

    /// <summary>
    /// Increments the capacity of the transport if possible
    /// </summary>
    /// <returns>True if the expansion is effective (not already large excaled)</returns>
    public bool Expand()
    {
        switch (Expansion)
        {
            case EXPANSION.NONE:
                Capacity = (int) (baseCapacity * 2);
                Expansion = EXPANSION.SMALL;
                return true;
            case EXPANSION.SMALL:
                Capacity += (int) (baseCapacity * 3);
                Expansion = EXPANSION.LARGE;
                return true;
            case EXPANSION.LARGE:
            default:
                return false;
        }
    }

    /// <summary>
    /// Increments the quality of the transport. This makes it safer and faster
    /// </summary>
    /// <returns>If the repairation is effective (not already repaired)</returns>
    public bool Repair()
    {
        switch (Wear)
        {
            case WEAR.COMPLEATLY:
                speed = baseSpeed * 0.75f;
                Safety.Value = baseSafety;
                Safety.ChangeIndexValue(Index.CHANGE.DROP);
                Wear = WEAR.PARTIALLY;
                return true;
            case WEAR.PARTIALLY:
                speed = baseSpeed;
                Safety.Value = baseSafety;
                Wear = WEAR.NONE;
                return true;
            case WEAR.NONE:
            default:
                return false;
        }
    }

    /// <summary>
    /// Decrements the quality of the transport. This makes it slower and unsafe
    /// </summary>
    /// <returns>If the erosion is effective (not already compleatly eroded)</returns>
    public bool Erode()
    {
        switch (Wear)
        {
            case WEAR.NONE:
                speed = baseSpeed * 0.75f;
                Safety.Value = baseSafety;
                Safety.ChangeIndexValue(Index.CHANGE.DROP);
                Wear = WEAR.PARTIALLY;
                return true;
            case WEAR.PARTIALLY:
                speed = baseSpeed * 0.5f;
                Safety.Value = baseSafety;
                Safety.ChangeIndexValue(Index.CHANGE.GREAT_DROP);
                Wear = WEAR.COMPLEATLY;
                return true;
            case WEAR.COMPLEATLY:
            default:
                return false;
        }
    }
}
