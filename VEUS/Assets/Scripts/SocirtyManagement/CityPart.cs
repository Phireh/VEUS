using System;
using System.Collections;
using System.Collections.Generic;

public class CityPart
{
    public enum PLACE
    {
        NORTH = 0,
        WEST = 1,
        SOUTH = 2,
        EAST = 3,
        CENTER = 4
    }
    public enum POPULATION
    {
        UNDER_POPULATED = 0,
        SMALL = 1,
        MEDIA = 2,
        LARGE = 3,
        OVER_POPULATED = 4
    }
    public enum INDUSTRY
    {
        UNDER_DEVELOPED = 0,
        DEVELOPING = 1,
        DEVELOPED = 2
    }
    public enum FUN
    {
        BORING = 0,
        ENJOYABLE = 1,
        ENTERTAINING = 2
    }
    public enum INFRASTRUCTURE
    {
        OLD_FASHINED = 0,
        UP_TO_DATE = 1,
        CUTTING_EDGE = 2
    }

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    Citizen[] residents;
    PLACE location;
    WaysOfTransport transport;
    WorkOffers jobs;
    LeisureVenues leisure;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////
    
    public WaysOfTransport Transport
    {
        get { return transport; }
        private set { transport = value; }
    }
    public LeisureVenues Leisure
    {
        get { return leisure; }
        private set { leisure = value; }
    }
    public WorkOffers Jobs
    {
        get { return jobs; }
        private set { jobs = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////

    public CityPart(PLACE location, WaysOfTransport transport,
        LeisureVenues leisure, WorkOffers jobs, Citizen[] residents)
    {
        SetInitialValues(location, transport, leisure, jobs, residents);
    }

    public CityPart(PLACE location, POPULATION population, INDUSTRY industry,
        FUN fun, INFRASTRUCTURE infrastrucure)
    {

    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetInitialValues(PLACE location, WaysOfTransport transport,
        LeisureVenues leisure, WorkOffers jobs, Citizen[] residents)
    {
        this.residents = residents;
        this.location = location;
        Transport = transport;
        Leisure = leisure;
        Jobs = jobs;
    }

    void GenerateRandomResidents()
    {
        int residentsNum = new Random().Next(150, 350);
        for (int i = 0; i < residentsNum; i++)
            residents[i] = Citizen.RandomCitizen();
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////

}
