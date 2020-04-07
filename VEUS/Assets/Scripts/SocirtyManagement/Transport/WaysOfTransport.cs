using System;
using System.Collections;
using System.Collections.Generic;

public class WaysOfTransport
{
    public enum TRANSPORT_ACCESS
    {
        PRIVATE = 0,
        SEMI_PRIVATE = 1,
        PUBLIC = 2
    }
    public enum TECHNOLOGY
    {
        OLD_FASHINED = 0,
        UP_TO_DATE = 1,
        CUTTING_EDGE = 2
    }
    public enum INVESTMENT
    {
        VERY_LOW = 0,
        LOW = 1,
        MEDIUM = 2,
        HIGH = 3,
        VERY_HIGH
    }
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    Transport road;
    Transport cycleLane;
    Transport street;
    Transport subway;

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

    /////////////////////
    /// Constructors ///
    ////////////////////

    public WaysOfTransport(Transport road, Transport cycleLane, Transport street, Transport subway)
    {
        SetInitialValues(road, cycleLane, street, subway);
    }

    public WaysOfTransport(TRANSPORT_ACCESS accesiblity, TECHNOLOGY texhnology,
        INVESTMENT investment)
    {

    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetInitialValues(Transport road, Transport cycleLane, Transport street, Transport subway)
    {
        Road = road;
        CycleLane = cycleLane;
        Street = street;
        Subway = subway;
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////
}
