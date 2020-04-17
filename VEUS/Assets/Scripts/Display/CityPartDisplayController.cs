using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CityPartDisplayController : MonoBehaviour
{
   public TextMeshProUGUI cityPart;

    public GameObject industrySectorPanel;
    public GameObject leisureSectorPanel;
    public GameObject transportSectorPanel;
    // Start is called before the first frame update
    public void SetData(CityPart p)
    {
        cityPart.text = p.CityPlace.ToString();

        industrySectorPanel.GetComponent<IndustrialSectorDisplayController>().SetData(p.IndustrySector);
        leisureSectorPanel.GetComponent<LeisureSectorDisplayController>().SetData(p.LeisureSector);
        transportSectorPanel.GetComponent<TransportSectorDisplayController>().SetData(p.TransportSector);
    }
}
