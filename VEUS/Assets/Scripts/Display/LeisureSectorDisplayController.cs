using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeisureSectorDisplayController : MonoBehaviour
{
    public GameObject indexBarInvestment;
    public GameObject indexBarFun;
        
    public GameObject discoPanel;
    public GameObject gymPanel;
    public GameObject parkLanePanel;
    public GameObject cinemaPanel;
    // Start is called before the first frame update
    public void SetData(LeisureSector ls)
    {
        indexBarInvestment.GetComponent<IndexBarController>().IndexID = ls.Investment.ID;
        indexBarFun.GetComponent<IndexBarController>().IndexID = ls.Fun.ID;

        discoPanel.GetComponent<LeisureDisplayController>().SetData(ls.LeisureVenues[(int)Leisure.PLACE.DISCO]);
        gymPanel.GetComponent<LeisureDisplayController>().SetData(ls.LeisureVenues[(int)Leisure.PLACE.GYM]);
        parkLanePanel.GetComponent<LeisureDisplayController>().SetData(ls.LeisureVenues[(int)Leisure.PLACE.PARK]);
        cinemaPanel.GetComponent<LeisureDisplayController>().SetData(ls.LeisureVenues[(int)Leisure.PLACE.CINEMA]);

    }
}
