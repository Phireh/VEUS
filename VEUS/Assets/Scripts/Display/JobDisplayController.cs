using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class JobDisplayController : MonoBehaviour
{
    Job displayedJob;
    int initiallized = 0;

    public TextMeshProUGUI jobType;

    public TextMeshProUGUI quantityOfOffers;
    public TextMeshProUGUI salary;
    public TextMeshProUGUI contractDuration;

    public TextMeshProUGUI start;
    public TextMeshProUGUI spentTime;

    public TMP_Dropdown extension;
    public TMP_Dropdown timeDemand;
    public TMP_Dropdown duration;

    public GameObject indexBar;
    // Start is called before the first frame update
    public void SetData(Job job)
    {
        initiallized = 0;
        displayedJob = job;

        jobType.text = job.JobType.ToString();

        quantityOfOffers.text = job.Quantity.ToString();
        salary.text = job.Salary.ToString();
        contractDuration.text = job.ContractedDays.ToString();

        start.text = job.Schedule.Start.ToString();
        spentTime.text = job.Schedule.RequieredTime.ToString();

        extension.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Job.EXTENSION)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        extension.AddOptions(options);
        extension.value = (int)job.GetExtension();

        timeDemand.ClearOptions();
        options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Job.TIME_DEMAND)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        timeDemand.AddOptions(options);
        timeDemand.value = (int)job.GetTimeDemand();

        duration.ClearOptions();
        options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Job.DURATION)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        duration.AddOptions(options);
        duration.value = (int)job.GetDuration();

        indexBar.GetComponent<IndexBarController>().IndexID = job.RequieredEffort.ID;
    }

    void SetData() => SetData(displayedJob);

    public void OnExtensioValueChange(int newValue)
    {
        if (initiallized++ > 2)
        {
            if (newValue == extension.value)
            {
                Debug.Log("You have not changed the dropdown value");
                return;
            }
            SocietyDataInterface.AddIndustryExtensionChange(displayedJob.CityPlace, displayedJob.JobType, (Job.EXTENSION)newValue);
            Debug.Log("Extension value changed");
        }
    }
    public void OnDurationValueChange(int newValue)
    {
        if (initiallized++ > 2)
        {
            if (newValue != duration.value)
            {
                Debug.Log("You have not changed the dropdown value");
                return;
            }
            Debug.Log("Duration value changed");
            SocietyDataInterface.AddIndustryContractsDurationChange(displayedJob.CityPlace, displayedJob.JobType, (Job.DURATION)newValue);
        }
    }
    public void OnTimeDemandValueChange(int newValue)
    {
        if (initiallized++ > 2)
        {
            if (newValue != timeDemand.value)
            {
                Debug.Log("You have not changed the dropdown value");
                return;
            }
            SocietyDataInterface.AddIndustryTimeDemandChange(displayedJob.CityPlace, displayedJob.JobType, (Job.TIME_DEMAND)newValue);
            Debug.Log("Time demand value changed");
        }
    }
}
