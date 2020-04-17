﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LeisureDisplayController : MonoBehaviour
{
    public TextMeshProUGUI leisurePlace;

    public TextMeshProUGUI cost;

    public TextMeshProUGUI opening;
    public TextMeshProUGUI closing;
    public TextMeshProUGUI time;

    public TMP_Dropdown availability;

    public GameObject indexBar;
    // Start is called before the first frame update
    public void SetData(Leisure leisure)
    {
        leisurePlace.text = leisure.LeisurePlace.ToString();

        cost.text = leisure.Cost.ToString();

        opening.text = leisure.Schedule.Opening.ToString();
        closing.text = leisure.Schedule.Closing.ToString();
        time.text = leisure.Schedule.RequieredTime.ToString();

        availability.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Leisure.AVAILABILITY)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        availability.AddOptions(options);
        availability.value = (int)leisure.GetAvailability();

        indexBar.GetComponent<IndexBarController>().IndexID = leisure.Satisfaction.ID;
    }

    public void OnAvailabilityValueChange(int newValue)
    {
        Debug.Log("New Extension Value Selected: " + (Job.EXTENSION)newValue);
    }
}