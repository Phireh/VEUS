using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
    public static class Values
    {
        public static int[,] transportCapacity;         // The sum of the max values has to be 1024 
        public static float[] transportSafety;
        public static float[] transportPollution;
        public static float[,] transportMaxSpeed;

        public static int[] leisureOpening;
        public static int[,] leisureOpenedTime;
        public static int[] leisureCost;
        public static float[] leisureSatisfaction;
        public static int[] leisureTime;

        public static int[,] jobsQuantity;              // The sum of the max values has to be 1024 
        public static int[] jobsSalary;
        public static int[] jobsStart;
        public static int[,] jobsWorkingHours;
        public static float[,] jobsRequieredEffort;
        public static int[,] jobsContractedDays;

        public static float[] citizenEnviromentalTransportPreferences;
        public static int[] citizenTransportTimePreferences;

        public static float matchingNatureBonues;
        public static int failingToWorkPenalty;
        public static float restingHourBonus;
        public static int minContiniousHoursToRest;

        public static void InitiallizeTransports()
        {
            transportCapacity = new int[Enum.GetNames(typeof(Transport.EXPANSION)).Length, Enum.GetNames(typeof(Transport.TYPE)).Length];
            transportCapacity[(int)Transport.EXPANSION.NONE, (int)Transport.TYPE.ROAD] = 150;
            transportCapacity[(int)Transport.EXPANSION.NONE, (int)Transport.TYPE.CYCLE_LANE] = 50;
            transportCapacity[(int)Transport.EXPANSION.NONE, (int)Transport.TYPE.STREET] = 200;
            transportCapacity[(int)Transport.EXPANSION.NONE, (int)Transport.TYPE.SUBWAY] = 100;

            transportCapacity[(int)Transport.EXPANSION.SMALL, (int)Transport.TYPE.ROAD] = 225;
            transportCapacity[(int)Transport.EXPANSION.SMALL, (int)Transport.TYPE.CYCLE_LANE] = 75;
            transportCapacity[(int)Transport.EXPANSION.SMALL, (int)Transport.TYPE.STREET] = 300;
            transportCapacity[(int)Transport.EXPANSION.SMALL, (int)Transport.TYPE.SUBWAY] = 150;

            transportCapacity[(int)Transport.EXPANSION.LARGE, (int)Transport.TYPE.ROAD] = 300;
            transportCapacity[(int)Transport.EXPANSION.LARGE, (int)Transport.TYPE.CYCLE_LANE] = 100;
            transportCapacity[(int)Transport.EXPANSION.LARGE, (int)Transport.TYPE.STREET] = 400;
            transportCapacity[(int)Transport.EXPANSION.LARGE, (int)Transport.TYPE.SUBWAY] = 224;


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

            transportMaxSpeed = new float[Enum.GetNames(typeof(Transport.ENHANCEMENTS)).Length, Enum.GetNames(typeof(Transport.TYPE)).Length];
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.NONE, (int)Transport.TYPE.ROAD] = 16f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.NONE, (int)Transport.TYPE.CYCLE_LANE] = 2f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.NONE, (int)Transport.TYPE.STREET] = 1f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.NONE, (int)Transport.TYPE.SUBWAY] = 8f;

            transportMaxSpeed[(int)Transport.ENHANCEMENTS.FEW, (int)Transport.TYPE.ROAD] = 24f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.FEW, (int)Transport.TYPE.CYCLE_LANE] = 4f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.FEW, (int)Transport.TYPE.STREET] = 2f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.FEW, (int)Transport.TYPE.SUBWAY] = 12f;

            transportMaxSpeed[(int)Transport.ENHANCEMENTS.MANY, (int)Transport.TYPE.ROAD] = 32f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.MANY, (int)Transport.TYPE.CYCLE_LANE] = 8f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.MANY, (int)Transport.TYPE.STREET] = 4f;
            transportMaxSpeed[(int)Transport.ENHANCEMENTS.MANY, (int)Transport.TYPE.SUBWAY] = 16f;
        }

        public static void InitiallizeLeisures()
        {
            leisureOpening = new int[Enum.GetNames(typeof(Leisure.PLACE)).Length];
            leisureOpening[(int)Leisure.PLACE.DISCO] = 23;
            leisureOpening[(int)Leisure.PLACE.PARK] = 6;
            leisureOpening[(int)Leisure.PLACE.GYM] = 10;
            leisureOpening[(int)Leisure.PLACE.CINEMA] = 16;

            leisureOpenedTime = new int[Enum.GetNames(typeof(Leisure.AVAILABILITY)).Length, Enum.GetNames(typeof(Leisure.PLACE)).Length];
            leisureOpenedTime[(int)Leisure.AVAILABILITY.LIMITED, (int)Leisure.PLACE.DISCO] = 3;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.LIMITED, (int)Leisure.PLACE.PARK] = 8;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.LIMITED, (int)Leisure.PLACE.GYM] = 5;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.LIMITED, (int)Leisure.PLACE.CINEMA] = 4;

            leisureOpenedTime[(int)Leisure.AVAILABILITY.NORMAL, (int)Leisure.PLACE.DISCO] = 5;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.NORMAL, (int)Leisure.PLACE.PARK] = 12;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.NORMAL, (int)Leisure.PLACE.GYM] = 7;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.NORMAL, (int)Leisure.PLACE.CINEMA] = 6;

            leisureOpenedTime[(int)Leisure.AVAILABILITY.EXTENDED, (int)Leisure.PLACE.DISCO] = 7;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.EXTENDED, (int)Leisure.PLACE.PARK] = 16;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.EXTENDED, (int)Leisure.PLACE.GYM] = 10;
            leisureOpenedTime[(int)Leisure.AVAILABILITY.EXTENDED, (int)Leisure.PLACE.CINEMA] = 8;


            leisureCost = new int[Enum.GetNames(typeof(Leisure.PLACE)).Length];
            leisureCost[(int)Leisure.PLACE.DISCO] = 20;
            leisureCost[(int)Leisure.PLACE.PARK] = 1;
            leisureCost[(int)Leisure.PLACE.GYM] = 12;
            leisureCost[(int)Leisure.PLACE.CINEMA] = 15;

            leisureSatisfaction = new float[Enum.GetNames(typeof(Leisure.PLACE)).Length];
            leisureSatisfaction[(int)Leisure.PLACE.DISCO] = 0.75f;
            leisureSatisfaction[(int)Leisure.PLACE.PARK] = 0.3f;
            leisureSatisfaction[(int)Leisure.PLACE.GYM] = 0.5f;
            leisureSatisfaction[(int)Leisure.PLACE.CINEMA] = 0.5f;

            leisureTime = new int[Enum.GetNames(typeof(Leisure.PLACE)).Length];
            leisureTime[(int)Leisure.PLACE.DISCO] = 4;
            leisureTime[(int)Leisure.PLACE.PARK] = 1;
            leisureTime[(int)Leisure.PLACE.GYM] = 2;
            leisureTime[(int)Leisure.PLACE.CINEMA] = 3;
        }

        public static void InitiallizeJobs()
        {
            jobsQuantity = new int[Enum.GetNames(typeof(Job.EXTENSION)).Length, Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.POLICEMAN] = 100;
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.DOCTOR] = 50;
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.CLEANER] = 35;
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.SUBWAY_WORKER] = 25;
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.OFFICE_WORKER] = 250;
            jobsQuantity[(int)Job.EXTENSION.LIMITED, (int)Job.TYPE.EXECUTIVE_OFFICER] = 5;

            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.POLICEMAN] = 150;
            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.DOCTOR] = 70;
            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.CLEANER] = 30;
            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.SUBWAY_WORKER] = 40;
            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.OFFICE_WORKER] = 500;
            jobsQuantity[(int)Job.EXTENSION.NORMAL, (int)Job.TYPE.EXECUTIVE_OFFICER] = 10;

            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.POLICEMAN] = 200;
            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.DOCTOR] = 100;
            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.CLEANER] = 50;
            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.SUBWAY_WORKER] = 65;
            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.OFFICE_WORKER] = 595;
            jobsQuantity[(int)Job.EXTENSION.EXTENDED, (int)Job.TYPE.EXECUTIVE_OFFICER] = 14;


            jobsSalary = new int[Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsSalary[(int)Job.TYPE.POLICEMAN] = 35;
            jobsSalary[(int)Job.TYPE.DOCTOR] = 45;
            jobsSalary[(int)Job.TYPE.CLEANER] = 20;
            jobsSalary[(int)Job.TYPE.SUBWAY_WORKER] = 25;
            jobsSalary[(int)Job.TYPE.OFFICE_WORKER] = 30;
            jobsSalary[(int)Job.TYPE.EXECUTIVE_OFFICER] = 150;


            jobsStart = new int[Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsStart[(int)Job.TYPE.POLICEMAN] = 8;
            jobsStart[(int)Job.TYPE.DOCTOR] = 8;
            jobsStart[(int)Job.TYPE.CLEANER] = 7;
            jobsStart[(int)Job.TYPE.SUBWAY_WORKER] = 5;
            jobsStart[(int)Job.TYPE.OFFICE_WORKER] = 9;
            jobsStart[(int)Job.TYPE.EXECUTIVE_OFFICER] = 8;


            jobsWorkingHours = new int[Enum.GetNames(typeof(Job.TIME_DEMAND)).Length, Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.POLICEMAN] = 5;
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.DOCTOR] = 6;
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.CLEANER] = 4;
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.SUBWAY_WORKER] = 5;
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.OFFICE_WORKER] = 5;
            jobsWorkingHours[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.EXECUTIVE_OFFICER] = 5;

            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.POLICEMAN] = 10;
            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.DOCTOR] = 12;
            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.CLEANER] = 8;
            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.SUBWAY_WORKER] = 11;
            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.OFFICE_WORKER] = 9;
            jobsWorkingHours[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.EXECUTIVE_OFFICER] = 10;

            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.POLICEMAN] = 14;
            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.DOCTOR] = 16;
            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.CLEANER] = 12;
            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.SUBWAY_WORKER] = 15;
            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.OFFICE_WORKER] = 13;
            jobsWorkingHours[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.EXECUTIVE_OFFICER] = 14;


            jobsRequieredEffort = new float[Enum.GetNames(typeof(Job.TIME_DEMAND)).Length, Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.POLICEMAN] = 0.35f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.DOCTOR] = 0.45f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.CLEANER] = 0.35f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.SUBWAY_WORKER] = 0.3f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.OFFICE_WORKER] = 0.3f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.PART_TIME, (int)Job.TYPE.EXECUTIVE_OFFICER] = 0.3f;

            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.POLICEMAN] = 0.7f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.DOCTOR] = 0.85f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.CLEANER] = 0.65f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.SUBWAY_WORKER] = 0.55f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.OFFICE_WORKER] = 0.6f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.FULL_TIME, (int)Job.TYPE.EXECUTIVE_OFFICER] = 0.6f;

            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.POLICEMAN] = 0.9f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.DOCTOR] = 1f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.CLEANER] = 0.75f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.SUBWAY_WORKER] = 0.65f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.OFFICE_WORKER] = 0.8f;
            jobsRequieredEffort[(int)Job.TIME_DEMAND.EXTRA_HOURS, (int)Job.TYPE.EXECUTIVE_OFFICER] = 0.8f;


            jobsContractedDays = new int[Enum.GetNames(typeof(Job.DURATION)).Length, Enum.GetNames(typeof(Job.TYPE)).Length];
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.POLICEMAN] = 15;
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.DOCTOR] = 10;
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.CLEANER] = 3;
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.SUBWAY_WORKER] = 9;
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.OFFICE_WORKER] = 11;
            jobsContractedDays[(int)Job.DURATION.TEMPORARY, (int)Job.TYPE.EXECUTIVE_OFFICER] = 25;

            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.POLICEMAN] = 20;
            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.DOCTOR] = 15;
            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.CLEANER] = 7;
            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.SUBWAY_WORKER] = 15;
            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.OFFICE_WORKER] = 15;
            jobsContractedDays[(int)Job.DURATION.STANDARD, (int)Job.TYPE.EXECUTIVE_OFFICER] = 35;

            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.POLICEMAN] = 25;
            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.DOCTOR] = 20;
            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.CLEANER] = 10;
            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.SUBWAY_WORKER] = 17;
            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.OFFICE_WORKER] = 19;
            jobsContractedDays[(int)Job.DURATION.LONG_TERM, (int)Job.TYPE.EXECUTIVE_OFFICER] = 50;
        }

        public static void InitiallizeCitizens()
        {
            citizenEnviromentalTransportPreferences = new float[Enum.GetNames(typeof(Citizen.ENVIROMENTAL_COMMITMENT)).Length];
            citizenEnviromentalTransportPreferences[(int)Citizen.ENVIROMENTAL_COMMITMENT.NONE] = 0.15f;
            citizenEnviromentalTransportPreferences[(int)Citizen.ENVIROMENTAL_COMMITMENT.SOME] = 0.4f;
            citizenEnviromentalTransportPreferences[(int)Citizen.ENVIROMENTAL_COMMITMENT.FULL] = 0.75f;

            citizenTransportTimePreferences = new int[Enum.GetNames(typeof(Citizen.TIME_MANAGEMENT)).Length];
            citizenTransportTimePreferences[(int)Citizen.TIME_MANAGEMENT.CALMED] = 7;
            citizenTransportTimePreferences[(int)Citizen.TIME_MANAGEMENT.NORMAL] = 5;
            citizenTransportTimePreferences[(int)Citizen.TIME_MANAGEMENT.RUSHED] = 3;

            matchingNatureBonues = 0.2f;
            failingToWorkPenalty = 50;
            restingHourBonus = 0.075f;
            minContiniousHoursToRest = 3;
    }
    }
    
    public class Methods : MonoBehaviour
    {
        public static float GetRandomPercentage(int l, int h)
        {
            if (l < 0) l = 0;
            else if (l > 100)
            {
                l = 100;
                h = 100;
            }
            if (h > 100) h = 100;
            else if (h < l) h = l;
            return UnityEngine.Random.Range(l, h + 1) / 100f;
        }
        public static float GetRandomPercentage() => GetRandomPercentage(0, 100);
        public static int GetRandom(int l, int h) => UnityEngine.Random.Range(l, h);
        public static int GetRandom(int h) => UnityEngine.Random.Range(0, h);

        public static void PrintError(string error)
        {
            Debug.LogError(error);
        }
    }

    public static class Names
    {
        public static string[] transport;
        public static string[] cityPart;
        public static string[] leisurePlaces;
        public static string[] jobs;

        static void Initiallize()
        {
            transport = new string[Enum.GetNames(typeof(Transport.TYPE)).Length];
            transport[(int)Transport.TYPE.NONE] = "NINGUNO";
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
            transport[(int)Leisure.PLACE.NONE] = "NINGÚN LADO";
            transport[(int)Leisure.PLACE.DISCO] = "DISCOTECA";
            transport[(int)Leisure.PLACE.CINEMA] = "CINE";
            transport[(int)Leisure.PLACE.PARK] = "PARQUE";
            transport[(int)Leisure.PLACE.GYM] = "GIMNASIO";

            leisurePlaces = new string[Enum.GetNames(typeof(Leisure.TYPE)).Length];
            transport[(int)Leisure.TYPE.PARTY] = "FIESTA";
            transport[(int)Leisure.TYPE.SHOW] = "ESPECTÁCULO";
            transport[(int)Leisure.TYPE.CALM] = "CALMADO";
            transport[(int)Leisure.TYPE.SPORT] = "DEPOrtE";

            jobs = new string[Enum.GetNames(typeof(Job.TYPE)).Length];
            transport[(int)Job.TYPE.NONE] = "NULO";
            transport[(int)Job.TYPE.POLICEMAN] = "POLICÍA";
            transport[(int)Job.TYPE.DOCTOR] = "MÉDICO";
            transport[(int)Job.TYPE.CLEANER] = "LIMPIADOR";
            transport[(int)Job.TYPE.SUBWAY_WORKER] = "TRABAJADOR DEL METRO";
            transport[(int)Job.TYPE.OFFICE_WORKER] = "OFICINISTA";
            transport[(int)Job.TYPE.EXECUTIVE_OFFICER] = "DIRECTOR EJECUTIVO";
        }
    }
}
