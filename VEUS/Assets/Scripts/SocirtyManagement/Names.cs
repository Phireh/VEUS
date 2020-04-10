using System;
using System.Collections;
using System.Collections.Generic;

public static class Names
{
    public static string[] transport;
    public static string[] cityPart;
    public static string[] leisurePlaces;
    public static string[] jobs;

    static void Initiallize()
    {
        transport = new string[Enum.GetNames(typeof(Transport.TYPE)).Length];
        Names.transport[(int)Transport.TYPE.ROAD] = "CARRETRA";
        Names.transport[(int)Transport.TYPE.CYCLE_LANE] = "CARRIL BICI";
        Names.transport[(int)Transport.TYPE.STREET] = "CALLE";
        Names.transport[(int)Transport.TYPE.SUBWAY] = "METRO";

        cityPart = new string[Enum.GetNames(typeof(CityPart.PLACE)).Length];
        Names.transport[(int)CityPart.PLACE.CENTER] = "CENTRAL";
        Names.transport[(int)CityPart.PLACE.EAST] = "ESTE";
        Names.transport[(int)CityPart.PLACE.NORTH] = "NORTE";
        Names.transport[(int)CityPart.PLACE.WEST] = "OESTE";
        Names.transport[(int)CityPart.PLACE.SOUTH] = "SUR";

        leisurePlaces = new string[Enum.GetNames(typeof(Leisure.PLACE)).Length];
        Names.transport[(int)Leisure.PLACE.DISCO] = "DISCOTECA";
        Names.transport[(int)Leisure.PLACE.CINEMA] = "CINE";
        Names.transport[(int)Leisure.PLACE.PARK] = "PARQUE";
        Names.transport[(int)Leisure.PLACE.GYM] = "GIMNASIO";

        jobs = new string[Enum.GetNames(typeof(Job.TYPE)).Length];
        Names.transport[(int)Job.TYPE.POLICEMAN] = "POLICÍA";
        Names.transport[(int)Job.TYPE.DOCTOR] = "MÉDICO";
        Names.transport[(int)Job.TYPE.CLEANER] = "LIMPIADOR";
        Names.transport[(int)Job.TYPE.SUBWAY_WORKER] = "TRABAJADOR DEL METRO";
        Names.transport[(int)Job.TYPE.OFFICE_WORKER] = "OFICINISTA";
        Names.transport[(int)Job.TYPE.EXECUTIVE_OFFICER] = "DIRECTOR EJECUTIVO";


    }
}
