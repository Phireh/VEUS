using System;
using System.Collections;
using System.Collections.Generic;

public class Leisure
{
    //////////////////////
    // Static Component //
    //////////////////////

    /// <summary>
    /// Different types of leisure activities
    /// </summary>
    public enum TYPE
    {
        PARTY = 0,
        CALM = 1,
        SPORT = 2,
        SHOW = 3
    }
    /// <summary>
    /// Different types of leisure places, each one has an assocciated activitie (TYPE)
    /// </summary>
    public enum PLACE
    {
        DISCO = 0,
        PARK = 1,
        GYM = 2,
        CINEMA = 3
    }
    public enum AVAILABILITY
    {
        LIMITED = 0,
        NORMAL = 1,
        EXTENDED = 2
    }

    public struct LeisureSchedule
    {
        // Opening hour [0..23]
        public int Opening{ get; private set; }
        // Closing hour [0..23]
        public int Closing { get; private set; }
        // Time needed to do an activity [>0]
        public int Time { get; set; }
        public bool BetweenDays { get; private set; }

        public void SetTimeSchedule(int opening, int timeOpened, int timeRequiered)
        {
            if (timeOpened > 23) timeOpened = 23;
            else if (timeOpened < 1) timeOpened = 1;
            if (opening > 23) Opening = 23;
            else if (opening < 1) Opening = 1;
            else Opening = opening;
            if (timeRequiered > timeOpened) timeRequiered = timeOpened;
            else if (timeRequiered < 1) timeRequiered = 1;
            if (Opening + timeOpened > 23) BetweenDays = true;
            if (BetweenDays) Closing = 23 - Opening;
            else Closing = Opening + timeOpened;
            Time = timeRequiered;
        }
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    int baseCost;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public LeisureSchedule Schedule { get; private set; }
    public CityPart.PLACE CityPlace { get; private set; }
    // Type of activity
    public TYPE LeisureType { get; private set; }
    public PLACE LeisurePlace { get; private set; }
    public AVAILABILITY Availability { get; private set; }
    // Money necesary to do the activity [>=0]
    public int Cost
    {
        get { return GetCost(); }
        private set { if (value >= 0) baseCost = value; }
    }
    public Index Satisfaction { get; private set; }

    //////////////////
    // Constructors //
    //////////////////


        
    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void SetSchedule(int opening, int timeOpened, int timeRequiered) { Schedule.SetTimeSchedule(opening, timeOpened, timeRequiered); }

    int GetCost() 
    {
        return baseCost;
    }

    ////////////////////
    // Public Methods //
    ////////////////////



}
