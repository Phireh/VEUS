using System;
using System.Collections;
using System.Collections.Generic;
public class LeisureVenues
{
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    CityPart.PLACE cityPlace;
    Leisure disco;
    Leisure park;
    Leisure gym;
    Leisure cinema;
    Index investment;
    Index fun;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public Leisure Disco
    {
        get { return disco; }
        private set { disco = value; }
    }
    public Leisure Park
    {
        get { return park; }
        private set { park = value; }
    }
    public Leisure Gym
    {
        get { return gym; }
        private set { gym = value; }
    }
    public Leisure Cinema
    {
        get { return cinema; }
        private set { cinema = value; }
    }
    public Index Investment
    {
        get { return investment; }
        private set { investment = value; }
    }
    public Index Fun
    {
        get { return fun; }
        private set { fun = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////

    public LeisureVenues(float investmentValue, float funValue, CityPart.PLACE cityPlace)
    {
        this.cityPlace = cityPlace;
        Investment = new Index("Inversión", "Nivel de inversión dirigida al ocio y entretenimiento en el barrio "
            + Names.cityPart[(int)cityPlace], investmentValue);
        Fun = new Index("Inversión", "Nivel de ambiente y buen rollo en el barrio "
            + Names.cityPart[(int)cityPlace], funValue);

        Disco = new Leisure(Leisure.PLACE.DISCO, this.cityPlace);
        Park = new Leisure(Leisure.PLACE.PARK, this.cityPlace);
        Gym = new Leisure(Leisure.PLACE.GYM, this.cityPlace);
        Cinema = new Leisure(Leisure.PLACE.CINEMA, this.cityPlace);

        if (Investment.GetIndexState() > Index.STATE.LOW)
            IcreaseOrDropSatisfaction(Leisure.PLACE.PARK, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.MEDIUM)
            IcreaseOrDropSatisfaction(Leisure.PLACE.GYM, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.HIGH)
            IcreaseOrDropSatisfaction(Leisure.PLACE.DISCO, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.VERY_HIGH)
            IcreaseOrDropSatisfaction(Leisure.PLACE.CINEMA, Index.CHANGE.LOW_INCREASE);

        Disco.Satisfaction.AddDependency(new Dependency(Fun, 35, Dependency.TYPE.SAME_TENDENCY));
        Park.Satisfaction.AddDependency(new Dependency(Fun, 15, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Gym.Satisfaction.AddDependency(new Dependency(Fun, 25, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Cinema.Satisfaction.AddDependency(new Dependency(Fun, 10, Dependency.TYPE.REVERSE_SUBSTRACTION));

        Disco.Satisfaction.AddDependency(new Dependency(Investment, 25, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Park.Satisfaction.AddDependency(new Dependency(Investment, 15, Dependency.TYPE.REVERSE_SUBSTRACTION));
        Gym.Satisfaction.AddDependency(new Dependency(Investment, 30, Dependency.TYPE.ADDITION));
        Cinema.Satisfaction.AddDependency(new Dependency(Investment, 20, Dependency.TYPE.SAME_TENDENCY));
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////

    public Index.STATE IcreaseOrDropSatisfaction(Leisure.PLACE place, Index.CHANGE change)
    {
        Leisure l;
        switch (place)
        {
            case Leisure.PLACE.DISCO:
                l = Disco;
                break;
            case Leisure.PLACE.PARK:
                l = Park;
                break;
            case Leisure.PLACE.GYM:
                l = Gym;
                break;
            case Leisure.PLACE.CINEMA:
            default:
                l = Cinema;
                break;
        }
        return l.Satisfaction.ChangeIndexValue(change);
    }

}
