using System.Collections;
using System;
using System.Collections.Generic;

public enum SOCIETY_INDEX
{
    AIR_POLLUTION = 0,
    SOUND_POLLUTION = 1,
    CLEANLINESS = 2,
}

public enum SOCIETY_KEY_INDEX
{
    HAPPINESS = 0,
    PEACE = 1,
    SECURITY = 2
}

public class City
{
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    int numParts = Enum.GetNames(typeof(PLACE)).Length;
    CityPart[] cityParts;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public CityPart[] CityParts
    {
        get { return CityParts; }
        private set { CityParts = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////
    
    public City()
    {
        CityParts = new CityPart[numParts];
        for (int i = 0; i < cityParts.Length; i++)
        {
            CityParts[i] = new CityPart();
        }
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////

}
