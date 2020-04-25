using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TransportDisplayController : MonoBehaviour
{
    int initiallized = 0;

    Transport displayedTransport;

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
        initiallized = 0;
        displayedTransport = transport;
        transportType.text = transport.TransportType.ToString();

        capacity.text = SocietyDataInterface.GetTransportCapacity(transport.CityPlace, transport.TransportType).ToString();
        baseSpeed.text = SocietyDataInterface.GetTransportBaseSpeed(transport.CityPlace, transport.TransportType).ToString();
        speed.text = SocietyDataInterface.GetTransportSpeed(transport.CityPlace, transport.TransportType).ToString();
        freeSpaces.text = SocietyDataInterface.GetTransportSectorFreeSpaces(transport.CityPlace, transport.TransportType).ToString();

        expansions.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Transport.EXPANSION)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        expansions.AddOptions(options);
        expansions.value = (int)SocietyDataInterface.GetTransportExpansions(transport.CityPlace, transport.TransportType);

        enhancements.ClearOptions();
        options = new List<TMP_Dropdown.OptionData>();
        foreach (var e in Enum.GetNames(typeof(Transport.ENHANCEMENTS)))
            options.Add(new TMP_Dropdown.OptionData() { text = e });
        enhancements.AddOptions(options);
        enhancements.value = (int)SocietyDataInterface.GetTransportEnhancements(transport.CityPlace, transport.TransportType);

        indexBarSpeed.GetComponent<IndexBarController>().IndexID = transport.SpeedIndex.ID;
        indexBarWear.GetComponent<IndexBarController>().IndexID = transport.Wear.ID;
        indexBarPollution.GetComponent<IndexBarController>().IndexID = transport.Polluting.ID;
    }

    void SetData() => SetData(displayedTransport);

    public void OnExpansionsValueChange(int newValue)
    {     
        if (initiallized++ > 1)
        {
            if (newValue != expansions.value)
            {
                Debug.Log("You have not changed the dropdown value");
                return;
            }
            Debug.Log("Expansion value changed");
            SocietyDataInterface.AddTransportExpansionsChange(displayedTransport.CityPlace, displayedTransport.TransportType, (Transport.EXPANSION)newValue);
        }
        else initiallized++;
    }

    public void OnEnhancementsValueChange(int newValue)
    {
        if (initiallized++ > 1)
        {
            if (newValue != enhancements.value)
            {
                Debug.Log("You have not changed the dropdown value");
                return;
            }
            Debug.Log("Enhancements value changed");
            SocietyDataInterface.AddTransportEnhancementsChange(displayedTransport.CityPlace, displayedTransport.TransportType, (Transport.ENHANCEMENTS)newValue);
        }
        else initiallized++;
    }
}
