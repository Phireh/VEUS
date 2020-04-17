using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class JobDisplayController : MonoBehaviour
{public TextMeshProUGUI jobType;

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

    public void OnExtensioValueChange(int newValue)
    {
        Debug.Log("New Extension Value Selected: " + (Job.EXTENSION)newValue);
    }
    public void OnDurationValueChange(int newValue)
    {
        Debug.Log("New Duration Value Selected: " + (Job.EXTENSION)newValue);
    }
    public void OnTimeDemandValueChange(int newValue)
    {
        Debug.Log("New Time Demand Value Selected: " + (Job.EXTENSION)newValue);
    }
}
