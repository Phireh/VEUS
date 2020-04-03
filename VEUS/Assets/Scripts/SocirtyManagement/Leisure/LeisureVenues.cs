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
        Index discoSatisfaction = new Index("Disco Satisfaction", "Represents the satisfaction obtained going to the disco", 0.7f);
        Disco = new Leisure(Leisure.TYPE.PARTY, 23, 6, 25, 4, discoSatisfaction);
        Index parkSatisfaction = new Index("Park Satisfaction", "Represents the satisfaction obtained going to the park", 0.3f);
        Park = new Leisure(Leisure.TYPE.CALM, 0, 23, 0, 1, parkSatisfaction);
        Index gymSatisfaction = new Index("Gym Satisfaction", "Represents the satisfaction obtained going to the gym", 0.55f);
        Gym = new Leisure(Leisure.TYPE.SPORT, 10, 22, 15, 2, gymSatisfaction);
        Index cinemaSatisfaction = new Index("Cinema Satisfaction", "Represents the satisfaction obtained going to the cinema", 0.45f);
        Cinema = new Leisure(Leisure.TYPE.SHOW, 16, 22, 10, 3, cinemaSatisfaction);
    }

    public LeisureVenues(Leisure disco, Leisure park, Leisure gym, Leisure cinema)
    {
        Disco = disco;
        Park = park;
        Gym = gym;
        Cinema = cinema;
    }
}
