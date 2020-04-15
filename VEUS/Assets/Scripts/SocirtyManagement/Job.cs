using System;
using System.Collections;
using System.Collections.Generic;

public class Job
{
    //////////////////////
    // Static Component //
    //////////////////////

    /// <summary>
    /// Deifferent work offers
    /// </summary>
    public enum TYPE
    {
        NONE = 0,
        POLICEMAN = 1,
        DOCTOR = 2,
        CLEANER = 3,
        SUBWAY_WORKER = 4,
        OFFICE_WORKER = 5,
        EXECUTIVE_OFFICER = 6
    }
    /// <summary>
    /// Type of contract refering how much time it lasts
    /// </summary>
    public enum DURATION
    {
        TEMPORARY = 0,
        STANDARD = 1,
        LONG_TERM = 2
    }
    /// <summary>
    /// Type of contract refering how much time it takes every day
    /// </summary>
    public enum TIME_DEMAND
    {
        PART_TIME = 0,
        FULL_TIME = 1,
        EXTRA_HOURS = 2
    }
    /// <summary>
    /// Amount of people that can access to the job compared to the original
    /// </summary>
    public enum EXTENSION
    {
        LIMITED = 0,
        NORMAL = 1,
        EXTENDED = 2
    }

    public struct JobSchedule
    {
        // Opening hour [0..23]
        public int Start { get; private set; }
        // Time needed to do the activity [>0]
        public int RequieredTime { get; set; }

        public JobSchedule(int start, int timeRequiered)
        {
            if (start > 23) Start = 23;
            else if (start < 0) Start = 0;
            else Start = start;
            if (timeRequiered > 23) RequieredTime = 23;
            else if (timeRequiered < 1) RequieredTime = 1;
            else RequieredTime = timeRequiered;
        }
    }

    ///////////////////////
    // Private Variables //
    ///////////////////////

    EXTENSION extension;
    TIME_DEMAND timeDemand;
    DURATION duration;

    ///////////////////////
    // Public Properties //
    ///////////////////////


    public int Quantity { get; private set; }
    public int Salary { get; private set; }
    public int ContractedDays { get; private set; }
    public JobSchedule Schedule { get; private set; }
    public CityPart.PLACE CityPlace { get; private set; }
    public TYPE JobType { get; private set; }
    public ConditionableIndex RequieredEffort { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public Job(TYPE jobType, EXTENSION extension, TIME_DEMAND timeDemand, DURATION duration, CityPart.PLACE cityPlace)
    {
        int quantity = Global.Values.jobsQuantity[(int)extension, (int)jobType];
        int salary = Global.Values.jobsSalary[(int)jobType];
        int contractedDays = Global.Values.jobsContractedDays[(int)duration, (int)jobType];
        float requieredEffortValue = Global.Values.jobsRequieredEffort[(int)timeDemand, (int)jobType];
        JobSchedule newSchedule = new JobSchedule(Global.Values.jobsStart[(int)jobType],
            Global.Values.jobsWorkingHours[(int)timeDemand, (int)jobType]);
        SetInitialValues(jobType, quantity, salary, contractedDays, newSchedule,
            requieredEffortValue, extension, timeDemand, duration, cityPlace);
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    void SetInitialValues(TYPE jobType, int quantity, int salary, int contractedDays, JobSchedule schedule,
        float requieredEffortValue, EXTENSION extension, TIME_DEMAND timeDemand, DURATION duration, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        JobType = jobType;
        this.extension = extension;
        this.timeDemand = timeDemand;
        this.duration = duration;
        Quantity = quantity;
        ContractedDays = contractedDays;
        Schedule = schedule;
        RequieredEffort = new ConditionableIndex("Esfuerzo Requerido", "Representacuanto esfuerzo ers necesario para ser "
            + Global.Names.jobs[(int)jobType] + " en el barrio " + Global.Names.cityPart[(int)cityPlace], requieredEffortValue);
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public void SetExtension(EXTENSION extension)
    {
        this.extension = extension;
        Quantity = Global.Values.jobsQuantity[(int)extension, (int)JobType];
    }
    public EXTENSION GetExtension() => this.extension;
    public void SetTimeDemand(TIME_DEMAND timeDemand)
    { 
        this.timeDemand = timeDemand;
        RequieredEffort.Value = Global.Values.jobsRequieredEffort[(int)timeDemand, (int)JobType]; ;
        Schedule = new JobSchedule(Global.Values.jobsStart[(int)JobType], Global.Values.jobsWorkingHours[(int)timeDemand, (int)JobType]);
    }
    public TIME_DEMAND GetTimeDemand() => this.timeDemand;
    public void SetDuration(DURATION duration)
    {
        this.duration = duration;
        ContractedDays = Global.Values.jobsContractedDays[(int)duration, (int)JobType];
    }
    public DURATION GetDuration() => this.duration;
    public int GetFinish()
    {
        int closing = Schedule.Start + Schedule.RequieredTime;
        if (closing > 23) return closing - 24;
        else return closing;
    }

}
