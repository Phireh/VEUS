using System;
using System.Collections;
using System.Collections.Generic;

public class WaysOfTransport
{

    ///////////////////////
    // Public Component //
    ///////////////////////

    public CityPart.PLACE CityPlace { get; private set; }
    public Transport Road { get; private set; }
    public Transport CycleLane { get; private set; }
    public Transport Street { get; private set; }
    public Transport Subway { get; private set; }
    public Index Investment { get; private set; }
    public Index Technology { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public WaysOfTransport(float technologyValue, float investmentValue, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        Technology = new IndependentIndex("Tecnología", "Nivel de la tecnología de los transportes en el barrio "
            + GlobalNames.cityPart[(int)cityPlace], technologyValue);
        Investment = new IndependentIndex("Inversión", "Nivel de inversión dirigida a los transportes en el barrio "
            + GlobalNames.cityPart[(int)cityPlace], investmentValue);

        Road = new Transport(Transport.TYPE.ROAD, GlobalValues.transportSafety[(int)Transport.TYPE.ROAD], 0f, GlobalValues.transportCapacity[(int)Transport.TYPE.ROAD],
            GlobalValues.transportMaxSpeed[(int)Transport.TYPE.ROAD], 1f, GlobalValues.transportPollution[(int)Transport.TYPE.ROAD], cityPlace);
        Subway = new Transport(Transport.TYPE.SUBWAY, GlobalValues.transportSafety[(int)Transport.TYPE.SUBWAY], 0f, GlobalValues.transportCapacity[(int)Transport.TYPE.SUBWAY],
            GlobalValues.transportMaxSpeed[(int)Transport.TYPE.SUBWAY], 1f, GlobalValues.transportPollution[(int)Transport.TYPE.SUBWAY], cityPlace);
        CycleLane = new Transport(Transport.TYPE.CYCLE_LANE, GlobalValues.transportSafety[(int)Transport.TYPE.CYCLE_LANE], 0f, GlobalValues.transportCapacity[(int)Transport.TYPE.CYCLE_LANE],
            GlobalValues.transportMaxSpeed[(int)Transport.TYPE.CYCLE_LANE], 1f, GlobalValues.transportPollution[(int)Transport.TYPE.CYCLE_LANE], cityPlace);
        Street = new Transport(Transport.TYPE.STREET, GlobalValues.transportSafety[(int)Transport.TYPE.STREET], 0f, GlobalValues.transportCapacity[(int)Transport.TYPE.STREET],
            GlobalValues.transportMaxSpeed[(int)Transport.TYPE.STREET], 1f, GlobalValues.transportPollution[(int)Transport.TYPE.STREET], cityPlace);
    }

}
