using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherIndexTest : MonoBehaviour
{
    WaysOfTransport w;

    Index inversionIndex;
    Index tecnologiaIndex;
    Index seguridadCarreteraIndex;
    Index contaminacionCarreteraIndex;
    Index velocidadCarreteraIndex;
    Index seguridadCarrilBiciIndex;
    Index contaminacionCarrilBiciIndex;
    Index velocidadCarrilBiciIndex;
    Index seguridadMetroIndex;
    Index contaminacionMetroIndex;
    Index velocidadMetroIndex;
    Index seguridadCalleIndex;
    Index contaminacionCalleIndex;
    Index velocidadCalleIndex;
    [Range(0.75f, 1f)] public float inversion;
    [Range(0.75f, 1f)] public float tecnologia;
    //[Range(0f, 1f)] public float carreteraSeguridad;
    public Index.STATE carreteraSeguridadState;
    //[Range(0f, 1f)] public float carreteraContaminacion;
    public Index.STATE carreteraContaminacionState;
    //public float carreteraVelocidad;
    //public Index.STATE carreteraVelocidadState;
    //[Range(0f, 1f)] public float carrilBiciSeguridad;
    public Index.STATE carrilBiciSeguridadState;
    //[Range(0f, 1f)] public float carrilBiciContaminacion;
    public Index.STATE carrilBiciContaminacionState;
    //public float carrilBiciVelocidad;
    //public Index.STATE carrilBiciVelocidadState;
    //[Range(0f, 1f)] public float metroSeguridad;
    public Index.STATE metroSeguridadState;
    //[Range(0f, 1f)] public float metroContaminacion;
    public Index.STATE metroContaminacionState;
    //public float metroVelocidad;
    //public Index.STATE metroVelocidadState;
    //[Range(0f, 1f)] public float calleSeguridad;
    public Index.STATE calleSeguridadState;
    //[Range(0f, 1f)] public float calleContaminacion;
    public Index.STATE calleContaminacionState;
    //public float calleVelocidad;
    //public Index.STATE calleVelocidadState;


    // Start is called before the first frame update
    void Start()
    {
        w = new WaysOfTransport(inversion, tecnologia);
        Initialize();
        Debug.Log("Número total de índices: " + Index.indexesDict.Count);
        foreach(Index i in Index.indexesDict.Values)
        {
            Debug.Log("ID: " + i.ID + " MAME: " + i.Name + " DESCRIPTION: " + i.Description);
        }
    }

    void Initialize()
    {
        inversionIndex = w.Investment;
        tecnologiaIndex = w.Technology;
        seguridadCarreteraIndex = w.Road.Safety;
        contaminacionCarreteraIndex = w.Road.Polluting;
        velocidadCarreteraIndex = w.Road.SpeedIndex;
        seguridadCarrilBiciIndex = w.CycleLane.Safety;
        contaminacionCarrilBiciIndex = w.CycleLane.Polluting;
        velocidadCarrilBiciIndex = w.CycleLane.SpeedIndex;
        seguridadMetroIndex = w.Subway.Safety;
        contaminacionMetroIndex = w.Subway.Polluting;
        velocidadMetroIndex = w.Subway.SpeedIndex;
        seguridadCalleIndex = w.Street.Safety;
        contaminacionCalleIndex = w.Street.Polluting;
        velocidadCalleIndex = w.Street.SpeedIndex;
        //Debug.Log(Index.indexesDict[inversionIndex.ID].ID);
    }

    // Update is called once per frame
    void Update()
    {
        carreteraContaminacionState = contaminacionCarreteraIndex.GetIndexState();
        carreteraSeguridadState = seguridadCarreteraIndex.GetIndexState();
        //carreteraVelocidadState = velocidadCarreteraIndex.GetIndexState();
        calleContaminacionState = contaminacionCalleIndex.GetIndexState();
        calleSeguridadState = seguridadCalleIndex.GetIndexState();
        //calleVelocidadState = velocidadCalleIndex.GetIndexState();
        metroContaminacionState = contaminacionMetroIndex.GetIndexState();
        metroSeguridadState = seguridadMetroIndex.GetIndexState();
        //metroVelocidadState = velocidadMetroIndex.GetIndexState();
        carrilBiciContaminacionState = contaminacionCarrilBiciIndex.GetIndexState();
        carrilBiciSeguridadState = seguridadCarrilBiciIndex.GetIndexState();
        //carrilBiciVelocidadState = velocidadCarrilBiciIndex.GetIndexState();
        Initialize();
    }
}
