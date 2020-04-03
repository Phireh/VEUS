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
        Index policemanEffort = new Index("Policeman ER", "Indicates the effort requiered to be a Policeman", 0.7f);
        Policeman = new Job(Job.TYPE.POLICEMAN, 50, 1000, 8, 20, policemanEffort);
        Index doctorEffort = new Index("Doctor ER", "Indicates the effort requiered to be a Doctor", 0.85f);
        Doctor = new Job(Job.TYPE.DOCTOR, 25, 1250, 8, 20, doctorEffort);
        Index cleanerEffort = new Index("Cleaner ER", "Indicates the effort requiered to be a Cleaner", 0.65f);
        Cleaner = new Job(Job.TYPE.CLEANER, 15, 650, 5, 13, cleanerEffort);
        Index subwayWorkerEffort = new Index("Subway Worker ER", "Indicates the effort requiered to be a Subway Worker", 0.55f);
        SubwayWorker = new Job(Job.TYPE.SUBWAY_WORKER, 15, 750, 7, 17, subwayWorkerEffort);
        Index officeWorkerEffort = new Index("Office Worker  ER", "Indicates the effort requiered to be an Office Worker", 0.6f);
        OfficeWorker = new Job(Job.TYPE.OFFICE_WORKER, 450, 850, 9, 18, officeWorkerEffort);
        Index executiveOfficerEffort = new Index("Executive Officer ER", "Indicates the effort requiered to be an ExecutiveOfficer", 0.6f);
        ExecutiveOfficer = new Job(Job.TYPE.EXECUTIVE_OFFICER, 5, 4500, 8, 19, executiveOfficerEffort);
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
