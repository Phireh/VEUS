using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportSectorDisplayController : MonoBehaviour
{
    public GameObject indexBarInvestment;
    public GameObject indexBarTechnology;
        
    public GameObject streetPanel;
    public GameObject roadPanel;
    public GameObject cycleLanePanel;
    public GameObject subwayPanel;
    // Start is called before the first frame update
    public void SetData(TransportSector ts)
    {
        indexBarInvestment.GetComponent<IndexBarController>().IndexID = ts.Investment.ID;
        indexBarTechnology.GetComponent<IndexBarController>().IndexID = ts.Technology.ID;

        streetPanel.GetComponent<TransportDisplayController>().SetData(ts.Transports[(int)Transport.TYPE.STREET]);
        cycleLanePanel.GetComponent<TransportDisplayController>().SetData(ts.Transports[(int)Transport.TYPE.CYCLE_LANE]);
        subwayPanel.GetComponent<TransportDisplayController>().SetData(ts.Transports[(int)Transport.TYPE.SUBWAY]);
        roadPanel.GetComponent<TransportDisplayController>().SetData(ts.Transports[(int)Transport.TYPE.ROAD]);

    }
}
