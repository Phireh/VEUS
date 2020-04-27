using System;
using System.Collections;
using System.Collections.Generic;

public struct Coords
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Coords(int x, int y) { X = x; Y = y; }
}

public class CityPart
{
    //////////////////////
    // Static Component //
    //////////////////////

    public enum PLACE
    {
        NORTH = 0,
        WEST = 1,
        SOUTH = 2,
        EAST = 3,
        CENTER = 4
    }
    public enum POPULATION
    {
        UNDER_POPULATED = 0,
        SMALL = 1,
        MEDIA = 2,
        LARGE = 3,
        OVER_POPULATED = 4
    }
    public static int[] populationLimitValues = new int[]
    {
        100,       // UNDER_POPULATED
        150,       // SMALL
        200,       // MEDIA
        250,       // LARGE
        300        // OVER_POPULATED
    };

    public enum INDUSTRY
    {
        UNDER_DEVELOPED = 0,
        DEVELOPING = 1,
        DEVELOPED = 2
    }
    public enum FUN
    {
        BORING = 0,
        ENJOYABLE = 1,
        ENTERTAINING = 2
    }
    public enum INFRASTRUCTURE
    {
        OLD_FASHINED = 0,
        UP_TO_DATE = 1,
        CUTTING_EDGE = 2
    }
    public enum SECTOR_INVESTMENT
    {
        LOW = 0,
        MEDIUM = 1,
        HIGH = 2
    }

    public enum SECTOR_TYPE
    {
        TRANSPORT = 0,
        LEISURE = 1,
        INDUSTRY = 2
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    City city;
    int[,] cityHomesGrid;
    List<Coords> nonAllocatedHomes;
    int lowClassCitizens, middleClassCitizens, highClassCitizens;
    int noneEnvriomentalCommitmentCitizens, someEnviromentalCommitmentCitizens, fullEnviromentalCommitmentCitizens;
    int calmedTimeManagementCitizens, normalTimeManagementCitizens, rushedTimeManagementCitizens;
    int stingyMoneyManagementCitizens, responsibleMoneyManagementCitizens, wastefulMoneyManagementCitizens;
    int activeNatureCitizens, calmNatureCitizens, socialNatureCitizens, dreamerNatureCitizens;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public PLACE CityPlace { get; private set; }
    public RepresentativeIndex GlobalHappiness { get; private set; }
    public RepresentativeIndex GlobalHealth { get; private set; }
    public TransportSector TransportSector { get; private set; }
    public LeisureSector LeisureSector { get; private set; }
    public IndustrySector IndustrySector { get; private set; }
    public Dictionary<int, Citizen> Citizens { get; private set; }
    public int CitizensCount { get; private set; }
    public RepresentativeIndex LowClassProportion { get; private set; }
    public RepresentativeIndex MiddleClassProportion { get; private set; }
    public RepresentativeIndex HighClassProportion { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public CityPart(PLACE cityPlace, POPULATION population, Citizen.ECONOMIC_CLASS populationWealth, INDUSTRY industry,
        SECTOR_INVESTMENT industryInvestment, FUN fun, SECTOR_INVESTMENT leisureInvestment,
        INFRASTRUCTURE infrastructure, SECTOR_INVESTMENT transportInvestment, City city)
    {
        this.city = city;
        CityPlace = cityPlace;
        Citizens = new Dictionary<int, Citizen>();
        nonAllocatedHomes = new List<Coords>();
        cityHomesGrid = new int[32, 32];
        GlobalHappiness = new RepresentativeIndex("Felicidad Global", "Felicidad Global en el barrio " + CityPlace, 0.5f);
        GlobalHealth = new RepresentativeIndex("Salud Global", "Salud Global en el barrio " + CityPlace, 0.5f);
        LowClassProportion = new RepresentativeIndex("Clase Baja", "Proporción de ciudadanos de clase baja en el barrio " + CityPlace, 0.5f);
        MiddleClassProportion = new RepresentativeIndex("Clase Media", "Proporción de ciudadanos de clase media en el barrio " + CityPlace, 0.5f);
        HighClassProportion = new RepresentativeIndex("Clase Alta", "Proporción de ciudadanos de clase alta en el barrio " + CityPlace, 0.5f);
        InitLaboralSector(industry, industryInvestment);
        InitTransportSector(infrastructure, transportInvestment);
        InitLeisureSector(fun, leisureInvestment);
        InitPopulation(population, populationWealth); // It has to be the last initialization
        //ProcessDay();
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void InitLaboralSector(INDUSTRY industry, SECTOR_INVESTMENT investment)
    {
        float investmentValue = 0f, developementValue = 0;
        switch (industry)
        {
            case INDUSTRY.UNDER_DEVELOPED: developementValue = 0.25f; break;
            case INDUSTRY.DEVELOPING: developementValue = 0.5f; break;
            case INDUSTRY.DEVELOPED: developementValue = 0.75f; break;
        }
        switch (investment)
        {
            case SECTOR_INVESTMENT.LOW: investmentValue = 0.25f; break;
            case SECTOR_INVESTMENT.MEDIUM: investmentValue = 0.5f; break;
            case SECTOR_INVESTMENT.HIGH: investmentValue = 0.75f; break;
        }
        IndustrySector = new IndustrySector(investmentValue, developementValue, CityPlace, city);
    }

    void InitLeisureSector(FUN fun, SECTOR_INVESTMENT investment)
    {
        float investmentValue = 0f, funValue = 0;
        switch (fun)
        {
            case FUN.BORING: funValue = 0.25f; break;
            case FUN.ENJOYABLE: funValue = 0.5f; break;
            case FUN.ENTERTAINING: funValue = 0.75f; break;
        }
        switch (investment)
        {
            case SECTOR_INVESTMENT.LOW: investmentValue = 0.25f; break;
            case SECTOR_INVESTMENT.MEDIUM: investmentValue = 0.5f; break;
            case SECTOR_INVESTMENT.HIGH: investmentValue = 0.75f; break;
        }
        LeisureSector = new LeisureSector(investmentValue, funValue, CityPlace);
    }

    void InitTransportSector(INFRASTRUCTURE infrastructure, SECTOR_INVESTMENT investment)
    {

        float investmentValue = 0f, infrastructureValue = 0;
        switch (infrastructure)
        {
            case INFRASTRUCTURE.OLD_FASHINED: infrastructureValue = 0.25f; break;
            case INFRASTRUCTURE.UP_TO_DATE: infrastructureValue = 0.5f; break;
            case INFRASTRUCTURE.CUTTING_EDGE: infrastructureValue = 0.75f; break;
        }
        switch (investment)
        {
            case SECTOR_INVESTMENT.LOW: investmentValue = 0.25f; break;
            case SECTOR_INVESTMENT.MEDIUM: investmentValue = 0.5f; break;
            case SECTOR_INVESTMENT.HIGH: investmentValue = 0.75f; break;
        }
        TransportSector = new TransportSector(investmentValue, infrastructureValue, CityPlace);
    }

    int InitPopulation(POPULATION population, Citizen.ECONOMIC_CLASS wealth)
    {
        for (int x = 0; x < 32; x++)
            for (int y = 0; y < 32; y++)
            {
                cityHomesGrid[x, y] = -1; // The houses are not ocupied by any citizen
                nonAllocatedHomes.Add(new Coords(x, y));
            }

        // Creating the Citizens
        for (int i = 0; i < populationLimitValues[(int)population]; i++)
        {
            string name = "Ciudadano " + i + " de " + CityPlace;
            Citizen.ECONOMIC_CLASS economicClass = wealth;
            if (Global.Methods.GetRandomPercentage(0, 100) < 0.25f)
                economicClass = (Citizen.ECONOMIC_CLASS)Global.Methods.GetRandom(Enum.GetNames(typeof(Citizen.ECONOMIC_CLASS)).Length);
            Index.STATE healthState = Index.STATE.MEDIUM, happinessState = Index.STATE.MEDIUM;
            CityPart.PLACE livingPlace = CityPlace;
            Citizen newCitizen = Citizen.CitizenFromAproximation(name, economicClass, healthState, happinessState, livingPlace, city);
            if (!InstallNewCitizen(newCitizen)) return 0;
        }
        return 1024 - Citizens.Count;
    }

    Coords AllocateCitizen()
    {
        Coords res = new Coords(-1, -1);
        try
        {
            res = nonAllocatedHomes[0];
            nonAllocatedHomes.RemoveAt(0);
        }
        catch (ArgumentOutOfRangeException) { }
        return res;
    }

    ////////////////////
    // Public Methods //
    ////////////////////
    public int CountClassCitizens(Citizen.ECONOMIC_CLASS economicClass)
    {
        switch (economicClass)
        {
            case Citizen.ECONOMIC_CLASS.LOW: return lowClassCitizens;
            case Citizen.ECONOMIC_CLASS.MIDDLE: return middleClassCitizens;
            case Citizen.ECONOMIC_CLASS.HIGH: return highClassCitizens;
            default: return -1;
        }
    }
    public int CountEnviromentalCommitmentCitizens(Citizen.ENVIROMENTAL_COMMITMENT envCommitment)
    {
        switch (envCommitment)
        {
            case Citizen.ENVIROMENTAL_COMMITMENT.NONE: return noneEnvriomentalCommitmentCitizens;
            case Citizen.ENVIROMENTAL_COMMITMENT.SOME : return someEnviromentalCommitmentCitizens;
            case Citizen.ENVIROMENTAL_COMMITMENT.FULL: return fullEnviromentalCommitmentCitizens;
            default: return -1;
        }
    }
    public int CountNatureCitizens(Citizen.NATURE nature)
    {
        switch (nature)
        {
            case Citizen.NATURE.ACTIVE: return activeNatureCitizens;
            case Citizen.NATURE.CALM: return calmNatureCitizens;
            case Citizen.NATURE.DREAMER: return dreamerNatureCitizens;
            case Citizen.NATURE.SOCIAL: return socialNatureCitizens;
            default: return -1;
        }
    }
    public int CountTimeManagementCitizens(Citizen.TIME_MANAGEMENT timeManagement)
    {
        switch (timeManagement)
        {
            case Citizen.TIME_MANAGEMENT.CALMED: return calmedTimeManagementCitizens;
            case Citizen.TIME_MANAGEMENT.NORMAL: return normalTimeManagementCitizens;
            case Citizen.TIME_MANAGEMENT.RUSHED: return rushedTimeManagementCitizens;
            default: return -1;
        }
    }
    public int CountMoneyManagementCitizens(Citizen.MONEY_MANAGEMENT moneyManagement)
    {
        switch (moneyManagement)
        {
            case Citizen.MONEY_MANAGEMENT.STINGY: return stingyMoneyManagementCitizens;
            case Citizen.MONEY_MANAGEMENT.RESPONSIBLE: return responsibleMoneyManagementCitizens;
            case Citizen.MONEY_MANAGEMENT.WASTEFUL: return wastefulMoneyManagementCitizens;
            default: return -1;
        }
    }

    public bool InstallNewCitizen(Citizen newCitizen)
    {
        Coords coords = AllocateCitizen();
        if (coords.X < 0) return false;
        newCitizen.Home = coords;
        Citizens.Add(newCitizen.ID, newCitizen);
        cityHomesGrid[coords.X, coords.Y] = newCitizen.ID;
        return true;
    }

    public void DumpCitizen(Coords coords)
    {
        int id = cityHomesGrid[coords.X, coords.Y];
        cityHomesGrid[coords.X, coords.Y] = -1;
        Citizens.Remove(id);
        nonAllocatedHomes.Insert(Global.Methods.GetRandom(nonAllocatedHomes.Count), coords);
    }

    public void ProcessDay()
    {
        foreach (Citizen c in Citizens.Values)
            c.ProcessDay();
        float happinessValueSum = 0f;
        float healthValueSum = 0f;
        int citizensCount = 0;
        int lowClassCitizensCount = 0, middleClassCitizensCount = 0, highClassCitizensCount = 0;
        int noneEnvriomentalCommitmentCitizensCount = 0, someEnviromentalCommitmentCitizensCount = 0, fullEnviromentalCommitmentCitizensCount = 0;
        int calmedTimeManagementCitizensCount = 0, normalTimeManagementCitizensCount = 0, rushedTimeManagementCitizensCount = 0;
        int stingyMoneyManagementCitizensCount = 0, responsibleMoneyManagementCitizensCount = 0, wastefulMoneyManagementCitizensCount = 0;
        int activeNatureCitizensCount = 0, calmNatureCitizensCount = 0, socialNatureCitizensCount = 0, dreamerNatureCitizensCount = 0;
        foreach (Citizen c in Citizens.Values)
        {
            healthValueSum += c.Health.Value;
            happinessValueSum += c.Happiness.Value;
            citizensCount++;
            switch (c.GetEconomicClass())
            {
                case Citizen.ECONOMIC_CLASS.LOW: lowClassCitizensCount++; break;
                case Citizen.ECONOMIC_CLASS.MIDDLE: middleClassCitizensCount++; break;
                case Citizen.ECONOMIC_CLASS.HIGH: highClassCitizensCount++; break;
            }
            switch (c.GetEnviromentalCommitment())
            {
                case Citizen.ENVIROMENTAL_COMMITMENT.NONE: noneEnvriomentalCommitmentCitizensCount++; break;
                case Citizen.ENVIROMENTAL_COMMITMENT.SOME: someEnviromentalCommitmentCitizensCount++; break;
                case Citizen.ENVIROMENTAL_COMMITMENT.FULL: fullEnviromentalCommitmentCitizensCount++; break;
            }
            switch (c.Nature)
            {
                case Citizen.NATURE.ACTIVE: activeNatureCitizensCount++; break;
                case Citizen.NATURE.CALM: calmNatureCitizensCount++; break;
                case Citizen.NATURE.DREAMER: dreamerNatureCitizensCount++; break;
                case Citizen.NATURE.SOCIAL: socialNatureCitizensCount++; break;
            }
            switch (c.GetTimeManagement())
            {
                case Citizen.TIME_MANAGEMENT.CALMED: calmedTimeManagementCitizensCount++; break;
                case Citizen.TIME_MANAGEMENT.NORMAL: normalTimeManagementCitizensCount++; break;
                case Citizen.TIME_MANAGEMENT.RUSHED: rushedTimeManagementCitizensCount++; break;
            }
            switch (c.GetMoneyManagement())
            {
                case Citizen.MONEY_MANAGEMENT.STINGY: stingyMoneyManagementCitizensCount++; break;
                case Citizen.MONEY_MANAGEMENT.RESPONSIBLE: responsibleMoneyManagementCitizensCount++; break;
                case Citizen.MONEY_MANAGEMENT.WASTEFUL: wastefulMoneyManagementCitizensCount++; break;
            }
        }
        GlobalHealth.Value = healthValueSum / citizensCount;
        GlobalHappiness.Value = happinessValueSum / citizensCount;
        CitizensCount = citizensCount;

        lowClassCitizens = lowClassCitizensCount;
        LowClassProportion.Value =  lowClassCitizens / (float) CitizensCount;
        middleClassCitizens = middleClassCitizensCount;
        MiddleClassProportion.Value = middleClassCitizens / (float) CitizensCount;
        highClassCitizens = highClassCitizensCount;
        HighClassProportion.Value = highClassCitizens / (float) CitizensCount;

        noneEnvriomentalCommitmentCitizens = noneEnvriomentalCommitmentCitizensCount;
        someEnviromentalCommitmentCitizens = someEnviromentalCommitmentCitizensCount;
        fullEnviromentalCommitmentCitizens = fullEnviromentalCommitmentCitizensCount;

        activeNatureCitizens = activeNatureCitizensCount;
        calmNatureCitizens = calmNatureCitizensCount;
        dreamerNatureCitizens = dreamerNatureCitizensCount;
        socialNatureCitizens = socialNatureCitizensCount;

        calmedTimeManagementCitizens = calmedTimeManagementCitizensCount;
        normalTimeManagementCitizens = normalTimeManagementCitizensCount;
        rushedTimeManagementCitizens = rushedTimeManagementCitizensCount;

        stingyMoneyManagementCitizens = stingyMoneyManagementCitizensCount;
        responsibleMoneyManagementCitizens = responsibleMoneyManagementCitizensCount;
        wastefulMoneyManagementCitizens = wastefulMoneyManagementCitizensCount;

        TransportSector.ProcessDay();
    }

    public override string ToString()
    {
        string res = "City Part: " + CityPlace;
        res += "\nIndustry Sector: " + IndustrySector.ToString();
        res += "\nTransport Sector: " + TransportSector.ToString();
        res += "\nLeisure Sector: " + LeisureSector.ToString();
        res += "\nNumber of people: " + Citizens.Count + " | Number of free houses: " + nonAllocatedHomes.Count;
        res += "\nFirst 5 citizens:\n=====================================================================\n";
        int cont = 0;
        foreach (Citizen c in Citizens.Values)
        {
            res += c.ToString() + "\n";
            if (++cont > 4) break;
        }
        return res;
    }
}
