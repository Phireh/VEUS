using System.Collections;
using System.Collections.Generic;

public class Leisure
{
    public enum TYPE
    {
        PARTY = 0,
        CALM = 1,
        SPORT = 2,
        SHOW = 3
    }

    TYPE leisureType;
    // Type of activity
    public TYPE LeisureType
    {
        get { return leisureType; }
        set { leisureType = value; }
    }
    int opening;
    // Opening hour [0..23]
    public int Opening
    {
        get { return opening; }
        set { if (value >= 0 && value < 24) opening = value; }
    }
    int closing;
    // Closing hour [0..23]
    public int Closing
    {
        get { return closing; }
        set { if (value >= 0 && value < 24) closing = value; }
    }
    int cost;
    // Money necesary to do the activity [>=0]
    public int Cost
    {
        get { return cost; }
        set { if (value >= 0) cost = value; }
    }
    int time;
    // Time needed to do an activity [>0]
    public int Time
    {
        get { return time; }
        set { if (value > 0) time = value; }
    }

    public Leisure()
    {
        LeisureType = TYPE.CALM;
        Opening = 8;
        Closing = 20;
        Cost = 100;
        Time = 1;
    }

    public Leisure(TYPE type, int opening, int closing, int cost, int time)
    {
        LeisureType = type;
        Opening = opening;
        Closing = closing;
        Cost = cost;
        Time = time;
    }
}
