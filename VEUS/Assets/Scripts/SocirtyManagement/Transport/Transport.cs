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
        ROAD = 0,
        CYCLE_LANE = 1,
        STREET = 2,
        SUBWAY = 3
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

    CityPart.PLACE cityPlace;
    EXPANSION expansion;
    TYPE transportType;
    Index wear;
    Index safety;
    Index speedIndex;
    int capacity;
    Index polluting;
    float baseCapacity;
    float baseSpeed;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////
   
    public EXPANSION Expansion
    {
        get { return expansion; }
        private set { expansion = value; }
    }
    public Index Wear
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
        get { return baseSpeed * speedIndex.Value; }
        private set { if (value > 0) baseSpeed = value; }
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
    public Index SpeedIndex
    {
        get { return speedIndex; }
        private set { if (value.Value > 0 && value.Value <= 1) speedIndex = value; }
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
    public Transport(TYPE transportType, float safetyValue, int capacity, float maxSpeed, float speedIndexValue,
        float pollutingValue, EXPANSION expansion, WEAR wear, CityPart.PLACE cityPlace)
    {
        SetInitialValues(transportType, safetyValue, capacity, maxSpeed, speedIndexValue, pollutingValue, expansion, wear, cityPlace);
    }

    /// <summary>
    /// [RECOMMENDED CONSTRUCTOR] Creates a Transport in base at the passed values and the prestablished base values
    /// for each type of transport
    /// </summary>
    /// <param name="transportType">Type of the transport</param>
    /// <param name="expansion">Level of expansion of the transport</param>
    /// <param name="wear">Level of wear of the transport</param>
    public Transport(TYPE transportType, EXPANSION expansion, WEAR wear, CityPart.PLACE place)
    {
        float safetyValue;
        int capacity;
        float maxSpeed;
        float pollutingValue;
        float speedIndexValue = 1f;
        switch (transportType)
        {
            case TYPE.STREET:
                capacity = baseStreetCapacity;
                maxSpeed = baseStreetSpeed;
                safetyValue = baseStreetSafety;
                pollutingValue = baseSubwayPollution;
                break;
            case TYPE.CYCLE_LANE:
                maxSpeed = baseCycleLaneSpeed;
                capacity = baseCycleLaneCapacity;
                safetyValue = baseCycleLaneSafety;
                pollutingValue = baseCycleLanePollution;
                break;
            case TYPE.ROAD:
                capacity = baseRoadCapacity;
                safetyValue = baseCycleLaneSafety;
                maxSpeed = baseCycleLaneSpeed;
                pollutingValue = baseCycleLanePollution;
                break;
            case TYPE.SUBWAY:
            default:
                capacity = baseSubwayCapacity;
                safetyValue = baseSubwaySafety;
                maxSpeed = baseSubwaySpeed;
                pollutingValue = baseSubwayPollution;
                break;
        }
        SetInitialValues(transportType, safetyValue, capacity, maxSpeed, speedIndexValue, pollutingValue, expansion, wear, place);
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetInitialValues(TYPE transportType, float safetyValue, int capacity, float maxSpeed, float speedIndexValue,
        float pollutingValue, EXPANSION expansion, WEAR wear, CityPart.PLACE cityPlace)
    {
        this.cityPlace = cityPlace;
        TransportType = transportType;
        Safety = new Index("Seguridad", "Representa como de seguro es desplazarse por " + Names.transport[(int) transportType]
            + " en el barrio " + Names.cityPart[(int)cityPlace], safetyValue);
        Polluting = new Index("Contaminante", "Representa como de contaminante es despalzarse por "
            + Names.transport[(int)transportType] + " en el barrio " + Names.cityPart[(int)cityPlace], pollutingValue);
        Expansion = EXPANSION.NONE;
        int i = 0;
        while (i < (int) expansion)
        {
            Expand();
            i++;
        }
        float wearValue;
        switch (wear)
        {
            case WEAR.NONE:
                wearValue = Index.rand.Next(33) / 100f;
                break;
            case WEAR.PARTIALLY:
                wearValue = Index.rand.Next(34, 66) / 100f;
                break;
            case WEAR.COMPLEATLY:
            default:
                wearValue = Index.rand.Next(67, 100) / 100f;
                break;
        }
        Wear = new Index("Desgaste", "Representa como de desgastado está el transporte por "
            + Names.transport[(int)transportType] + " en el barrio " + Names.cityPart[(int)place], wearValue); 
        Safety.AddDependency(new Dependency(Wear, 35, Dependency.TYPE.SUBSTRACTION));
        this.baseCapacity = Capacity = capacity;
        Speed = maxSpeed;
        speedIndex = new Index("Velocidad", "Representa que cantidad de la velocidad máxima es alcanzable viajando por "
            + Names.transport[(int)transportType] + " en el barrio " + Names.cityPart[(int)place], speedIndexValue);
        speedIndex.AddDependency(new Dependency(Wear, 75, Dependency.TYPE.SUBSTRACTION));
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
}
