using System;
using System.Collections;
using System.Collections.Generic;

public class Dependency
{
    /// <summary>
    /// Types of influence from an index to another.
    /// SUBSTRACTION -> The greater the influencer the lower the influenced |
    /// ADDITION -> The greater the influencer the greater the influenced |
    /// REVERSE_SUBSTRACTION -> The influencer substracts from the influenced, the gretater the influencer, the less it substracts
    /// REVERSE_ADDITION -> The influencer adds to the influenced, the gretater the influencer, the less it adds
    /// </summary>
    public enum TYPE
    {
        SUBSTRACTION = 0,
        ADDITION = 1,
        REVERSE_SUBSTRACTION = 2,
        REVERSE_ADDITION = 3
    }
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    TYPE dependencyType;
    Index influencer;
    int influence;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public Index Influencer
    {
        get { return influencer; }
        private set { influencer = value; }
    }
    public TYPE DependencyType
    {
        get { return dependencyType; }
        private set { dependencyType = value; }
    }
    public int Influence
    {
        get { return influence; }
        set
        {
            if (value < 0) influence = 0;
            else if (value > 100) influence = 100;
            else influence = value;
        }
    }

    //////////////////
    // Constructors //
    //////////////////

    public Dependency(Index influencer, int influence, TYPE dependencyType)
    {
        Influencer = influencer;
        Influence = influence;
        DependencyType = dependencyType;
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////



    ////////////////////
    // Public Methods //
    ////////////////////
}
