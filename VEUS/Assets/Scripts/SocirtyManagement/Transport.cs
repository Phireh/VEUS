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
    public enum MAINTENANCE
    {
        NONE = 0,
        PARTIAL = 1,
        COMPLEATe = 2
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    float baseSpeed;
    int baseCapacity;
    Index speedIndex;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public EXPANSION Expansion { get; private set; }
    public MAINTENANCE Maintenance { get; private set; }
    public TYPE TransportType { get; private set; }
    public CityPart.PLACE CityPlace { get; private set; }
    public DependentIndex Wear { get; private set; }
    public DependentIndex Safety { get; private set; }
    public DependentIndex Polluting { get; private set; }
    public int Capacity
    {
        get { return GetCapacity(); }
        private set { if (value > 0) baseCapacity = value; }
    }
    public float Speed
    {
        get { return baseSpeed * speedIndex.Value; }
        private set { if (value > 0) baseSpeed = value; }
    }

    //////////////////
    // Constructors //
    //////////////////

    public Transport(TYPE transportType, float safetyValue, float wearValue, int capacity, float maxSpeed, float speedIndexValue,
        float pollutingValue, CityPart.PLACE cityPlace)
    {
        SetInitialValues(transportType, safetyValue, wearValue, capacity, maxSpeed, speedIndexValue, pollutingValue, cityPlace);
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void SetInitialValues(TYPE transportType, float safetyValue, float wearValue, int capacity, float maxSpeed, float speedIndexValue,
        float pollutingValue, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        TransportType = transportType;
        Safety = new DependentIndex("Seguridad", "Representa como de seguro es desplazarse por " + GlobalNames.transport[(int)transportType]
            + " en el barrio " + GlobalNames.cityPart[(int)cityPlace], safetyValue);
        Polluting = new DependentIndex("Contaminante", "Representa como de contaminante es despalzarse por "
            + GlobalNames.transport[(int)transportType] + " en el barrio " + GlobalNames.cityPart[(int)cityPlace], pollutingValue);
        Wear = new DependentIndex("Desgaste", "Representa como de desgastado está el transporte por "
            + GlobalNames.transport[(int)transportType] + " en el barrio " + GlobalNames.cityPart[(int)cityPlace], wearValue);
        Capacity = capacity;
        Speed = maxSpeed;
        speedIndex = new DependentIndex("Velocidad", "Representa que cantidad de la velocidad máxima es alcanzable viajando por "
            + GlobalNames.transport[(int)transportType] + " en el barrio " + GlobalNames.cityPart[(int)cityPlace], speedIndexValue);
    }

    int GetCapacity()
    {
        switch (Expansion)
        {
            case EXPANSION.NONE:
                Expansion = EXPANSION.SMALL;
                return baseCapacity ;
            case EXPANSION.SMALL:
                return baseCapacity * 2;
            case EXPANSION.LARGE:
            default:
                return baseCapacity * 3;
        }
    }

    ////////////////////
    // Public Methods //
    ////////////////////



}
