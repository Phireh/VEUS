using System;
using System.Collections;
using System.Collections.Generic;
public class LeisureVenues
{
    Leisure disco;
    public Leisure Disco
    {
        get { return disco; }
        set { disco = value; }
    }
    Leisure park;
    public Leisure Park
    {
        get { return park; }
        set { park = value; }
    }
    Leisure gym;
    public Leisure Gym
    {
        get { return gym; }
        set { gym = value; }
    }
    Leisure cinema;
    public Leisure Cinema
    {
        get { return cinema; }
        set { cinema = value; }
    }

    public LeisureVenues()
    {
        Disco = new Leisure(Leisure.TYPE.PARTY, 23, 6, 25, 4);
        Park = new Leisure(Leisure.TYPE.CALM, 0, 23, 0, 1);
        Gym = new Leisure(Leisure.TYPE.SPORT, 10, 22, 15, 2);
        Cinema = new Leisure(Leisure.TYPE.SHOW, 16, 22, 10, 3);
    }

    public LeisureVenues(Leisure disco, Leisure park, Leisure gym, Leisure cinema)
    {
        Disco = disco;
        Park = park;
        Gym = gym;
        Cinema = cinema;
    }
}
