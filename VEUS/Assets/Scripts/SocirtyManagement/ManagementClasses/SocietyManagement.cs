using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SocietyManagement
{
    public static List<City> dayByDayCity;
    public static City CityOfToday { get; private set; }

    // Start is called before the first frame update
    public static void Init()
    {
        Global.InitiallizeAll();
        dayByDayCity = new List<City>();
        dayByDayCity.Add(new City());
        CityOfToday = dayByDayCity[0];
    }

    public static void ProcessDay()
    {
        int sum = CityOfToday.Changes.ApplyAllChanges();
        Debug.Log(sum + " changes applied");
    }
}
