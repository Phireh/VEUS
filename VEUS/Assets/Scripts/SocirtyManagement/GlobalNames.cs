using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalNames
{
    public static string[] transport;
    public static string[] cityPart;
    public static string[] leisurePlaces;
    public static string[] jobs;

    static void Initiallize()
    {
        transport = new string[Enum.GetNames(typeof(Transport.TYPE)).Length];
        transport[(int)Transport.TYPE.ROAD] = "CARRETRA";
        transport[(int)Transport.TYPE.CYCLE_LANE] = "CARRIL BICI";
        transport[(int)Transport.TYPE.STREET] = "CALLE";
        transport[(int)Transport.TYPE.SUBWAY] = "METRO";

        cityPart = new string[Enum.GetNames(typeof(CityPart.PLACE)).Length];
        transport[(int)CityPart.PLACE.CENTER] = "CENTRAL";
        transport[(int)CityPart.PLACE.EAST] = "ESTE";
        transport[(int)CityPart.PLACE.NORTH] = "NORTE";
        transport[(int)CityPart.PLACE.WEST] = "OESTE";
        transport[(int)CityPart.PLACE.SOUTH] = "SUR";

        leisurePlaces = new string[Enum.GetNames(typeof(Leisure.PLACE)).Length];
        transport[(int)Leisure.PLACE.DISCO] = "DISCOTECA";
        transport[(int)Leisure.PLACE.CINEMA] = "CINE";
        transport[(int)Leisure.PLACE.PARK] = "PARQUE";
        transport[(int)Leisure.PLACE.GYM] = "GIMNASIO";

        jobs = new string[Enum.GetNames(typeof(Job.TYPE)).Length];
        transport[(int)Job.TYPE.POLICEMAN] = "POLICÍA";
        transport[(int)Job.TYPE.DOCTOR] = "MÉDICO";
        transport[(int)Job.TYPE.CLEANER] = "LIMPIADOR";
        transport[(int)Job.TYPE.SUBWAY_WORKER] = "TRABAJADOR DEL METRO";
        transport[(int)Job.TYPE.OFFICE_WORKER] = "OFICINISTA";
        transport[(int)Job.TYPE.EXECUTIVE_OFFICER] = "DIRECTOR EJECUTIVO";
    }
}
