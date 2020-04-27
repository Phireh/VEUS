using System;
using System.Collections;
using System.Collections.Generic;

public class TransportSector
{
    //////////////////////
    // Static Component //
    //////////////////////

    public struct TransportPlan
    {
        public int TimeRequiered { get; set; }
        public Transport.TYPE Transport { get; set; }
        public float Safety { get; set; }
        public TransportPlan(Transport.TYPE transport, float safety, int time)
        {
            Transport = transport; Safety = safety; TimeRequiered = time;
        }
    }

    ///////////////////////
    // Private variables //
    ///////////////////////

    int[] freeSpaces;
    int transportsCount;

    ///////////////////////
    // Public Component //
    ///////////////////////

    public CityPart.PLACE CityPlace { get; private set; }
    public Transport[] Transports { get; private set; }
    public ConditionableIndex Investment { get; private set; }
    public ConditionableIndex Technology { get; private set; }
    public RepresentativeIndex SectorPollution { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public TransportSector(float technologyValue, float investmentValue, CityPart.PLACE cityPlace)
    {
        CityPlace = cityPlace;
        Technology = new ConditionableIndex("Tecnología", "Nivel de la tecnología de los transportes en el barrio "
            + Global.Names.cityPart[(int)cityPlace], technologyValue);
        Investment = new ConditionableIndex("Inversión", "Nivel de inversión dirigida a los transportes en el barrio "
            + Global.Names.cityPart[(int)cityPlace], investmentValue);
        SectorPollution = new RepresentativeIndex("Contaminación del sector", "Nivel de contaminación producida por los transportes en el barrio "
            + Global.Names.cityPart[(int)cityPlace], 0.5f);

        transportsCount = Enum.GetNames(typeof(Transport.TYPE)).Length;
        Transports = new Transport[transportsCount];
        freeSpaces = new int[transportsCount];

        Transports[(int)Transport.TYPE.ROAD]
            = new Transport(Transport.TYPE.ROAD, Transport.EXPANSION.NONE, Transport.ENHANCEMENTS.NONE, cityPlace);
        Transports[(int)Transport.TYPE.SUBWAY]
            = new Transport(Transport.TYPE.SUBWAY, Transport.EXPANSION.NONE, Transport.ENHANCEMENTS.NONE, cityPlace);
        Transports[(int)Transport.TYPE.CYCLE_LANE]
            = new Transport(Transport.TYPE.CYCLE_LANE, Transport.EXPANSION.NONE, Transport.ENHANCEMENTS.NONE, cityPlace);
        Transports[(int)Transport.TYPE.STREET]
            = new Transport(Transport.TYPE.STREET, Transport.EXPANSION.NONE, Transport.ENHANCEMENTS.NONE, cityPlace);
        
        ResetFreeSpaces();
    }

    ////////////////////////
    /// Auxiliar Methods ///
    ////////////////////////

    int GetTravelTime(int distance, Transport t) => (int)Math.Ceiling(distance / t.Speed);

    //////////////////////
    /// Public Methods ///
    //////////////////////

    public int GetFreeSpaces(Transport.TYPE type) => freeSpaces[(int)type];
    public TransportPlan GeFastest(int distance, int maxTime)
    {
        TransportPlan fastest = new TransportPlan(Transport.TYPE.NONE, -1, -1);
        float speedValueMax = 0f;
        int iteration = 0;
        foreach (Transport t in Transports)
        {
            if (iteration++ < 1) continue;
            int timeRequiered = GetTravelTime(distance, t);
            if (t.Speed > speedValueMax
                && freeSpaces[(int)t.TransportType] > 0
                && timeRequiered <= maxTime)
            {
                fastest.Transport = t.TransportType;
                fastest.Safety = t.Safety.Value;
                fastest.TimeRequiered = timeRequiered;
                speedValueMax = fastest.Safety;
            }
        }
        freeSpaces[(int)fastest.Transport]--;
        return fastest;
    }

    public TransportPlan GetSafest(int distance, int maxTime)
    {
        TransportPlan safest = new TransportPlan(Transport.TYPE.NONE, -1, -1);
        float safestValue = 0f;
        int iteration = 0;
        foreach (Transport t in Transports)
        {
            if (iteration++ < 1) continue;
            int timeRequiered = GetTravelTime(distance, t);
            if (t.Safety.Value > safestValue
                && freeSpaces[(int)t.TransportType] > 0
                && timeRequiered <= maxTime)
            {
                safest.Transport = t.TransportType;
                safest.Safety = t.Safety.Value;
                safest.TimeRequiered = timeRequiered;
                safestValue = safest.Safety;
            }
        }
        freeSpaces[(int)safest.Transport]--;
        return safest;
    }

    public TransportPlan GetLeastPolluting(int distance, int maxTime)
    {
        TransportPlan leastPolluting = new TransportPlan(Transport.TYPE.NONE, -1, -1);
        float pollutionValue = 1f;
        int iteration = 0;
        foreach (Transport t in Transports)
        {
            if (iteration++ < 1) continue;
            int timeRequiered = GetTravelTime(distance, t);
            if (t.Safety.Value < pollutionValue
                && freeSpaces[(int)t.TransportType] > 0
                && timeRequiered <= maxTime)
            {
                leastPolluting.Transport = t.TransportType;
                leastPolluting.Safety = t.Safety.Value;
                leastPolluting.TimeRequiered = timeRequiered;
                pollutionValue = t.Safety.Value;
            }
        }
        freeSpaces[(int)leastPolluting.Transport]--;
        return leastPolluting;
    }

    public void ResetFreeSpaces()
    {
        freeSpaces[0] = 0;
        for (int i = 1; i < transportsCount; i++)
            freeSpaces[i] = Transports[i].Capacity;
    }

    public void ProcessDay()
    {
        float pollutionVal = 0f;
        int iteration = 0;
        foreach (Transport t in Transports)
        {
            if (iteration++ < 1) continue;
            pollutionVal += t.Polluting.Value;
        }
        SectorPollution.Value = pollutionVal / iteration;
    }

    public override string ToString()
    {
        string res = "";
        res += "Free Spaces:\n";
        for (int i = 1; i < transportsCount; i++) res += (Transport.TYPE)i + ": " + freeSpaces[i] + "   ";
        res += "\n" + Investment.ToString() + "\n";
        res += Technology.ToString() + "\n";
        res += "All transport options:\n==========================================\n";
        foreach (Transport t in Transports) if (t!=null) res += t.ToString() + "\n";
        return res;
    }
}
