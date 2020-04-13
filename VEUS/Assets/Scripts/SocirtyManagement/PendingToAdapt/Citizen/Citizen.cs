using System;
using System.Collections;
using System.Collections.Generic;

public class Citizen
{
    /// <summary>
    /// Defines the economic status of the citizen depending on their money: 
    /// LOW (< 1500) | MIDDLE ([1500..3500]) | HIGH > 3500
    /// </summary>
    public enum ECONOMIC_CLASS
    {
        LOW = 0,
        MIDDLE = 1,
        HIGH = 2
    }
    /// <summary>
    /// Describes the kind of things that make the citizen happier easy
    /// </summary>
    public enum NATURE
    {
        ACTIVE = 0, // Loves sports
        CALM = 1,  // Loves calmed activities
        SOCIAL = 2, // Loves partys
        DREAMER = 3 // Loves shows
    }

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    string name;
    int money;
    Index health;
    Index happiness;
    CityPart.PLACE livingPlace;
    CityPart.PLACE workingPlace;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////
    
    public int Money
    {
        get { return money; }
        private set { if (value > 0) money = value; }
    }
    public Index Health
    {
        get { return health; }
        private set { if (value.Value > 0 && value.Value <= 1) health = value; }
    }
    public Index Happiness
    {
        get { return happiness; }
        private set { if (value.Value > 0 && value.Value <= 1) happiness = value; }
    }
    public CityPart.PLACE LivingPlace
    {
        get { return livingPlace; }
        private set { livingPlace = value; }
    }
    public CityPart.PLACE WorkingPlace
    {
        get { return workingPlace; }
        private set { workingPlace = value; }
    }

    public ECONOMIC_CLASS GetEconomicClass()
    {
        if (Money < 1500) return ECONOMIC_CLASS.LOW;
        else if (Money < 3500) return ECONOMIC_CLASS.MIDDLE;
        else return ECONOMIC_CLASS.HIGH;
    }

    /////////////////////
    /// Constructors ///
    ////////////////////
    
    public Citizen()
    {
        name = "Ciudadano";
        Money = 1000;
        Health = new Index("Salud", "Salud de " + name, 0.75f);
        Happiness = new Index("Felicidad", "Felicidad de " + name, 0.75f);
        LivingPlace = CityPart.PLACE.CENTER;
        WorkingPlace = CityPart.PLACE.CENTER;
    }

    public Citizen(string name, int money, float healthValue, float happinessValues, CityPart.PLACE livingPlace, CityPart.PLACE workingPlace)
    {
        this.name = name;
        Money = money;
        Health = new Index("Salud", "Salud de " + name,healthValue);
        Happiness = new Index("Felicidad", "Felicidad de " + name, happinessValues); 
        LivingPlace = livingPlace;
        WorkingPlace = workingPlace;
    }

    public static Citizen RandomCitizen()
    {
        string name = "Random Citizen";
        return RandomCitizen(name);
    }


    //////////////////////
    /// Static Methods ///
    //////////////////////
    
    public static Citizen RandomCitizen(string name)
    {
        Random rand = new Random();
        ECONOMIC_CLASS economicClass = (ECONOMIC_CLASS)rand.Next(Enum.GetNames(typeof(ECONOMIC_CLASS)).Length);
        Index.STATE healthState = (Index.STATE)rand.Next(Enum.GetNames(typeof(Index.STATE)).Length);
        Index.STATE happinesState = (Index.STATE)rand.Next(Enum.GetNames(typeof(Index.STATE)).Length);
        CityPart.PLACE livingPlace = (CityPart.PLACE)rand.Next(Enum.GetNames(typeof(CityPart.PLACE)).Length);
        CityPart.PLACE workingPlace = (CityPart.PLACE)rand.Next(Enum.GetNames(typeof(CityPart.PLACE)).Length);
        Citizen res = CitizenFromAproximation(name, economicClass, healthState, happinesState, livingPlace, workingPlace);
        return res;
    }

    public static Citizen CitizenFromAproximation(string name, ECONOMIC_CLASS economicClass,
        Index.STATE healthState, Index.STATE happinessState, CityPart.PLACE livingPlace, CityPart.PLACE workingPlace)
    {
        Random rand = new Random();
        int money;
        switch (economicClass)
        {
            case ECONOMIC_CLASS.LOW:
                money = rand.Next(0, 1500);
                break;
            case ECONOMIC_CLASS.HIGH:
                money = rand.Next(3500, 10000);
                break;
            case ECONOMIC_CLASS.MIDDLE:
            default:
                money = rand.Next(1500, 3500);
                break;
        }
        float healthValue = Index.GetRoughValueFromState(healthState);
        float happinessValue = Index.GetRoughValueFromState(happinessState);
        Citizen res = new Citizen(name, money, healthValue, happinessValue, livingPlace, workingPlace);
        return res;
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////
}
