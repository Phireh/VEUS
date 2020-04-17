using System;
using System.Collections;
using System.Collections.Generic;

public class City
{
    public CityPart[] CityParts { get; private set; }
    public ChangesManagement changes { get; private set; }

public City() {
        changes = new ChangesManagement();
        CityParts = new CityPart[Enum.GetNames(typeof(CityPart.PLACE)).Length];
        CityParts[(int)CityPart.PLACE.CENTER] = new CityPart(CityPart.PLACE.CENTER,
            CityPart.POPULATION.LARGE, Citizen.ECONOMIC_CLASS.MIDDLE,
            CityPart.INDUSTRY.DEVELOPING, CityPart.SECTOR_INVESTMENT.HIGH,
            CityPart.FUN.BORING, CityPart.SECTOR_INVESTMENT.LOW,
            CityPart.INFRASTRUCTURE.CUTTING_EDGE, CityPart.SECTOR_INVESTMENT.HIGH,
            this);

        CityParts[(int)CityPart.PLACE.NORTH] = new CityPart(CityPart.PLACE.NORTH,
            CityPart.POPULATION.SMALL, Citizen.ECONOMIC_CLASS.MIDDLE,
            CityPart.INDUSTRY.DEVELOPED, CityPart.SECTOR_INVESTMENT.MEDIUM,
            CityPart.FUN.BORING, CityPart.SECTOR_INVESTMENT.MEDIUM,
            CityPart.INFRASTRUCTURE.UP_TO_DATE, CityPart.SECTOR_INVESTMENT.MEDIUM,
            this);

        CityParts[(int)CityPart.PLACE.SOUTH] = new CityPart(CityPart.PLACE.SOUTH,
            CityPart.POPULATION.OVER_POPULATED, Citizen.ECONOMIC_CLASS.LOW,
            CityPart.INDUSTRY.UNDER_DEVELOPED, CityPart.SECTOR_INVESTMENT.MEDIUM,
            CityPart.FUN.ENTERTAINING, CityPart.SECTOR_INVESTMENT.MEDIUM,
            CityPart.INFRASTRUCTURE.OLD_FASHINED, CityPart.SECTOR_INVESTMENT.LOW,
            this);

        CityParts[(int)CityPart.PLACE.WEST] = new CityPart(CityPart.PLACE.WEST,
            CityPart.POPULATION.UNDER_POPULATED, Citizen.ECONOMIC_CLASS.HIGH,
            CityPart.INDUSTRY.DEVELOPED, CityPart.SECTOR_INVESTMENT.HIGH,
            CityPart.FUN.ENJOYABLE, CityPart.SECTOR_INVESTMENT.HIGH,
            CityPart.INFRASTRUCTURE.UP_TO_DATE, CityPart.SECTOR_INVESTMENT.HIGH,
            this);

        CityParts[(int)CityPart.PLACE.EAST] = new CityPart(CityPart.PLACE.EAST,
            CityPart.POPULATION.MEDIA, Citizen.ECONOMIC_CLASS.MIDDLE,
            CityPart.INDUSTRY.DEVELOPING, CityPart.SECTOR_INVESTMENT.MEDIUM,
            CityPart.FUN.ENTERTAINING, CityPart.SECTOR_INVESTMENT.HIGH,
            CityPart.INFRASTRUCTURE.UP_TO_DATE, CityPart.SECTOR_INVESTMENT.MEDIUM,
            this);
    }


    public override string ToString()
    {
        string res = "";
        foreach (CityPart c in CityParts)
        {
            res += c.ToString();
        }
        return res;
    }

    public void DebugPrint()
    {
        foreach (CityPart c in CityParts)
            Global.Methods.PrintInfo(c.ToString());
    }
}
