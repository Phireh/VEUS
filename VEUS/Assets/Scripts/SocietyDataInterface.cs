using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SocietyDataInterface
{
    static City City
    {
        get { return SocietyManagement.CityOfToday; }
        set { return; }
    }

    ///////////////////////
    // Transport Getters //
    ///////////////////////
    public static int GetTransportCapacity(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Capacity;
    public static float GetTransportBaseSpeed(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].GetBaseSpeed();
    public static float GetTransportSpeed(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Speed;
    public static Transport.EXPANSION GetTransportExpansions(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].GetExpansionState();
    public static Transport.ENHANCEMENTS GetTransportEnhancements(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].GetEnhancements();
    public static float GetTransportSpeedIndexValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].SpeedIndex.Value;
    public static Index.STATE GetTransportSpeedIndexState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].SpeedIndex.GetIndexState();
    public static float GetTransportWearValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Wear.Value;
    public static Index.STATE GetTransportWearState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Wear.GetIndexState();
    public static float GetTransportPollutingValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Polluting.Value;
    public static Index.STATE GetTransportPollutingState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Polluting.GetIndexState();

    public static float GetTransportSectorInvestmentValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Investment.Value;
    public static Index.STATE GetTransportSectorInvestmentState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Investment.GetIndexState();
    public static float GetTransportSectorTechnologyValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Technology.Value;
    public static Index.STATE GetTransportSectorTechnologyState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.Technology.GetIndexState();
    public static int GetTransportSectorFreeSpaces(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].TransportSector.GetFreeSpaces(transportType);


    //////////////////////
    // Industry Getters //
    //////////////////////

    public static int GetIndustryTotalOffersAmount(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].Quantity;
    public static int GetIndustrySalary(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].Salary;
    public static int GetIndustryContractsDurationDays(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].ContractedDays;
    public static int GetIndustryScheduledStart(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].Schedule.Start;
    public static int GetIndustryScheduledWorkingHours(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].Schedule.RequieredTime;
    public static Job.DURATION GetIndustryContractsDurationState(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].GetDuration();
    public static Job.EXTENSION GetIndustryExtensionState(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].GetExtension();
    public static Job.TIME_DEMAND GetIndustryTimeDemandState(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].GetTimeDemand();
    public static float GetIndustryRequiredEffortValue(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].RequieredEffort.Value;
    public static Index.STATE GetIndustryRequiredEffortState(CityPart.PLACE cityPlace, Job.TYPE industryType)
        => City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].RequieredEffort.GetIndexState();


    public static float GetIndustrySectorInvestmentValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].IndustrySector.Investment.Value;
    public static Index.STATE GetIndustrySectorInvestmentState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].IndustrySector.Investment.GetIndexState();
    public static float GetIndustrySectorDevelopmentValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].IndustrySector.Development.Value;
    public static Index.STATE GetIndustrySectorDevelopmentState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].IndustrySector.Development.GetIndexState();

    /////////////////////
    // Leisure Getters //
    /////////////////////

    public static int GetLeisureCost(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Cost;
    public static int GetLeisureScheduledOpening(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Schedule.Opening;
    public static int GetLeisureScheduledClosing(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Schedule.Closing;
    public static int GetLeisureRequiredTime(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Schedule.RequieredTime;
    public static Leisure.AVAILABILITY GetLeisureAvailabilityState(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].GetAvailability();
    public static float GetLeisureSatisfactionValue(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Satisfaction.Value;
    public static Index.STATE GetLeisureSatisfactionIndex(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace)
        => City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Satisfaction.GetIndexState();


    public static float GetLeisureSectorInvestmentValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].LeisureSector.Investment.Value;
    public static Index.STATE GetLeisureSectorInvestmentState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].LeisureSector.Investment.GetIndexState();
    public static float GetLeisureSectorFunValue(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].LeisureSector.Fun.Value;
    public static Index.STATE GetLeisureSectorFunState(CityPart.PLACE cityPlace, Transport.TYPE transportType)
        => City.CityParts[(int)cityPlace].LeisureSector.Fun.GetIndexState();


    ///////////////////////
    // City Part Getters //
    ///////////////////////

    public static Index.STATE GetCitizensHappinessState(CityPart.PLACE cityPlace)
        => City.CityParts[(int)cityPlace].GlobalHappiness.GetIndexState();

    public static Index.STATE GetCitizensHealthState(CityPart.PLACE cityPlace)
        => City.CityParts[(int)cityPlace].GlobalHealth.GetIndexState();

    public static int GetCitizensCount(CityPart.PLACE cityPlace)
        => City.CityParts[(int)cityPlace].CitizensCount;

    public static int GetCitizensEconomicClassCount(CityPart.PLACE cityPlace, Citizen.ECONOMIC_CLASS ec)
        => City.CityParts[(int)cityPlace].CountClassCitizens(ec);

    public static Index.STATE GetCitizensEconomicClassProportionState(CityPart.PLACE cityPlace, Citizen.ECONOMIC_CLASS ec)
    {
        switch (ec)
        {
            case Citizen.ECONOMIC_CLASS.LOW: return City.CityParts[(int)cityPlace].LowClassProportion.GetIndexState();
            case Citizen.ECONOMIC_CLASS.MIDDLE: return City.CityParts[(int)cityPlace].MiddleClassProportion.GetIndexState(); ;
            case Citizen.ECONOMIC_CLASS.HIGH: default:  return City.CityParts[(int)cityPlace].HighClassProportion.GetIndexState(); ;
        }
    }

    public static int GetCitizensEnviomentalCommitmentCount(CityPart.PLACE cityPlace, Citizen.ENVIROMENTAL_COMMITMENT ec)
        => City.CityParts[(int)cityPlace].CountEnviromentalCommitmentCitizens(ec);

    public static int GetCitizensNatureCount(CityPart.PLACE cityPlace, Citizen.NATURE n)
        => City.CityParts[(int)cityPlace].CountNatureCitizens(n);

    public static int GetCitizensTimeManagementCount(CityPart.PLACE cityPlace, Citizen.TIME_MANAGEMENT tm)
        => City.CityParts[(int)cityPlace].CountTimeManagementCitizens(tm);

    public static int GetCitizensMoneyManagementCount(CityPart.PLACE cityPlace, Citizen.MONEY_MANAGEMENT mm)
        => City.CityParts[(int)cityPlace].CountMoneyManagementCitizens(mm);

    public static Index.STATE GetCityPartPollutionState(CityPart.PLACE cityPlace)
        => City.CityParts[(int)cityPlace].TransportSector.SectorPollution.GetIndexState();


    ////////////////////
    // Global Getters //
    ////////////////////

    public static Index.STATE GetGlobalPollutionState()
    {
        float polVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            polVal += cp.TransportSector.SectorPollution.Value;
        return new RepresentativeIndex("", "", polVal / 5).GetIndexState();
    }

    public static float GetGlobalPollutionValue()
    {
        float polVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            polVal += cp.TransportSector.SectorPollution.Value;
        return polVal / 5;
    }

    public static Index.STATE GetGlobalHappinessState()
    {
        float hapVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            hapVal += cp.GlobalHappiness.Value;
        return new RepresentativeIndex("", "", hapVal / 5).GetIndexState();
    }

    public static float GetGlobalHappinessValue()
    {
        float hapVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            hapVal += cp.GlobalHappiness.Value;
        return hapVal / 5;
    }

    public static Index.STATE GetGlobalHealthState()
    {
        float helVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            helVal += cp.GlobalHealth.Value;
        return new RepresentativeIndex("", "", helVal / 5).GetIndexState();
    }

    public static float GetGlobalHealthValue()
    {
        float helVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            helVal += cp.GlobalHealth.Value;
        return helVal / 5;
    }

    public static Index.STATE GetGlobalSectorDevelopementState(CityPart.SECTOR_TYPE st)
    {
        float devlVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            switch (st)
            {
                case CityPart.SECTOR_TYPE.INDUSTRY: devlVal += cp.IndustrySector.Investment.Value + cp.IndustrySector.Development.Value; break;
                case CityPart.SECTOR_TYPE.LEISURE: devlVal += cp.IndustrySector.Investment.Value + cp.LeisureSector.Fun.Value; break;
                case CityPart.SECTOR_TYPE.TRANSPORT: devlVal += cp.IndustrySector.Investment.Value + cp.TransportSector.Technology.Value; break;
            }
        return new RepresentativeIndex("", "", devlVal / 6).GetIndexState();
    }

    public static float GetGlobalSectorDevelopementValue(CityPart.SECTOR_TYPE st)
    {
        float devlVal = 0f;
        foreach (CityPart cp in SocietyManagement.CityOfToday.CityParts)
            switch (st)
            {
                case CityPart.SECTOR_TYPE.INDUSTRY: devlVal += cp.IndustrySector.Investment.Value + cp.IndustrySector.Development.Value; break;
                case CityPart.SECTOR_TYPE.LEISURE: devlVal += cp.IndustrySector.Investment.Value + cp.LeisureSector.Fun.Value; break;
                case CityPart.SECTOR_TYPE.TRANSPORT: devlVal += cp.IndustrySector.Investment.Value + cp.TransportSector.Technology.Value; break;
            }
        return devlVal / 6;
    }

    public static Index.STATE GetAlcaldoLoceState()
    {
        float lovaVal = (GetGlobalHappinessValue() + GetGlobalHealthValue()) / 2;
        return new RepresentativeIndex("", "", lovaVal).GetIndexState();
    }

    public static float GetAlcaldoLoceValue()
    {
        float lovaVal = (GetGlobalHappinessValue() + GetGlobalHealthValue()) / 2;
        return lovaVal;
    }

    ///////////////////////
    // Transport Changes //
    ///////////////////////

    public static void AddTransportExpansionsChange(CityPart.PLACE cityPlace, Transport.TYPE transportType, Transport.EXPANSION newValue)
        => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].SetExpansionState, newValue);
    public static void AddTransportEnhancementsChange(CityPart.PLACE cityPlace, Transport.TYPE transportType, Transport.ENHANCEMENTS newValue)
        => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].SetEnhancements, newValue);

    public static void AddTransportWearIndexChange(CityPart.PLACE cityPlace, Transport.TYPE transportType, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Wear, change);
    public static void AddTransportSpeedIndexChange(CityPart.PLACE cityPlace, Transport.TYPE transportType, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].SpeedIndex, change);
    public static void AddTransportPollutingIndexChange(CityPart.PLACE cityPlace, Transport.TYPE transportType, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].TransportSector.Transports[(int)transportType].Polluting, change);


    public static void AddTransportSectorInvestmentIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].TransportSector.Investment, change);
    public static void AddTransportSectorTechnologyIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].TransportSector.Technology, change);


    //////////////////////
    // Industry Changes //
    //////////////////////

    public static void AddIndustryContractsDurationChange(CityPart.PLACE cityPlace, Job.TYPE industryType, Job.DURATION newValue)
        => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].SetDuration, newValue);
    public static void AddIndustryExtensionChange(CityPart.PLACE cityPlace, Job.TYPE industryType, Job.EXTENSION newValue)
        => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].SetExtension, newValue);
    public static void AddIndustryTimeDemandChange(CityPart.PLACE cityPlace, Job.TYPE industryType, Job.TIME_DEMAND newValue)
        => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].SetTimeDemand, newValue);

    public static void AddIndustryRequiredEffortIndexChange(CityPart.PLACE cityPlace, Job.TYPE industryType, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].IndustrySector.Jobs[(int)industryType].RequieredEffort, change);

    public static void AddIndustrySectorInvestmentIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].IndustrySector.Investment, change);
    public static void AddIndustrySectorDevelopementIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].IndustrySector.Development, change);

    /////////////////////
    // Leisure Changes //
    /////////////////////

    public static void AddLeisureAvailabilityStateChange(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace, Leisure.AVAILABILITY newValue)
       => City.Changes.AddValueChange(City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].SetAvailability, newValue);

    public static void AddLeisureSatisfactionIndexChange(CityPart.PLACE cityPlace, Leisure.PLACE leisurePlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].LeisureSector.LeisureVenues[(int)leisurePlace].Satisfaction, change);

    public static void AddLeisureSectorInvestmentIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].LeisureSector.Investment, change);
    public static void AddLeisureSectorFunIndexChange(CityPart.PLACE cityPlace, Index.CHANGE change)
        => City.Changes.AddIndexChange(City.CityParts[(int)cityPlace].LeisureSector.Fun, change);
}