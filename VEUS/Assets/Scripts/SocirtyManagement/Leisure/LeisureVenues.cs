using System;
using System.Collections;
using System.Collections.Generic;
public class LeisureVenues
{
    /////////////////////////
    /// Private Variables ///
    /////////////////////////
    
    Leisure disco;
    Leisure park;
    Leisure gym;
    Leisure cinema;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public Leisure Disco
    {
        get { return disco; }
        private set { disco = value; }
    }
    public Leisure Park
    {
        get { return park; }
        private set { park = value; }
    }
    public Leisure Gym
    {
        get { return gym; }
        private set { gym = value; }
    }
    public Leisure Cinema
    {
        get { return cinema; }
        private set { cinema = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////

    public LeisureVenues(Leisure disco, Leisure park, Leisure gym, Leisure cinema)
    {
        Disco = disco;
        Park = park;
        Gym = gym;
        Cinema = cinema;
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////
    


    //////////////////////
    /// Public Methods ///
    //////////////////////
}
