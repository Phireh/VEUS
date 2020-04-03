using System.Collections;
using System;
using System.Collections.Generic;

public enum SOCIETY_INDEX
{
    AIR_POLLUTION,
    SOUND_POLLUTION,
    CLEANLINESS,
}

public enum SOCIETY_KEY_INDEX
{
    HAPPINESS,
    PEACE,
    SECURITY
}

public class City
{
    int numParts = Enum.GetNames(typeof(PLACE)).Length;
    CityPart[] cityParts;
    public CityPart[] CityParts
    {
        get { return CityParts; }
        set { CityParts = value; }
    }

    public City()
    {
        CityParts = new CityPart[numParts];
        for (int i = 0; i < cityParts.Length; i++)
        {
            CityParts[i] = new CityPart(250,
                (PLACE) i,
                new WaysOfTransport(),
                new LeisureVenues(),
                new WorkOffers()
                );
        }
    }
}
