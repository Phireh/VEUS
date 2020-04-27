using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CitizenDisplayController : MonoBehaviour
{
    CityPart displayedCityPart;

    public TextMeshProUGUI totalCitizens;

    public TextMeshProUGUI lowClass;
    public TextMeshProUGUI middleClass;
    public TextMeshProUGUI highClass;

    public TextMeshProUGUI noneEnviromentalCommitment;
    public TextMeshProUGUI someEnviromentalCommitment;
    public TextMeshProUGUI fullEnviromentalCommitment;

    public TextMeshProUGUI activeNature;
    public TextMeshProUGUI calmNature;
    public TextMeshProUGUI socialNature;
    public TextMeshProUGUI dreamerNature;

    public TextMeshProUGUI calmedTimeManagement;
    public TextMeshProUGUI normalTimeManagement;
    public TextMeshProUGUI rushedTimeManagement;

    public TextMeshProUGUI stingyMoneyManagement;
    public TextMeshProUGUI responsibleMoneyManagement;
    public TextMeshProUGUI wastefulMoneyManagement;

    public GameObject globalHappiness;
    public GameObject globalhealth;
    public GameObject lowClassProportion;
    public GameObject middleClassProportion;
    public GameObject highClassProportion;

    public void SetData(CityPart cityPart)
    {
        displayedCityPart = cityPart;

        totalCitizens.text = SocietyDataInterface.GetCitizensCount(displayedCityPart.CityPlace).ToString();

        lowClass.text = SocietyDataInterface.GetCitizensEconomicClassCount(displayedCityPart.CityPlace, Citizen.ECONOMIC_CLASS.LOW).ToString();
        middleClass.text = SocietyDataInterface.GetCitizensEconomicClassCount(displayedCityPart.CityPlace, Citizen.ECONOMIC_CLASS.MIDDLE).ToString();
        highClass.text = SocietyDataInterface.GetCitizensEconomicClassCount(displayedCityPart.CityPlace, Citizen.ECONOMIC_CLASS.HIGH).ToString();

        noneEnviromentalCommitment.text = SocietyDataInterface.GetCitizensEnviomentalCommitmentCount(displayedCityPart.CityPlace, Citizen.ENVIROMENTAL_COMMITMENT.NONE).ToString();
        someEnviromentalCommitment.text = SocietyDataInterface.GetCitizensEnviomentalCommitmentCount(displayedCityPart.CityPlace, Citizen.ENVIROMENTAL_COMMITMENT.SOME).ToString();
        fullEnviromentalCommitment.text = SocietyDataInterface.GetCitizensEnviomentalCommitmentCount(displayedCityPart.CityPlace, Citizen.ENVIROMENTAL_COMMITMENT.FULL).ToString();

        activeNature.text = SocietyDataInterface.GetCitizensNatureCount(displayedCityPart.CityPlace, Citizen.NATURE.ACTIVE).ToString();
        calmNature.text = SocietyDataInterface.GetCitizensNatureCount(displayedCityPart.CityPlace, Citizen.NATURE.CALM).ToString();
        socialNature.text = SocietyDataInterface.GetCitizensNatureCount(displayedCityPart.CityPlace, Citizen.NATURE.SOCIAL).ToString();
        dreamerNature.text = SocietyDataInterface.GetCitizensNatureCount(displayedCityPart.CityPlace, Citizen.NATURE.DREAMER).ToString();

        calmedTimeManagement.text = SocietyDataInterface.GetCitizensTimeManagementCount(displayedCityPart.CityPlace, Citizen.TIME_MANAGEMENT.CALMED).ToString();
        normalTimeManagement.text = SocietyDataInterface.GetCitizensTimeManagementCount(displayedCityPart.CityPlace, Citizen.TIME_MANAGEMENT.NORMAL).ToString();
        rushedTimeManagement.text = SocietyDataInterface.GetCitizensTimeManagementCount(displayedCityPart.CityPlace, Citizen.TIME_MANAGEMENT.RUSHED).ToString();

        stingyMoneyManagement.text = SocietyDataInterface.GetCitizensMoneyManagementCount(displayedCityPart.CityPlace, Citizen.MONEY_MANAGEMENT.STINGY).ToString();
        responsibleMoneyManagement.text = SocietyDataInterface.GetCitizensMoneyManagementCount(displayedCityPart.CityPlace, Citizen.MONEY_MANAGEMENT.RESPONSIBLE).ToString();
        wastefulMoneyManagement.text = SocietyDataInterface.GetCitizensMoneyManagementCount(displayedCityPart.CityPlace, Citizen.MONEY_MANAGEMENT.WASTEFUL).ToString();

        globalhealth.GetComponent<IndexBarController>().IndexID = displayedCityPart.GlobalHealth.ID;
        globalHappiness.GetComponent<IndexBarController>().IndexID = displayedCityPart.GlobalHappiness.ID;
        lowClassProportion.GetComponent<IndexBarController>().IndexID = displayedCityPart.LowClassProportion.ID;
        middleClassProportion.GetComponent<IndexBarController>().IndexID = displayedCityPart.MiddleClassProportion.ID;
        highClassProportion.GetComponent<IndexBarController>().IndexID = displayedCityPart.HighClassProportion.ID;
    }
}
