using System;

public class WorkOffers
{
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    CityPart.PLACE cityPlace;
    Job policeman;
    Job doctor;
    Job cleaner;
    Job officeWorker;
    Job subwayWorker;
    Job executiveOfficer;
    Index investment;
    Index wealth;

    /////////////////////////
    /// Public Properties ///
    /////////////////////////

    public Job Policeman
    {
        get { return policeman; }
        private set { policeman = value; }
    }
    public Job Doctor
    {
        get { return doctor; }
        private set { doctor = value; }
    }
    public Job Cleaner
    {
        get { return cleaner; }
        private set { cleaner = value; }
    }
    public Job SubwayWorker
    {
        get { return subwayWorker; }
        private set { subwayWorker = value; }
    }
    public Job OfficeWorker

    {
        get { return officeWorker; }
        private set { officeWorker = value; }
    }
    public Job ExecutiveOfficer
{
        get { return executiveOfficer; }
        private set { executiveOfficer = value; }
    }
    public Index Investment
    {
        get { return investment; }
        private set { investment = value; }
    }
    public Index Wealth
    {
        get { return wealth; }
        private set { wealth = value; }
    }
    /////////////////////
    /// Constructors ///
    ////////////////////    

    public WorkOffers(float investmentValue, float wealthValue, CityPart.PLACE cityPlace)
    {
        this.cityPlace = cityPlace;

        Investment = new Index("Inversión", "Nivel de inversión dirigida al sector laboral en el barrio "
            + Names.cityPart[(int)cityPlace], investmentValue);
        Wealth = new Index("Riqueza", "Nivel de riqueza de la gente del barrio "
            + Names.cityPart[(int)cityPlace], wealthValue);

        if (Investment.GetIndexState() > Index.STATE.LOW)
            IcreaseOrDropRequieredEffort(Job.TYPE.POLICEMAN, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.MEDIUM)
            IcreaseOrDropRequieredEffort(Job.TYPE.DOCTOR, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.HIGH)
            IcreaseOrDropRequieredEffort(Job.TYPE.CLEANER, Index.CHANGE.LOW_INCREASE);
        if (Investment.GetIndexState() > Index.STATE.VERY_HIGH)
            IcreaseOrDropRequieredEffort(Job.TYPE.SUBWAY_WORKER, Index.CHANGE.LOW_INCREASE);

        Policeman = new Job(Job.TYPE.POLICEMAN, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
        Doctor = new Job(Job.TYPE.DOCTOR, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
        Cleaner = new Job(Job.TYPE.CLEANER, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
        SubwayWorker = new Job(Job.TYPE.SUBWAY_WORKER, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
        OfficeWorker = new Job(Job.TYPE.OFFICE_WORKER, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
        ExecutiveOfficer = new Job(Job.TYPE.EXECUTIVE_OFFICER, Job.DURATION.STANDARD, Job.TIME_DEMAND.FULL_TIME, Job.EXTENSION.NORMAL, cityPlace);
    
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    ////////////////////
    // Public Methods //
    ////////////////////
    
    public Index.STATE IcreaseOrDropRequieredEffort(Job.TYPE type, Index.CHANGE change)
    {
        Job j;
        switch (type)
        {
            case Job.TYPE.POLICEMAN:
                j = policeman;
                break;
            case Job.TYPE.DOCTOR:
                j = doctor;
                break;
            case Job.TYPE.CLEANER:
                j = cleaner;
                break;
            case Job.TYPE.SUBWAY_WORKER:
                j = subwayWorker;
                break;
            case Job.TYPE.OFFICE_WORKER:
                j = officeWorker;
                break;
            case Job.TYPE.EXECUTIVE_OFFICER:
            default:
                j = executiveOfficer;
                break;
        }
        return j.RequieredEffort.ChangeIndexValue(change);
    }
}
