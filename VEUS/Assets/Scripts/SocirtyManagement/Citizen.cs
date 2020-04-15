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
    public static int[] economicClassLimitiValues = new int[]
    {
        1500,   // LOW
        3500,   // MIDDLE
        10000   // HIGH
    };
    /// <summary>
    /// Describes the kind of things that make the citizen happier easy
    /// </summary>
    public enum NATURE
    {
        ACTIVE = 0,     // Loves sports
        CALM = 1,       // Loves calmed activities
        SOCIAL = 2,     // Loves partys
        DREAMER = 3     // Loves shows
    }
    public enum ENVIROMENTAL_COMMITMENT
    {
        NONE = 0,
        SOME = 1,
        FULL = 2
    }
    public enum TIME_MANAGEMENT
    {
        CALMED = 0,
        NORMAL = 1,
        RUSHED = 2
    }
    public enum SCHEDULED_ACTIVITY
    {
        NONE = 0,
        MOVE_TO_WORK = 1,
        WORK = 2,
        HAVE_FUN = 3,
        REST = 4
    }

    static int idCount;

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    string name;
    int money;
    Index health;
    Index happiness;
    CityPart.PLACE livingPlace;
    CityPart.PLACE workingPlace;
    IndustrySector.AcceptedJob acceptedJob;
    int contractRemainingDays;
    City city;
    SCHEDULED_ACTIVITY[] dailySchedule;
    ENVIROMENTAL_COMMITMENT enviromentalCommitment;
    TIME_MANAGEMENT timeManagement;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public int ID { get; private set; }
    public DependentIndex Health { get; private set; }
    public DependentIndex Happiness { get; private set; }
    public CityPart.PLACE LivingPlace { get; private set; }
    public CityPart.PLACE WorkingPlace { get; private set; }
    public NATURE Nature { get; private set; } // TODO currently there is not way to define the nature of the citizen from the public methods or constructors 
    public Coords Home { get; set; }


    /////////////////////
    /// Constructors ///
    ////////////////////

    public Citizen(string name, int money, float healthValue, float happinessValue,
        CityPart.PLACE livingPlace, CityPart.PLACE workingPlace, ENVIROMENTAL_COMMITMENT envCommitment, City city)
    {
        this.enviromentalCommitment = envCommitment;
        this.city = city;
        ID = idCount++;
        this.name = name;
        this.money = money;
        Health = new DependentIndex("Salud", "Salud de " + name, healthValue);
        Happiness = new DependentIndex("Felicidad", "Felicidad de " + name, happinessValue); 
        LivingPlace = livingPlace;
        WorkingPlace = workingPlace;
        acceptedJob = new IndustrySector.AcceptedJob(new Coords(), Job.TYPE.NONE, 0, 0, 0, 999);
    }

    //////////////////////
    /// Static Methods ///
    //////////////////////

    public static Citizen RandomCitizen(City city)
    {
        string name = "Random Citizen " + idCount;
        return RandomCitizen(name, city);
    }

    public static Citizen RandomCitizen(string name, City city)
    {
        ECONOMIC_CLASS economicClass = (ECONOMIC_CLASS)Global.Methods.GetRandom(Enum.GetNames(typeof(ECONOMIC_CLASS)).Length);
        Index.STATE healthState = (Index.STATE)Global.Methods.GetRandom(Enum.GetNames(typeof(Index.STATE)).Length);
        Index.STATE happinesState = (Index.STATE)Global.Methods.GetRandom(Enum.GetNames(typeof(Index.STATE)).Length);
        CityPart.PLACE livingPlace = (CityPart.PLACE)Global.Methods.GetRandom(Enum.GetNames(typeof(CityPart.PLACE)).Length);
        CityPart.PLACE workingPlace = (CityPart.PLACE)Global.Methods.GetRandom(Enum.GetNames(typeof(CityPart.PLACE)).Length);
        Citizen res = CitizenFromAproximation(name, economicClass, healthState, happinesState, livingPlace, workingPlace, city);
        return res;
    }

    public static Citizen CitizenFromAproximation(string name, ECONOMIC_CLASS economicClass,
        Index.STATE healthState, Index.STATE happinessState, CityPart.PLACE livingPlace, CityPart.PLACE workingPlace, City city)
    {
        int money;
        switch (economicClass)
        {
            case ECONOMIC_CLASS.LOW:
                money = Global.Methods.GetRandom(0, 1500);
                break;
            case ECONOMIC_CLASS.HIGH:
                money = Global.Methods.GetRandom(3500, 10000);
                break;
            case ECONOMIC_CLASS.MIDDLE:
            default:
                money = Global.Methods.GetRandom(1500, 3500);
                break;
        }
        float healthValue = Index.GetRoughValueFromState(healthState);
        float happinessValue = Index.GetRoughValueFromState(happinessState);
        Citizen res = new Citizen(name, money, healthValue, happinessValue, livingPlace, workingPlace, ENVIROMENTAL_COMMITMENT.NONE, city);
        return res;
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void ResetDailySchedule() => dailySchedule = new SCHEDULED_ACTIVITY[24]; // The automatic initiallization of an enum 'E' puts its value to '(E)0'; NONE, in this case

    //////////////////////
    /// Public Methods ///
    //////////////////////

    public ECONOMIC_CLASS GetEconomicClass()
    {
        if (money < economicClassLimitiValues[(int)ECONOMIC_CLASS.LOW]) return ECONOMIC_CLASS.LOW;
        else if (money < economicClassLimitiValues[(int)ECONOMIC_CLASS.MIDDLE]) return ECONOMIC_CLASS.MIDDLE;
        else return ECONOMIC_CLASS.HIGH;
    }

    public int AddMoney(int extraMoney) => this.money += extraMoney;
    public int RemoveMoney(int extraMoney) => this.money -= extraMoney;
    public int GetMoney() => this.money;
    public ENVIROMENTAL_COMMITMENT GetEnviromentalCommitment() => this.enviromentalCommitment;
    public void SetEnviromentalCommitment(ENVIROMENTAL_COMMITMENT newCommitment) => this.enviromentalCommitment = newCommitment;
    public TIME_MANAGEMENT GetTimeManagement() => this.timeManagement;
    public void SetTimeManagement(TIME_MANAGEMENT newTimeManagement) => this.timeManagement = newTimeManagement;

    public SCHEDULED_ACTIVITY[] ProcessDay()    // TODO: Currently if the places where the citizen lives and works are different the time to travel 
    {                                           // is calculated without taking into the consideration the TransportSector of the place where he worls
        ResetDailySchedule(); // All hours are set to NONE
        int lastWorkHour = -1;

        if (acceptedJob.JobType == Job.TYPE.NONE) // If the citizen is unenployed
        {
            acceptedJob = city.CityParts[(int)livingPlace].IndustrySector.GetWorkOffer();
            if (acceptedJob.JobType == Job.TYPE.NONE) // If the citizen cannot find a job in his neightbourhood...
            {   // tries a second time. This time can be in any part of the city
                acceptedJob = city.CityParts[(int)livingPlace].IndustrySector.GetWorkOffer(); 
            }
        }

        if (acceptedJob.JobType != Job.TYPE.NONE) // If the citizen has a job
        {
            for (int i = 0; i < acceptedJob.TimeRequiered; i++) // Sets the working hours in the schedule
            {
                int j = acceptedJob.Enter + i;
                if (j > 23) j -= 24;
                dailySchedule[j] = SCHEDULED_ACTIVITY.WORK;
            }

            // This parts calculates how mucha hours the citizen needs to travel to work
            int distanceToJob = 0;
            if (livingPlace == workingPlace)
                distanceToJob += Math.Abs(acceptedJob.Coords.X - Home.X) + Math.Abs(acceptedJob.Coords.Y - Home.Y);
            else
                distanceToJob += acceptedJob.Coords.X + acceptedJob.Coords.Y + Home.X + Home.Y;
            float enviromentalConmmitmentValue = Global.Values.citizenEnviromentalTransportPreferences[(int)enviromentalCommitment];
            int transportHoursLimit = Global.Values.citizenTransportTimePreferences[(int)timeManagement];
            if (transportHoursLimit > 24 - acceptedJob.TimeRequiered) transportHoursLimit = 24 - acceptedJob.TimeRequiered;
            float rand = Global.Methods.GetRandomPercentage();
            TransportSector.TransportPlan transportPlan;
            if (rand < enviromentalConmmitmentValue)  // If the citizen is pro-enviroment will probably choose the least polluting option
            {
                 transportPlan =
                    city.CityParts[(int)livingPlace].TransportSector.GetLeastPolluting(distanceToJob, transportHoursLimit);
            }
            else // otherwise will choose between safety and speed
            {
                if (Health.GetIndexState() < Index.STATE.MEDIUM)  // If the citizen's health is low, he will go for the safest option
                    transportPlan =
                        city.CityParts[(int)livingPlace].TransportSector.GetSafest(distanceToJob, transportHoursLimit);
                else // if that's not the case, he will choose the fastest
                    transportPlan =
                        city.CityParts[(int)livingPlace].TransportSector.GeFastest(distanceToJob, transportHoursLimit);
            }

            if (transportPlan.Transport == Transport.TYPE.NONE) // If the citizen can't go to work he gets sad, and A PANALTY
            {
                Happiness.ChangeIndexValue(Index.CHANGE.LOW_DROP);
                RemoveMoney(Global.Values.failingToWorkPenalty);
                acceptedJob.RemainingDays--;
            }
            else
            {   // Using the transport has a cost in health
                Health.ChangeIndexValue(-(1 - transportPlan.Safety));
                lastWorkHour = acceptedJob.Enter + acceptedJob.TimeRequiered;
            }

            // If the citizens has no transport plan (because there are not viable options) => transportPlan.TimeRequiered = -1
            for (int i = 1; i < transportPlan.TimeRequiered + 1; i++)  // Sets the moving to work hours in the schedule
            {
                int j = acceptedJob.Enter - i;
                if (j < 0) j += 24;
                dailySchedule[j] = SCHEDULED_ACTIVITY.MOVE_TO_WORK;
            }

            if (acceptedJob.RemainingDays < 0)  // The day 0 is included
                acceptedJob = city.CityParts[(int)livingPlace].IndustrySector.FreeWorkOffer(acceptedJob.Coords);
        }

        LeisureSector.LeisurePlan leisurePlan = LeisureSector.GetNullPlan();
        if (Health.GetIndexState() > Index.STATE.LOW) // If the citizen is not sick he will try to have fun
        {
            if (lastWorkHour < 0)
                leisurePlan = city.CityParts[(int)livingPlace].LeisureSector.GetPlan(Nature, 0, 23);
            else
                leisurePlan = city.CityParts[(int)livingPlace].LeisureSector.GetPlan(Nature, lastWorkHour + 1, acceptedJob.Enter - 1);
        }

        if (leisurePlan.Place != Leisure.PLACE.NONE)
        {
            RemoveMoney(leisurePlan.Cost);
            Happiness.ChangeIndexValue(leisurePlan.Satisfaction);

            for (int i = 0; i < leisurePlan.TimeExpended; i++)
            {
                int j = leisurePlan.Enter + i;
                if (j > 23) j -= 24;
                dailySchedule[j] = SCHEDULED_ACTIVITY.HAVE_FUN;
            }
        }y

        // If the citizen's schedule contains enough continious hours without activitys this ours become resting hours. Theese ones are healthy
        int continiousNoneActivutyHours = 0;
        int firstActivityHour = -1;
        for (int i = 0; i < 24; i++)
        {
            SCHEDULED_ACTIVITY s = dailySchedule[i];
            if (s == SCHEDULED_ACTIVITY.NONE) continiousNoneActivutyHours++;
            else if (firstActivityHour < 0) firstActivityHour = i;
            if (continiousNoneActivutyHours == Global.Values.minContiniousHoursToRest)
            {
                for (int j = i; j > i - continiousNoneActivutyHours; j--) dailySchedule[j] = SCHEDULED_ACTIVITY.REST;
                continiousNoneActivutyHours = 0;
            }
        }
        if (continiousNoneActivutyHours + firstActivityHour + 1 >= Global.Values.minContiniousHoursToRest && firstActivityHour + 1 < Global.Values.minContiniousHoursToRest)
            for (int i = 0; i < continiousNoneActivutyHours + firstActivityHour + 1; i++)
            {
                int j = continiousNoneActivutyHours + i;
                if (j > 23) j -= 24;
                dailySchedule[j] = SCHEDULED_ACTIVITY.REST;
            }

        foreach (SCHEDULED_ACTIVITY s in dailySchedule)
            if (s == SCHEDULED_ACTIVITY.REST) Health.ChangeIndexValue(Global.Values.restingHourBonus);

        return dailySchedule;
    }
    
}
