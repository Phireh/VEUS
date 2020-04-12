using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues
{
    public static int[] transportCapacity;
    public static float[] transportSafety;
    public static float[] transportPollution;
    public static float[] transportMaxSpeed;

    static void InitiallizeTransports()
    {
        transportCapacity = new int[Enum.GetNames(typeof(Transport.TYPE)).Length];
        transportCapacity[(int)Transport.TYPE.ROAD] = 250;
        transportCapacity[(int)Transport.TYPE.CYCLE_LANE] = 100;
        transportCapacity[(int)Transport.TYPE.STREET] = 1000;
        transportCapacity[(int)Transport.TYPE.SUBWAY] = 75;

        transportSafety = new float[Enum.GetNames(typeof(Transport.TYPE)).Length];
        transportSafety[(int)Transport.TYPE.ROAD] = 0.6f;
        transportSafety[(int)Transport.TYPE.CYCLE_LANE] = 0.75f;
        transportSafety[(int)Transport.TYPE.STREET] = 1f;
        transportSafety[(int)Transport.TYPE.SUBWAY] = 0.9f;

        transportPollution = new float[Enum.GetNames(typeof(Transport.TYPE)).Length];
        transportPollution[(int)Transport.TYPE.ROAD] = 0.9f;
        transportPollution[(int)Transport.TYPE.CYCLE_LANE] = 0.2f;
        transportPollution[(int)Transport.TYPE.STREET] = 0.1f;
        transportPollution[(int)Transport.TYPE.SUBWAY] = 0.35f;

        transportMaxSpeed = new float[Enum.GetNames(typeof(Transport.TYPE)).Length];
        transportMaxSpeed[(int)Transport.TYPE.ROAD] = 20f;
        transportMaxSpeed[(int)Transport.TYPE.CYCLE_LANE] = 3f;
        transportMaxSpeed[(int)Transport.TYPE.STREET] = 1f;
        transportMaxSpeed[(int)Transport.TYPE.SUBWAY] = 10f;
    }
}
