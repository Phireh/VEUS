﻿using System.Collections;
using System.Collections.Generic;

public class Leisure
{
    ////////////////////////
    /// Static Variables ///
    ////////////////////////

    public static int baseOpeningDisco;
    public static int baseOpeningPark;
    public static int baseOpeningGym;
    public static int baseOpeningCinema;
    public static int baseClosingDisco;
    public static int baseClosingPark;
    public static int baseClosingGym;
    public static int baseClosingCinema;
    public static int baseCostDisco;
    public static int baseCostPark;
    public static int baseCostGym;
    public static int baseCostCinema;
    public static float baseSatisfactionDisco;
    public static float baseSatisfactionPark;
    public static float baseSatisfactionGym;
    public static float baseSatisfactionCinema;
    public static int baseTimeDisco;
    public static int baseTimePark;
    public static int baseTimeGym;
    public static int baseTimeCinema;

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
    /// <summary>
    /// Amount of money that the organizers havej
    /// </summary>
    public enum BUDGET
    {
        LOW = 0,
        STANDARD = 1,
        HIGH = 2
    }

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    TYPE leisureType;
    BUDGET budget;
    int opening;
    int closing;
    int cost;
    int time;
    Index satisfaction;
    int baseCost;
    float baseSatisfactionValue;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    // Type of activity
    public TYPE LeisureType
    {
        get { return leisureType; }
        private set { leisureType = value; }
    }
    // Opening hour [0..23]
    public int Opening
    {
        get { return opening; }
        private set { if (value >= 0 && value < 24) opening = value; }
    }
    // Closing hour [0..23]
    public int Closing
    {
        get { return closing; }
        private set { if (value >= 0 && value < 24) closing = value; }
    }
    // Money necesary to do the activity [>=0]
    public int Cost
    {
        get { return cost; }
        private set { if (value >= 0) cost = value; }
    }
    // Time needed to do an activity [>0]
    public int Time
    {
        get { return time; }
        private set { if (value > 0) time = value; }
    }
    public Index Satisfaction
    {
        get { return satisfaction; }
        private set { if (value.Value > 0 && value.Value <= 1) satisfaction = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////
    
    public Leisure(PLACE place, int opening, int closing, int cost, int time, float satisfactionValue)
    {
        SetValues(place, opening, closing, cost, time, satisfactionValue);
    }

    public Leisure(PLACE place)
    {
        int opening;
        int closing;
        int cost;
        int time;
        float satisfactionValue;
        switch (place)
        {
            case PLACE.CINEMA:
                opening = baseOpeningCinema;
                closing = baseClosingCinema;
                cost = baseCostCinema;
                time = baseTimeCinema;
                satisfactionValue = baseSatisfactionCinema;
                break;
            case PLACE.PARK:
                opening = baseOpeningPark;
                closing = baseClosingPark;
                cost = baseCostPark;
                time = baseTimePark;
                satisfactionValue = baseSatisfactionPark;
                break;
            case PLACE.GYM:
                opening = baseOpeningGym;
                closing = baseClosingGym;
                cost = baseCostGym;
                time = baseTimeGym;
                satisfactionValue = baseSatisfactionGym;
                break;
            case PLACE.DISCO:
                opening = baseOpeningDisco;
                closing = baseClosingDisco;
                cost = baseCostDisco;
                time = baseTimeDisco;
                satisfactionValue = baseSatisfactionDisco;
                break;
            default:
                opening = 10;
                closing = 20;
                cost = 100;
                time = 2;
                satisfactionValue = 0.5f;
                break;
        }
        SetValues(place, opening, closing, cost, time, satisfactionValue);
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetValues(PLACE place, int opening, int closing, int cost, int time, float satisfactionValue)
    {
        string n;
        switch (place)
        {
            case PLACE.CINEMA:
                LeisureType = TYPE.SHOW;
                n = "al cine";
                break;
            case PLACE.PARK:
                LeisureType = TYPE.CALM;
                n = "al parque";
                break;
            case PLACE.GYM:
                LeisureType = TYPE.SPORT;
                n = "al gimnasio";
                break;
            case PLACE.DISCO:
                LeisureType = TYPE.PARTY;
                n = "a la discoteca";
                break;
            default:
                LeisureType = TYPE.CALM;
                n = "";
                break;
        }
        Opening = opening;
        Closing = closing;
        Cost = cost;
        Time = time;
        Satisfaction = new Index("Satisfacción", "Satisfacción que produce ir " + n, satisfactionValue);
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////

    public bool ImproveBudget()
    {
        switch (this.budget)
        {
            case BUDGET.LOW:
                Satisfaction.Value = baseSatisfactionValue;
                Cost = baseCost;
                return true;
            case BUDGET.STANDARD:
                Satisfaction.Value = baseSatisfactionValue;
                Satisfaction.ChangeIndexValue(Index.CHANGE.INCREASE);
                Cost = (int)(baseCost * 1.75f);
                return true;
            case BUDGET.HIGH:
            default:
                return false;
        }
    }

    public bool DropBudget()
    {
        switch (this.budget)
        {
            case BUDGET.HIGH:
                Satisfaction.Value = baseSatisfactionValue;
                Cost = baseCost;
                return true;
            case BUDGET.STANDARD:
                Satisfaction.Value = baseSatisfactionValue;
                Satisfaction.ChangeIndexValue(Index.CHANGE.DROP);
                Cost = (int)(baseCost * 0.75f);
                return true;
            case BUDGET.LOW:
            default:
                return false;
        }
    }
}
