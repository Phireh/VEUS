using System;
using System.Collections;
using System.Collections.Generic;

public class WaysOfTransport
{

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    CityPart.PLACE cityPlace;
    Transport road;
    Transport cycleLane;
    Transport street;
    Transport subway;
    Index technology;
    Index investment;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public Transport Road
    {
        get { return road; }
        private set { road = value; }
    }
    public Transport CycleLane
    {
        get { return cycleLane; }
        private set { cycleLane = value; }
    }
    public Transport Street
    {
        get { return street; }
        private set { street = value; }
    }
    public Transport Subway
    {
        get { return subway; }
        private set { subway = value; }
    }
    public Index Investment
    {
        get { return investment; }
        private set { investment = value; }
    }
    public Index Technology
    {
        get { return technology; }
        private set { technology = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////

    public WaysOfTransport(float technologyValue, float investmentValue, CityPart.PLACE cityPlace)
    {
        this.cityPlace = cityPlace;
        Technology = new Index("Tecnología", "Nivel de la tecnología de los transportes en el barrio "
            + Names.cityPart[(int)cityPlace], technologyValue);
        Investment = new Index("Inversión", "Nivel de inversión dirigida a los transportes en el barrio "
            + Names.cityPart[(int)cityPlace], investmentValue);

        Transport.WEAR auxWear;
        if (technology.GetIndexState() > Index.STATE.VERY_HIGH) auxWear = Transport.WEAR.NONE;
        else if (technology.GetIndexState() > Index.STATE.MEDIUM) auxWear = Transport.WEAR.PARTIALLY;
        else  auxWear = Transport.WEAR.PARTIALLY;

        Road = new Transport(Transport.TYPE.ROAD, Transport.EXPANSION.NONE, auxWear, this.cityPlace);
        Subway = new Transport(Transport.TYPE.SUBWAY, Transport.EXPANSION.NONE, auxWear, this.cityPlace);
        CycleLane = new Transport(Transport.TYPE.CYCLE_LANE, Transport.EXPANSION.NONE, auxWear, this.cityPlace);
        Street = new Transport(Transport.TYPE.STREET, Transport.EXPANSION.NONE, auxWear, this.cityPlace);

        if (Investment.GetIndexState() > Index.STATE.LOW)
            RepairOrErode(Transport.TYPE.STREET, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.MEDIUM)
            RepairOrErode(Transport.TYPE.CYCLE_LANE, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.HIGH)
            RepairOrErode(Transport.TYPE.SUBWAY, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.VERY_HIGH)
            RepairOrErode(Transport.TYPE.ROAD, Index.CHANGE.LOW_INCREASE);

        Road.Wear.AddDependency(new Dependency(Investment, 50, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Street.Wear.AddDependency(new Dependency(Investment, 35, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Subway.Wear.AddDependency(new Dependency(Investment, 65, Dependency.TYPE.REVERSE_SUBSTRACTION));
        CycleLane.Wear.AddDependency(new Dependency(Investment, 35, Dependency.TYPE.REVERSE_SUBSTRACTION));

        Road.Wear.AddDependency(new Dependency(Technology, 40, Dependency.TYPE.ADDITION));
        Street.Wear.AddDependency(new Dependency(Technology, 25, Dependency.TYPE.ADDITION));
        Subway.Wear.AddDependency(new Dependency(Technology, 50, Dependency.TYPE.ADDITION));
        CycleLane.Wear.AddDependency(new Dependency(Technology, 25, Dependency.TYPE.ADDITION));

        Road.Safety.AddDependency(new Dependency(Technology, 55, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Street.Safety.AddDependency(new Dependency(Technology, 15, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Subway.Safety.AddDependency(new Dependency(Technology, 55, Dependency.TYPE.REVERSE_SUBSTRACTION));
        CycleLane.Safety.AddDependency(new Dependency(Technology, 25, Dependency.TYPE.REVERSE_SUBSTRACTION));
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////
   
    public Index.STATE RepairOrErode(Transport.TYPE type, Index.CHANGE change)
    {
        Transport t;
        switch (type)
        {
            case Transport.TYPE.STREET:
                t = Street;
                break;
            case Transport.TYPE.ROAD:
                t = Road;
                break;
            case Transport.TYPE.SUBWAY:
                t = Subway;
                break;
            case Transport.TYPE.CYCLE_LANE:
            default:
                t = CycleLane;
                break;
        }
        return t.Wear.ChangeIndexValue(change);
    }
}
