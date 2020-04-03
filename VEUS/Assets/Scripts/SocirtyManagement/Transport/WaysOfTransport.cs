using System;
using System.Collections;
using System.Collections.Generic;

public class WaysOfTransport
{
    Transport road;         // Fastest way to go. Also the most polluting.
    public Transport Road
    {
        get { return road; }
        set { road = value; }
    }
    Transport cycleLane;    // It's the less polluting
    public Transport CycleLane
    {
        get { return cycleLane; }
        set { cycleLane = value; }
    }
    Transport street;       // Slowest way to go
    public Transport Street
    {
        get { return street; }
        set { street = value; }
    }
    Transport subway;       // Faster than cycling, slower than the car
    public Transport Subway
    {
        get { return subway; }
        set { subway = value; }
    }

    public WaysOfTransport()
    {
        Index roadSafety = new Index("Road Safety", "Indicates how safe is to move using a car", 0.99f);
        Index roadPolution = new Index("Road Pollution", "Indicates how much pollutes to move using a car", 0.75f);
        road = new Transport(Transport.TYPE.CAR, roadSafety, 250, 20f, roadPolution);
        Index cycleLanSafety = new Index("Cycle Lane Safety", "Indicates how safe is to move using the byke", 0.97f);
        Index cycleLanePolution = new Index("Cycle Lane Pollution", "Indicates how much pollutes to move using the byke", 0.05f);
        cycleLane = new Transport(Transport.TYPE.BIKE, cycleLanSafety, 100, 3f, cycleLanePolution);
        Index streetSafety = new Index("Street Safety", "Indicates how safe is to move by feet", 0.999f);
        Index streetPolution = new Index("Street Pollution", "Indicates how much pollutes to move by feet", 0.025f);
        street = new Transport(Transport.TYPE.FEET, streetSafety, 1000, 1f, streetPolution);
        Index subwaySafety = new Index("Subway Safety", "Indicates how safe is to move using the subway", 0.995f);
        Index subwayPolution = new Index("Subway Pollution", "Indicates how much pollutes to move using the subway", 0.3f);
        subway = new Transport(Transport.TYPE.TRAIN, subwaySafety, 175, 10f, subwayPolution);
    }

    public WaysOfTransport(Transport road, Transport cycleLane, Transport street, Transport subway)
    {
        Road = road;
        CycleLane = cycleLane;
        Street = street;
        Subway = subway;
    }
}
