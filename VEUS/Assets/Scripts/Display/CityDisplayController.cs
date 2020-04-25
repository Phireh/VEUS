using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDisplayController : MonoBehaviour
{
    Camera mycam;
    [Range(1, 50)] public float cameraSesitivity;
    float standardSize = 500f;
    float currentSize;

    public City CitytoRepresent { get; private set; }      

    public GameObject centerPanel;
    public GameObject northPanel;
    public GameObject eastPanel;
    public GameObject westPanel;
    public GameObject southPanel;
    // Start is called before the first frame update
    void Start()
    {
        currentSize = standardSize;
        mycam = GetComponent<Camera>();
        //////////////////////////////////////
        SocietyManagement.Init();
        CitytoRepresent = SocietyManagement.CityOfToday;
        StartCoroutine(DelayedInit());
    }

    IEnumerator DelayedInit()
    {
        Debug.Log("Wait a second please");
        yield return new WaitForSeconds(1f);
        centerPanel.GetComponent<CityPartDisplayController>().SetData(CitytoRepresent.CityParts[(int)CityPart.PLACE.CENTER]);
        northPanel.GetComponent<CityPartDisplayController>().SetData(CitytoRepresent.CityParts[(int)CityPart.PLACE.NORTH]);
        eastPanel.GetComponent<CityPartDisplayController>().SetData(CitytoRepresent.CityParts[(int)CityPart.PLACE.EAST]);
        westPanel.GetComponent<CityPartDisplayController>().SetData(CitytoRepresent.CityParts[(int)CityPart.PLACE.WEST]);
        southPanel.GetComponent<CityPartDisplayController>().SetData(CitytoRepresent.CityParts[(int)CityPart.PLACE.SOUTH]);
        Debug.Log("Displaying current city data");
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector3 vp = mycam.transform.position;
        if (Input.GetKey(KeyCode.M)) currentSize += 50f;
        if (Input.GetKey(KeyCode.N)) currentSize -= 50f;
        if (currentSize < 100f) currentSize = 100f;
        if (currentSize > 5000f) currentSize = 5000f;
        vp += new Vector3(Input.GetAxis("Horizontal") * standardSize / currentSize * cameraSesitivity,
            Input.GetAxis("Vertical") * standardSize / currentSize * cameraSesitivity);
        mycam.transform.position = new Vector3(vp.x, vp.y, -10);
        mycam.orthographicSize = currentSize;




        if (Input.GetKeyDown(KeyCode.R))
        {
            SocietyManagement.ProcessDay();
            Debug.Log("Wait a second please");
            StartCoroutine(DelayedInit());
        }
    }
}
