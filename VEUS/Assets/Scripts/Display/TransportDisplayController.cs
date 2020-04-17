using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TransportDisplayController : MonoBehaviour
{
    public TextMeshProUGUI transportType;    

    public TextMeshProUGUI capacity;
    public TextMeshProUGUI baseSpeed;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI freeSpaces;

    public TMP_Dropdown expansions;
    public TMP_Dropdown enhancements;

    public GameObject indexBarSpeed;
    public GameObject indexBarWear;
    public GameObject indexBarPollution;
    // Start is called before the first frame update
    public void SetData(Transport transport)
    {
        transportType.text = transport.TransportType.ToString();

        capacity.text = transport.Capacity.ToString();
        baseSpeed.text = transport.GetBaseSpeed().ToString();
        speed.text = transport.Speed.ToString();
        freeSpaces.text = SocietyManagement.CityOfToday.CityParts[0].TransportSector.GetFreeSpaces(transport.TransportType).ToString();

        expansions.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Transport.EXPANSION)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        expansions.AddOptions(options);
        expansions.value = (int)transport.GetExpansionState();

        enhancements.ClearOptions();
        options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Transport.ENHANCEMENTS)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        enhancements.AddOptions(options);
        enhancements.value = (int)transport.GetEnhancements();

        indexBarSpeed.GetComponent<IndexBarController>().IndexID = transport.SpeedIndex.ID;
        indexBarWear.GetComponent<IndexBarController>().IndexID = transport.Wear.ID;
        indexBarPollution.GetComponent<IndexBarController>().IndexID = transport.Polluting.ID;
    }

    public void OnExpansionsValueChange(int newValue)
    {
        Debug.Log("New Extension Value Selected: " + (Job.EXTENSION)newValue);
    }

    public void OnEnhancementsValueChange(int newValue)
    {
        Debug.Log("New Extension Value Selected: " + (Job.EXTENSION)newValue);
    }
}
