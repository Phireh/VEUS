using System.Collections;
using System;
using System.Collections.Generic;

public class City
{
    CityPart south;
    public CityPart South
    {
        get { return south; }
        set { south = value; }
    }
    CityPart east;
    public CityPart East
    {
        get { return east; }
        set { east = value; }
    }
    CityPart north;
    public CityPart North
    {
        get { return north; }
        set { north = value; }
    }
    CityPart west;
    public CityPart West
    {
        get { return west; }
        set { west = value; }
    }
    CityPart center;
    public CityPart Center
    {
        get { return center; }
        set { center = value; }
    }

    public City()
    {
        South = new CityPart();
        East = new CityPart();
        North = new CityPart();
        West = new CityPart();
        Center = new CityPart();
    }

    public City(CityPart south, CityPart east, CityPart north, CityPart west, CityPart center)
    {
        South = south;
        East = east;
        North = north;
        West = west;
        Center = center;
    }
}
