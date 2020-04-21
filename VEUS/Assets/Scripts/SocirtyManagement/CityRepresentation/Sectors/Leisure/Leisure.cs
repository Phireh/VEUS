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
    public static Citizen.NATURE[] typeToNatureMatching = new Citizen.NATURE[]
    {
        Citizen.NATURE.ACTIVE,  // PARTY
        Citizen.NATURE.CALM,    // CALM
        Citizen.NATURE.SOCIAL,  // SPORT
        Citizen.NATURE.DREAMER  // SHOW
    };
    /// <summary>
    /// Different types of leisure places, each one has an assocciated activitie (TYPE)
    /// </summary>
    public enum PLACE
    {
        NONE = 0,
        DISCO = 1,
        PARK = 2,
        GYM = 3,
        CINEMA = 4
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
        public int RequieredTime { get; set; }
        // If Closing < Opening
        public bool BetweenDays { get; set; }

        public LeisureSchedule(int opening, int openedTime, int timeRequiered)
        {
            BetweenDays = false;
            if (opening > 23) Opening = 23;
            else if (opening < 0) Opening = 0;
            else Opening = opening;
            if (openedTime > 23) openedTime = 23;
            else if (openedTime < 1) openedTime = 1;
            Closing = Opening + openedTime;
            if (Closing > 23)
            {
                Closing -= 24;
                BetweenDays = true;
            }
            if (timeRequiered > openedTime) timeRequiered = openedTime;
            else if (timeRequiered < 1) timeRequiered = 1;
            RequieredTime = timeRequiered;
        }
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    AVAILABILITY availability;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public int Cost { get; private set; }
    public CityPart.PLACE CityPlace { get; private set; }
    // Type of activity
    public TYPE LeisureType { get; private set; }
    public PLACE LeisurePlace { get; private set; }
    public ConditionableIndex Satisfaction { get; private set; }
    public LeisureSchedule Schedule { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public Leisure(PLACE leisurePlace, AVAILABILITY availability, CityPart.PLACE cityPlace)
    {
        LeisureSchedule newSchedule = new LeisureSchedule(Global.Values.leisureOpening[(int)leisurePlace],
            Global.Values.leisureOpenedTime[(int)availability, (int)leisurePlace],
            Global.Values.leisureTime[(int)leisurePlace]);
        float satisfactionValue = Global.Values.leisureSatisfaction[(int)leisurePlace];
        int cost = Global.Values.leisureCost[(int)leisurePlace];
        SetInitialValues(leisurePlace, newSchedule, satisfactionValue, cost, availability, cityPlace);
    }
        
    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void SetInitialValues(PLACE leisurePlace, LeisureSchedule schedule, float satisfactionValue, int cost,
        AVAILABILITY availability, CityPart.PLACE cityPlace)
    {
        Cost = cost;
        LeisurePlace = leisurePlace;
        Schedule = schedule;
        this.availability = availability;
        LeisurePlace = leisurePlace;
        switch (leisurePlace)
        {
            case PLACE.CINEMA: LeisureType = TYPE.SHOW; break;
            case PLACE.PARK: LeisureType = TYPE.CALM; break;
            case PLACE.GYM: LeisureType = TYPE.SPORT; break;
            case PLACE.DISCO: LeisureType = TYPE.PARTY; break;
            default: LeisureType = TYPE.CALM; break;
        }
        this.availability = availability;
        Satisfaction = new ConditionableIndex("Satisfacción", "Representa como de satisfactorio es ir a " + Global.Names.leisurePlaces[(int)leisurePlace]
            + " en el barrio " + Global.Names.cityPart[(int)cityPlace], satisfactionValue);
        CityPlace = cityPlace;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public void SetAvailability(AVAILABILITY newAvailability)
    {
        this.availability = newAvailability;
        Schedule = new LeisureSchedule(Global.Values.leisureOpening[(int)LeisurePlace],
            Global.Values.leisureOpenedTime[(int)availability, (int)LeisurePlace],
            Global.Values.leisureTime[(int)LeisurePlace]);
    }
    public AVAILABILITY GetAvailability() => availability;

    public override string ToString()
    {
        string res = "Leisure Place: " + LeisurePlace + " | Type: " + LeisureType + " | Cost: " + Cost;
        res += "\nAvailability: " + availability + "\n";
        res += Satisfaction;
        res += "\nOpening: " + Schedule.Opening + " | Closing: " + Schedule.Closing + " | Requiered Time: " + Schedule.RequieredTime;
        return res;
    }
}
