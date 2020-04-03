using System.Collections;
using System.Collections.Generic;

public class Job
{
    public enum TYPE
    {
        POLICEMAN = 0,
        DOCTOR = 1,
        CLEANER = 2,
        SUBWAY_WORKER = 3,
        OFFICE_WORKER = 4,
        EXECUTIVE_OFFICER = 5
    }

    TYPE jobType;
    // Type of job
    public TYPE JobType
    {
        get { return jobType; }
        set { jobType = value; }
    }
    int quantity;
    // How many people can get the job
    public int Quantity
    {
        get { return quantity; }
        set { if (value >= 0) quantity = value; }
    }
    int salary;
    // How much does a citizen get paid for the job
    public int Salary
    {
        get { return salary; }
        set { if (value >= 0) salary = value; }
    }
    int start;
    // First labourable hour [0..23]
    public int Start
    {
        get { return start; }
        set { if (value >= 0 && value < 24) start = value; }
    }
    int finish;
    // Last labourable hour [0..23]
    public int Finish
    {
        get { return finish; }
        set { if (value >= 0 && value < 24) finish = value; }
    }

    public Job()
    {
        JobType = TYPE.OFFICE_WORKER;
        Quantity = 100;
        Salary = 600;
        Start = 9;
        Finish = 18;
    }

    public Job(TYPE jobType, int quantity, int salary, int start, int finish)
    {
        JobType = jobType;
        Quantity = quantity;
        Salary = salary;
        Start = start;
        Finish = finish;
    }
}
