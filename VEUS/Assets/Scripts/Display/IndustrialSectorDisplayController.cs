using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialSectorDisplayController : MonoBehaviour
{
    public GameObject indexBarInvestment;
    public GameObject indexBarDevelopement;
        
    public GameObject policemanPanel;
    public GameObject doctorPanel;
    public GameObject cleanerPanel;
    public GameObject subwayWorkerPanel;
    public GameObject officeWorkerPanel;
    public GameObject executiveOfficerPanel;
    // Start is called before the first frame update
    public void SetData(IndustrySector isec)
    {
        indexBarInvestment.GetComponent<IndexBarController>().IndexID = isec.Investment.ID;
        indexBarDevelopement.GetComponent<IndexBarController>().IndexID = isec.Development.ID;

        policemanPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.POLICEMAN]);
        doctorPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.DOCTOR]);
        cleanerPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.CLEANER]);
        subwayWorkerPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.SUBWAY_WORKER]);
        officeWorkerPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.OFFICE_WORKER]);
        executiveOfficerPanel.GetComponent<JobDisplayController>().SetData(isec.Jobs[(int)Job.TYPE.EXECUTIVE_OFFICER]);

    }
}
