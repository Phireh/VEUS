using System;

public class WorkOffers
{
    /////////////////////////
    /// Private Variables ///
    /////////////////////////

    Job policeman;
    Job doctor;
    Job cleaner;
    Job officeWorker;
    Job subwayWorker;
    Job executiveOfficer;

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

    /////////////////////
    /// Constructors ///
    ////////////////////    

    public WorkOffers(Job policeman, Job doctor, Job cleaner, Job subwayWorker,
        Job officeWorker, Job executiveOfficer)
    {
        Policeman = policeman;
        Doctor = doctor;
        Cleaner = cleaner;
        SubwayWorker = subwayWorker;
        OfficeWorker = officeWorker;
        ExecutiveOfficer = executiveOfficer;
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////



    //////////////////////
    /// Public Methods ///
    //////////////////////
}
