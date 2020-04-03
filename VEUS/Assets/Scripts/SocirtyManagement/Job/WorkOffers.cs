using System;

public class WorkOffers
{
    Job policeman;
    public Job Policeman
    {
        get { return policeman; }
        set { policeman = value; }
    }
    Job doctor;
    public Job Doctor
    {
        get { return doctor; }
        set { doctor = value; }
    }
    Job cleaner;
    public Job Cleaner
    {
        get { return cleaner; }
        set { cleaner = value; }
    }
    Job subwayWorker;
    public Job SubwayWorker
    {
        get { return subwayWorker; }
        set { subwayWorker = value; }
    }
    Job officeWorker;
    public Job OfficeWorker

    {
        get { return officeWorker; }
        set { officeWorker = value; }
    }
    Job executiveOfficer;
    public Job ExecutiveOfficer
{
        get { return executiveOfficer; }
        set { executiveOfficer = value; }
    }

    public WorkOffers()
    {
        Policeman = new Job(Job.TYPE.POLICEMAN, 50, 1000, 8, 20);
        Doctor = new Job(Job.TYPE.DOCTOR, 25, 1250, 8, 20);
        Cleaner = new Job(Job.TYPE.CLEANER, 15, 650, 5, 13);
        SubwayWorker = new Job(Job.TYPE.SUBWAY_WORKER, 15, 750, 7, 17);
        OfficeWorker = new Job(Job.TYPE.OFFICE_WORKER, 450, 850, 9, 18);
        ExecutiveOfficer = new Job(Job.TYPE.EXECUTIVE_OFFICER, 5, 4500, 8, 19);
    }

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
}
