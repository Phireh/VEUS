using System.Collections;
using System.Collections.Generic;

public enum PLACE
{
    NORTH = 0,
    WEST = 1,
    SOUTH = 2,
    EAST = 3,
    CENTER = 4
}

public class CityPart
{

    PLACE location;
    public PLACE Location
    {
        get { return location; }
        set { location = value; }
    }
    WaysOfTransport transport;
    public WaysOfTransport Transport
    {
        get { return transport; }
        set { transport = value; }
    }
    LeisureVenues leisure;
    public LeisureVenues Leisure
    {
        get { return leisure; }
        set { leisure = value; }
    }
    WorkOffers jobs;
    public WorkOffers Jobs
    {
        get { return jobs; }
        set { jobs = value; }
    }

    public CityPart()
    {
        Location = PLACE.CENTER;
        Transport = new WaysOfTransport();
        Leisure = new LeisureVenues();
        Jobs = new WorkOffers();
    }

    public CityPart(PLACE location, WaysOfTransport transport, LeisureVenues leisure, WorkOffers jobs)
    {
        Location = location;
        Transport = transport;
        Leisure = leisure;
        Jobs = jobs;
    }
}
