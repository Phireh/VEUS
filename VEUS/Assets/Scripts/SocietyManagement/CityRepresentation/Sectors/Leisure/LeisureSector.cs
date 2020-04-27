using System;
using System.Collections;
using System.Collections.Generic;

public class LeisureSector
{
    //////////////////////
    // Static Component //
    //////////////////////

    public struct LeisurePlan
    {
        public int Cost { get; set; }
        public int Enter { get; set; }
        public int TimeExpended { get; set; }
        public float Satisfaction { get; set; }
        public Leisure.PLACE Place { get; set; }
        public LeisurePlan(Leisure.PLACE place, int enter, int timeExpended, float satisfaction, int cost)
        {
            Place = place; Enter = enter; TimeExpended = timeExpended; Satisfaction = satisfaction; Cost = cost;
        }
    }

    public static LeisurePlan GetNullPlan() => new LeisurePlan(Leisure.PLACE.NONE, -1, -1, -0f, 999);

    //////////////////////
    // Public Component //
    //////////////////////

    int placesCoount;

    //////////////////////
    // Public Component //
    //////////////////////

    public CityPart.PLACE CityPlace { get; private set; }
    public Leisure[] LeisureVenues { get; private set; }
    public ConditionableIndex Investment { get; private set; }
    public ConditionableIndex Fun { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public LeisureSector(float investmentValue, float funValue, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        Fun = new ConditionableIndex("Diversión", "Nivel de diversión de los lugares de ocio en el barrio "
            + Global.Names.cityPart[(int)cityPlace], funValue);
        Investment = new ConditionableIndex("Inversión", "Nivel de inversión dirigida a los lugares de ocio en el barrio "
            + Global.Names.cityPart[(int)cityPlace], investmentValue);

        placesCoount = Enum.GetNames(typeof(Leisure.PLACE)).Length;
        LeisureVenues = new Leisure[placesCoount];

        LeisureVenues[(int)Leisure.PLACE.DISCO] = new Leisure(Leisure.PLACE.DISCO, Leisure.AVAILABILITY.NORMAL, cityPlace);
        LeisureVenues[(int)Leisure.PLACE.CINEMA] = new Leisure(Leisure.PLACE.CINEMA, Leisure.AVAILABILITY.NORMAL, cityPlace);
        LeisureVenues[(int)Leisure.PLACE.PARK] = new Leisure(Leisure.PLACE.PARK, Leisure.AVAILABILITY.NORMAL, cityPlace);
        LeisureVenues[(int)Leisure.PLACE.GYM] = new Leisure(Leisure.PLACE.GYM, Leisure.AVAILABILITY.NORMAL, cityPlace);
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////


    //////////////////////
    /// Public Methods ///
    //////////////////////

    public LeisurePlan GetMostSatisfyingPlan(Citizen.NATURE nature, int currentHour, int limitHour)
    {
        LeisurePlan mostSatisfying = GetNullPlan();
        int iteration = 0;
        foreach (Leisure l in LeisureVenues)
        {
            if (iteration++ < 1) continue;
            if (limitHour < currentHour) limitHour += 24;
            int closing = l.Schedule.Closing, openinng = l.Schedule.Opening;
            if (closing < openinng) closing += 24;
            int entering;
            if (currentHour > openinng)
            {
                if (currentHour < closing) entering = currentHour;
                else entering = openinng;
            }
            else entering = openinng;
            float satisfactionValue = l.Satisfaction.Value;
            if (nature == Leisure.typeToNatureMatching[(int)l.LeisureType]) satisfactionValue += Global.Values.matchingNatureBonues;
            if (satisfactionValue > mostSatisfying.Satisfaction             // If... it's more satisfying than the current option
                && entering + l.Schedule.RequieredTime <= closing           // ... it's possible to do the activity before the closing
                && entering + l.Schedule.RequieredTime <= limitHour)        // ... it's possible to do the activity before it's too late
            {
                mostSatisfying.Enter = entering;
                mostSatisfying.Place = l.LeisurePlace;
                mostSatisfying.Satisfaction = satisfactionValue;
                mostSatisfying.TimeExpended = l.Schedule.RequieredTime;
                mostSatisfying.Cost = l.Cost;
            }
        }
        return mostSatisfying;
    }

    public LeisurePlan GetCheapestPlan(Citizen.NATURE nature, int currentHour, int limitHour)
    {
        LeisurePlan cheapest = GetNullPlan();
        int iteration = 0;
        foreach (Leisure l in LeisureVenues)
        {
            if (iteration++ < 1) continue;
            if (limitHour < currentHour) limitHour += 24;
            int closing = l.Schedule.Closing, openinng = l.Schedule.Opening;
            if (closing < openinng) closing += 24;
            int entering;
            if (currentHour > openinng)
            {
                if (currentHour < closing) entering = currentHour;
                else entering = openinng;
            }
            else entering = openinng;
            if (cheapest.Cost < cheapest.Cost             
                && entering + l.Schedule.RequieredTime <= closing           
                && entering + l.Schedule.RequieredTime <= limitHour)        
            {
                float satisfactionValue = l.Satisfaction.Value;
                if (nature == Leisure.typeToNatureMatching[(int)l.LeisureType]) satisfactionValue += Global.Values.matchingNatureBonues;
                cheapest.Enter = entering;
                cheapest.Place = l.LeisurePlace;
                cheapest.Satisfaction = satisfactionValue;
                cheapest.TimeExpended = l.Schedule.RequieredTime;
                cheapest.Cost = l.Cost;
            }
        }
        return cheapest;
    }

    public override string ToString()
    {
        string res = "";
        res += Investment.ToString() + "\n";
        res += Fun.ToString() + "\n";
        res += "All leisure places:\n==========================================\n";
        foreach (Leisure l in LeisureVenues) if (l!=null) res += l.ToString() + "\n";
        return res;
    }
}
