using System;
using System.Collections;
using System.Collections.Generic;

public class Transport
{
    //////////////////////
    // Static Component //
    //////////////////////

    /// <summary>
    /// Different ways of transport
    /// </summary>
    public enum TYPE
    {
        NONE = 0,
        ROAD = 1,
        CYCLE_LANE = 2,
        STREET = 3,
        SUBWAY = 4
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
    public enum ENHANCEMENTS
    {
        NONE = 0,
        FEW = 1,
        MANY = 2
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    float baseSpeed;
    EXPANSION expansion;
    ENHANCEMENTS enhancements;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public int Capacity { get; private set; }
    public TYPE TransportType { get; private set; }
    public CityPart.PLACE CityPlace { get; private set; }
    public DependentIndex SpeedIndex { get; private set; }
    public DependentIndex Wear { get; private set; }
    public DependentIndex Safety { get; private set; }
    public DependentIndex Polluting { get; private set; }
    public float Speed
    {
        get { return baseSpeed * SpeedIndex.Value; }
        private set { if (value > 0) baseSpeed = value; }
    }

    //////////////////
    // Constructors //
    //////////////////

    public Transport(TYPE transportType, EXPANSION expansion, ENHANCEMENTS enhancements, CityPart.PLACE cityPlace)
    {
        float safetyValue = Global.Values.transportSafety[(int)transportType];
        float wearValue = 0f;
        int capacity = Global.Values.transportCapacity[(int)expansion, (int)transportType];
        float maxSpeed = Global.Values.transportMaxSpeed[(int)enhancements, (int)transportType];
        float speedIndexValue = 1f;
        float pollutingValue = Global.Values.transportPollution[(int) transportType];
        SetInitialValues(transportType, safetyValue, wearValue, capacity, maxSpeed, speedIndexValue,
            pollutingValue, expansion, enhancements, cityPlace);
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void SetInitialValues(TYPE transportType, float safetyValue, float wearValue, int capacity, float maxSpeed, float speedIndexValue,
        float pollutingValue, EXPANSION expansion, ENHANCEMENTS enhancements, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        this.expansion = expansion;
        this.enhancements = enhancements;
        TransportType = transportType;
        Safety = new DependentIndex("Seguridad", "Representa como de seguro es desplazarse por " + Global.Names.transport[(int)transportType]
            + " en el barrio " + Global.Names.cityPart[(int)cityPlace], safetyValue);
        Polluting = new DependentIndex("Contaminante", "Representa como de contaminante es despalzarse por "
            + Global.Names.transport[(int)transportType] + " en el barrio " + Global.Names.cityPart[(int)cityPlace], pollutingValue);
        Wear = new DependentIndex("Desgaste", "Representa como de desgastado está el transporte por "
            + Global.Names.transport[(int)transportType] + " en el barrio " + Global.Names.cityPart[(int)cityPlace], wearValue);
        Capacity = capacity;
        Speed = maxSpeed;
        SpeedIndex = new DependentIndex("Velocidad", "Representa que cantidad de la velocidad máxima es alcanzable viajando por "
            + Global.Names.transport[(int)transportType] + " en el barrio " + Global.Names.cityPart[(int)cityPlace], speedIndexValue);
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public EXPANSION GetExpansionState() => this.expansion;
    public ENHANCEMENTS GetEnhancements() => this.enhancements;
    public void SetExpansionState(EXPANSION newExpansionState)
    {
        this.expansion = newExpansionState;
        Capacity = Global.Values.transportCapacity[(int)expansion, (int)TransportType];
    }
    public void SetEnhancements(ENHANCEMENTS newMaintenanceState)
    {
        this.enhancements = newMaintenanceState;
        Speed = Global.Values.transportMaxSpeed[(int)enhancements, (int)TransportType];
    }
    public float GetBaseSpeed() => baseSpeed;
    public override string ToString()
    {
        string res = "Trasport Type: " + TransportType + " | Capacity: " + Capacity + " | Speed: " + Speed + "(" + baseSpeed + ")\n";
        res += SpeedIndex + "\n";
        res += Wear + "\n";
        res += Safety + "\n";
        res += Polluting + "\n";
        res += "Expansions: " + expansion + " | Enhancements: " + enhancements;
        return res;
    }
}
