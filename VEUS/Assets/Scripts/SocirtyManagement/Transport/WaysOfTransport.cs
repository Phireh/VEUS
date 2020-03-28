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
        road = new Transport(Transport.TYPE.CAR, 0.99f, 250, 20f, 0.75f);
        cycleLane = new Transport(Transport.TYPE.BIKE, 0.97f, 100, 3f, 0.05f);
        street = new Transport(Transport.TYPE.FEET, 0.999f, 1000, 1f, 0.025f);
        subway = new Transport(Transport.TYPE.TRAIN, 0.995f, 175, 10f, 0.3f);
    }

    public WaysOfTransport(Transport road, Transport cycleLane, Transport street, Transport subway)
    {
        Road = road;
        CycleLane = cycleLane;
        Street = street;
        Subway = subway;
    }
}
