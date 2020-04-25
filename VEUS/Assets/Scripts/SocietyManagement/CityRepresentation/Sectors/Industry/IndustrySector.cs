using System;
using System.Collections;
using System.Collections.Generic;

public class IndustrySector
{
    //////////////////////
    // Static Component //
    //////////////////////

    public struct WorkOfferInGrid
    {
        public Job.TYPE Job { get; set; }
        public bool Allocated { get; set; }

        public WorkOfferInGrid(Job.TYPE job, bool allocated)
        {
            Allocated = allocated;
            Job = job;
        }
    }

    public struct AcceptedJob
    {
        public int Enter { get; set; }
        public int RemainingDays { get; set; }
        public int TimeRequiered { get; set; }
        public Coords Coords { get; set; }
        public Job.TYPE JobType { get; set; }
        public CityPart.PLACE CityPlace { get; set; }
        public int Salary { get; set; }
        public AcceptedJob(Coords coords, Job.TYPE job, int salary, int enter, int time, int contractedDays, CityPart.PLACE cityPlace)
        {
            Coords = coords; JobType = job; Salary = salary; Enter = enter; TimeRequiered = time; RemainingDays = contractedDays; CityPlace = cityPlace;
        }
    }

    public static AcceptedJob GetNullJob() => new AcceptedJob(new Coords(-1, -1), Job.TYPE.NONE, 0, -1, -1, 999, CityPart.PLACE.CENTER);

    ///////////////////////
    // Private Variables //
    ///////////////////////

    int jobsCount;
    City city;
    WorkOfferInGrid[,] cityOffersGrid;
    List<Coords> nonAllocatedWorkOffers;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public CityPart.PLACE CityPlace {get; private set;}
    public Job[] Jobs { get; private set; }
    public ConditionableIndex Investment { get; private set; }
    public ConditionableIndex Development { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndustrySector(float investmentValue, float developmentValue, CityPart.PLACE cityPlace, City city)
    {
        this.city = city;
        CityPlace = cityPlace;
        Development = new ConditionableIndex("Riqueza", "Nivel de riqueza de los trabajadores en el barrio "
            + Global.Names.cityPart[(int)cityPlace], developmentValue);
        Investment = new ConditionableIndex("Inversión", "Nivel de inversión dirigida a los oficios en el barrio "
            + Global.Names.cityPart[(int)cityPlace], investmentValue);

        jobsCount = Enum.GetNames(typeof(Job.TYPE)).Length;
        Jobs = new Job[jobsCount];

        Jobs[(int)Job.TYPE.POLICEMAN]
            = new Job(Job.TYPE.POLICEMAN, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);
        Jobs[(int)Job.TYPE.DOCTOR]
            = new Job(Job.TYPE.DOCTOR, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);
        Jobs[(int)Job.TYPE.CLEANER]
            = new Job(Job.TYPE.CLEANER, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);
        Jobs[(int)Job.TYPE.SUBWAY_WORKER]
            = new Job(Job.TYPE.SUBWAY_WORKER, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);
        Jobs[(int)Job.TYPE.OFFICE_WORKER]
            = new Job(Job.TYPE.OFFICE_WORKER, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);
        Jobs[(int)Job.TYPE.EXECUTIVE_OFFICER]
            = new Job(Job.TYPE.EXECUTIVE_OFFICER, Job.EXTENSION.NORMAL, Job.TIME_DEMAND.FULL_TIME, Job.DURATION.STANDARD, cityPlace);

        InitiallizeWorkOffers();
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void InitiallizeWorkOffers()
    {
        nonAllocatedWorkOffers = new List<Coords>();
        cityOffersGrid = new WorkOfferInGrid[32, 32];
        Job.TYPE currentJobType = (Job.TYPE)1;
        int aux = Global.Values.jobsQuantity[(int)Jobs[(int)currentJobType].GetExtension(), (int)currentJobType];
        for (int i = 0; i < 1024; i++)
        {
            //Global.Methods.PrintInfo(Jobs[(int)currentJobType].GetExtension() + "_" + i.ToString() +": " + currentJobType);
            if (i < aux)
            {
                if ((int)currentJobType >= Global.Values.jobsQuantity.Length) break;
                int x = i / 32;
                int y = i % 32;
                cityOffersGrid[x, y] = new WorkOfferInGrid(currentJobType, false);
                nonAllocatedWorkOffers.Insert(Global.Methods.GetRandom(nonAllocatedWorkOffers.Count), new Coords(x, y)); // The insertion is random
            }
            else
            {
                currentJobType++;
                if (jobsCount > (int)currentJobType)
                    aux += Global.Values.jobsQuantity[(int)Jobs[(int)currentJobType].GetExtension(), (int)currentJobType];
                else break;
            }
        }
    }

    Coords AllocateWorkOffer()
    {
        Coords res = new Coords(-1, -1);
        try
        {
            res = nonAllocatedWorkOffers[0];
            nonAllocatedWorkOffers.RemoveAt(0);
        }
        catch (ArgumentOutOfRangeException) { }
        return res;
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////

    public AcceptedJob GetWorkOffer()
    {
        Coords availableOffferCords = AllocateWorkOffer();
        AcceptedJob res = GetNullJob();
        if (availableOffferCords.X < 0)
            return res;
        WorkOfferInGrid offer = cityOffersGrid[availableOffferCords.X, availableOffferCords.Y];
        res.Coords = availableOffferCords;
        res.JobType = offer.Job;
        res.Salary = Jobs[(int)offer.Job].Salary;
        res.TimeRequiered = Jobs[(int)offer.Job].Schedule.RequieredTime;
        res.Enter = Jobs[(int)offer.Job].Schedule.Start;
        res.RemainingDays = Jobs[(int)offer.Job].ContractedDays;
        res.CityPlace = CityPlace;
        return res;
    }

    public AcceptedJob FreeWorkOffer(Coords coords)
    {
        cityOffersGrid[coords.X, coords.Y].Allocated = false;
        nonAllocatedWorkOffers.Insert(Global.Methods.GetRandom(nonAllocatedWorkOffers.Count), coords); //The insertion is random
        return GetNullJob();
    }

    public override string ToString()
    {
        string res = "";
        res += "Available Offers: " + nonAllocatedWorkOffers.Count + "\n";
        res += Investment.ToString() + "\n";
        res += Development.ToString() + "\n";
        res += "All work offer types:\n==========================================\n";
        foreach (Job j in Jobs) if (j!=null) res += j.ToString() + "\n";
        return res;
    }
}
