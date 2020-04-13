using System.Collections;
using System.Collections.Generic;

public class Job
{
    ////////////////////////
    /// Static Variables ///
    ////////////////////////

    public static int baseQuantityPoliceman = 50;
    public static int baseQuantityDoctor = 25;
    public static int baseQuantityCleaner = 15;
    public static int baseQuantitySubwayWorker = 15;
    public static int baseQuantityOfficeWorker = 450;
    public static int baseQuantityExecutiveOfficer = 5;
    public static int baseSalaryPoliceman = 1000;
    public static int baseSalaryDoctor = 1250;
    public static int baseSalaryCleaner = 650;
    public static int baseSalarySubwayWorker = 750;
    public static int baseSalaryOfficeWorker  = 850;
    public static int baseSalaryExecutiveOfficer = 4500;
    public static int baseStartPoliceman = 8;
    public static int baseStartDoctor = 8;
    public static int baseStartCleaner = 5;
    public static int baseStartSubwayWorker = 7;
    public static int baseStartOfficeWorker = 9;
    public static int baseStartExecutiveOfficer = 8;
    public static int baseWorkingHoursPoliceman = 12;
    public static int baseWorkingHoursDoctor = 12;
    public static int baseWorkingHoursCleaner = 8;
    public static int baseWorkingHoursSubwayWorker = 10;
    public static int baseWorkingHoursOfficeWorker = 9;
    public static int baseWorkingHoursExecutiveOfficer = 10;
    public static float baseRequieredEffortPoliceman = 0.7f;
    public static float baseRequieredEffortDoctor = 0.85f;
    public static float baseRequieredEffortCleaner = 0.65f;
    public static float baseRequieredEffortSubwayWorker = 0.55f;
    public static float baseRequieredEffortOfficeWorker = 0.6f;
    public static float baseRequieredEffortExecutiveOfficer = 0.6f;
    public static int baseDaysPoliceman = 50;
    public static int baseDaysDoctor = 35;
    public static int baseDaysCleaner = 15;
    public static int baseDaysSubwayWorker = 25;
    public static int baseDaysOfficeWorker = 30;
    public static int baseDaysExecutiveOfficer = 100;
    
    /// <summary>
    /// Deifferent work offers
    /// </summary>
    public enum TYPE
    {
        POLICEMAN = 0,
        DOCTOR = 1,
        CLEANER = 2,
        SUBWAY_WORKER = 3,
        OFFICE_WORKER = 4,
        EXECUTIVE_OFFICER = 5
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

    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    CityPart.PLACE cityPlace;
    EXTENSION extension;
    TIME_DEMAND timeDemand;
    DURATION duration;
    TYPE jobType;
    int quantity;
    int salary;
    int start;
    int finish;
    Index requieredEffort;
    int contractedDays;
    int baseQuantity;
    int baseSalary;
    int baseStart;
    int baseWorkingHours;
    float baseRequieredEffortValue;
    int baseDays;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public EXTENSION Extension
    {
        get { return extension; }
        private set { extension = value; }
    }
    public TIME_DEMAND TimeDemand
    {
        get { return timeDemand; }
        private set { timeDemand = value; }
    }
    public DURATION Duration
    {
        get { return duration; }
        private set { duration = value; }
    }
    // Type of job
    public TYPE JobType
    {
        get { return jobType; }
        private set { jobType = value; }
    }
    // How many people can get the job
    public int Quantity
    {
        get { return quantity; }
        private set { if (value >= 0) quantity = value; }
    }
    // How much does a citizen get paid for the job
    public int Salary
    {
        get { return salary; }
        private set { if (value >= 0) salary = value; }
    }
    // First labourable hour [0..23]
    public int Start
    {
        get { return start; }
        private set { if (value >= 0 && value < 24) SetWorkingSchedule(value, WorkingHours); }
    }
    // Last labourable hour [0..23]
    public int WorkingHours
    {
        get { return GetWorkingHours(); }
        private set { if (value >= 0 && value < 24) SetWorkingSchedule(start, value); }
    }
    public int Finish
    {
        get { return finish; }
        private set { finish = value; }
    }
    // Effort requiered to do the job
    public Index RequieredEffort
    {
        get { return requieredEffort; }
        private set { if (value.Value > 0 && value.Value <= 1) requieredEffort = value; }
    }
    // Days before the contract expires
    public int ContractedDays
    {
        get { return contractedDays; }
        private set { if (value >= 0) contractedDays = value; }
    }

    /////////////////////
    /// Constructors ///
    ////////////////////

    public Job(TYPE jobType, int quantity, int salary, int start, int finish, float requieredEffortValue,
        int contractedDays, DURATION duration, TIME_DEMAND timeDemand, EXTENSION extension, CityPart.PLACE cityPlace)
    {
        SetInitialValues(jobType, quantity, salary, start, finish, requieredEffortValue,
            contractedDays, duration, timeDemand, extension, cityPlace);
    }

    public Job(TYPE jobType, DURATION duration, TIME_DEMAND timeDemand, EXTENSION extension, CityPart.PLACE cityPlace)
    {
        int quantity;
        int salary;
        int start;
        int workingHours;
        float requieredEffortValue;
        int contractedDays;
        switch (jobType)
        {
            case TYPE.POLICEMAN:
                quantity = baseQuantityPoliceman;
                salary = baseSalaryPoliceman;
                start = baseStartPoliceman;
                workingHours = baseWorkingHoursPoliceman;
                requieredEffortValue = baseRequieredEffortPoliceman;
                contractedDays = baseDaysPoliceman;
                break;
            case TYPE.DOCTOR:
                quantity = baseQuantityDoctor;
                salary = baseSalaryDoctor;
                start = baseStartDoctor;
                workingHours = baseWorkingHoursDoctor;
                requieredEffortValue = baseRequieredEffortDoctor;
                contractedDays = baseDaysDoctor;
                break;
            case TYPE.CLEANER:
                quantity = baseQuantityCleaner;
                salary = baseSalaryCleaner;
                start = baseStartCleaner;
                workingHours = baseWorkingHoursCleaner;
                requieredEffortValue = baseRequieredEffortCleaner; 
                contractedDays = baseDaysCleaner;
                break;
            case TYPE.SUBWAY_WORKER:
                quantity = baseQuantitySubwayWorker;
                salary = baseSalarySubwayWorker;
                start = baseStartSubwayWorker;
                workingHours = baseWorkingHoursSubwayWorker;
                requieredEffortValue = baseRequieredEffortSubwayWorker; 
                contractedDays = baseDaysSubwayWorker;
                break;
            case TYPE.OFFICE_WORKER:
                quantity = baseQuantityOfficeWorker;
                salary = baseSalaryOfficeWorker;
                start = baseStartOfficeWorker;
                workingHours = baseWorkingHoursOfficeWorker;
                requieredEffortValue = baseRequieredEffortOfficeWorker; 
                contractedDays = baseDaysOfficeWorker;
                break;
            case TYPE.EXECUTIVE_OFFICER:
            default:
                quantity = baseQuantityExecutiveOfficer;
                salary = baseSalaryExecutiveOfficer;
                start = baseStartExecutiveOfficer;
                workingHours = baseWorkingHoursExecutiveOfficer;
                requieredEffortValue = baseRequieredEffortExecutiveOfficer;
                contractedDays = baseDaysExecutiveOfficer;
                break;
        }
        SetInitialValues(jobType, quantity, salary, start, workingHours, requieredEffortValue,
            contractedDays, duration, timeDemand, extension, cityPlace);
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    void SetInitialValues(TYPE jobType, int quantity, int salary, int start, int workingHours, float requieredEffortValue,
        int contractedDays, DURATION duration, TIME_DEMAND timeDemand, EXTENSION extension, CityPart.PLACE cityPlace)
    {
        this.cityPlace = cityPlace;
        JobType = jobType;
        Quantity = quantity;
        Salary = salary;
        SetWorkingSchedule(start, workingHours);
        ContractedDays = contractedDays;
        RequieredEffort = new Index("Esfuerzo Necesario", "Esfuerzo necesario para ser " + Names.jobs[(int)jobType]
             + " en el barrio " + Names.cityPart[(int)cityPlace], requieredEffortValue);
        Duration = DURATION.STANDARD;
        switch (duration)
        {
            case DURATION.TEMPORARY:
                DecrementContractDuration();
                break;
            case DURATION.LONG_TERM:
                IncrementContractDuration();
                break;
            case DURATION.STANDARD:
            default:
                break;
        }
        TimeDemand = TIME_DEMAND.FULL_TIME;
        switch (timeDemand)
        {
            case TIME_DEMAND.PART_TIME:
                DecrementTimeDemand();
                break;
            case TIME_DEMAND.EXTRA_HOURS:
                IncrementTimeDemand();
                break;
            case TIME_DEMAND.FULL_TIME:
            default:
                break;
        }
        Extension = EXTENSION.NORMAL;
        switch (extension)
        {
            case EXTENSION.LIMITED:
                Contract();
                break;
            case EXTENSION.EXTENDED:
                Extend();
                break;
            case EXTENSION.NORMAL:
            default:
                break;
        }
    }

    void SetWorkingSchedule(int start, int workingHours)
    {
        if (workingHours > 23) workingHours = 23;
        else if (workingHours < 1) workingHours = 1;
        this.start = start;
        bool betweeenDays = false;
        if (this.start + workingHours > 23) betweeenDays = true;
        if (betweeenDays) this.finish = 23 - this.start;
        else this.finish = start + workingHours;
    }

    int GetWorkingHours()
    {
        if (this.finish < this.start) return 23 - this.start + this.finish;
        else return this.finish - this.start;
    }

    //////////////////////
    /// Public Methods ///
    //////////////////////

    public bool Extend()
    {
        switch (this.extension)
        {
            case EXTENSION.LIMITED:
                this.extension = EXTENSION.NORMAL;
                this.quantity = baseQuantity;
                return true;
            case EXTENSION.NORMAL:
                this.quantity = (int)(baseQuantity * 2.5f);
                this.extension = EXTENSION.EXTENDED;
                return true;
            case EXTENSION.EXTENDED:
            default:
                return false;
        }
    }

    public bool Contract()
    {
        switch (this.extension)
        {
            case EXTENSION.EXTENDED:
                this.extension = EXTENSION.NORMAL;
                this.quantity = baseQuantity;
                return true;
            case EXTENSION.NORMAL:
                this.quantity = (int)(baseQuantity * 0.5f);
                this.extension = EXTENSION.LIMITED;
                return true;
            case EXTENSION.LIMITED:
            default:
                return false;
        }
    }

    public bool IncrementTimeDemand()
    {
        switch (this.TimeDemand)
        {
            case TIME_DEMAND.PART_TIME:
                timeDemand = TIME_DEMAND.FULL_TIME;
                SetWorkingSchedule(baseStart, baseWorkingHours);
                return true;
            case TIME_DEMAND.FULL_TIME:
                timeDemand = TIME_DEMAND.EXTRA_HOURS;
                SetWorkingSchedule(baseStart, (int)(baseWorkingHours * 1.5f));
                return true;
            case TIME_DEMAND.EXTRA_HOURS:
            default:
                return false;

        }
    }

    public bool DecrementTimeDemand()
    {
        switch (this.TimeDemand)
        {
            case TIME_DEMAND.EXTRA_HOURS:
                timeDemand = TIME_DEMAND.FULL_TIME;
                SetWorkingSchedule(baseStart, baseWorkingHours);
                return true;
            case TIME_DEMAND.FULL_TIME:
                timeDemand = TIME_DEMAND.PART_TIME;
                SetWorkingSchedule(baseStart, (int)(baseWorkingHours * 0.5f));
                return true;
            case TIME_DEMAND.PART_TIME:
            default:
                return false;
        }
    }

    public bool IncrementContractDuration()
    {
        switch (this.duration)
        {
            case DURATION.TEMPORARY:
                duration = DURATION.STANDARD;
                contractedDays = baseDays;
                return true;
            case DURATION.STANDARD:
                duration = DURATION.LONG_TERM;
                contractedDays = baseDays * 2;
                return true;
            case DURATION.LONG_TERM:
            default:
                return false;
        }
    }

    public bool DecrementContractDuration()
    {
        switch (this.duration)
        {
            case DURATION.LONG_TERM:
                duration = DURATION.STANDARD;
                contractedDays = baseDays;
                return true;
            case DURATION.STANDARD:
                duration = DURATION.TEMPORARY;
                contractedDays = (int) (baseDays * 0.25f);
                return true;
            case DURATION.TEMPORARY:
            default:
                return false;
        }
    }
}
