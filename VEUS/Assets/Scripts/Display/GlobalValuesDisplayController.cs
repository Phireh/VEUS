using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValuesDisplayController : MonoBehaviour
{
    public GameObject globalHappiness;
    public GameObject globalHealth;
    public GameObject globalPollution;
    public GameObject globalAlcaldoLove;

    public void SetData()
    {
        globalHappiness.GetComponent<IndexBarController>().IndexID = new RepresentativeIndex("Felicidad Global", "Felicidad global de la sociedad", SocietyDataInterface.GetGlobalHappinessValue()).ID;
        globalHealth.GetComponent<IndexBarController>().IndexID = new RepresentativeIndex("Salud Global", "Salud global de la sociedad", SocietyDataInterface.GetGlobalHappinessValue()).ID;
        globalPollution.GetComponent<IndexBarController>().IndexID = new RepresentativeIndex("Contaminación Global", "Contaminación global de la sociedad", SocietyDataInterface.GetGlobalHappinessValue()).ID;
        globalAlcaldoLove.GetComponent<IndexBarController>().IndexID = new RepresentativeIndex("Amor Global", "Amor global al alcaldo en la sociedad", SocietyDataInterface.GetGlobalHappinessValue()).ID;
    }
}
