using System.Collections;
using System.Collections.Generic;

public class Transport 
{
    public enum TYPE
    {
        CAR = 0,
        BIKE = 1,
        FEET = 2,
        TRAIN = 3
    }

    TYPE transportType;
    // Type of the transport
    public TYPE TransportType
    {
        get { return transportType; }
        set { transportType = value; }
    }
    Index safety;
    // Is it healthy and safe to use it? [0..1]
    public Index Safety
    {
        get { return safety; }
        set { if (value.Value > 0 && value.Value <= 1) safety = value; }
    }
    float speed;
    // Does it take too long? [> 0 (Divides the default travel time by walk)]
    public float Speed
    {
        get { return speed; }
        set { if (value > 0) speed = value; }
    }
    // How many people can use it at the same time
    int capacity;
    public int Capacity
    {
        get { return capacity; }
        set { if (value > 0) capacity = value; }
    }
    Index polluting;

    // How much does the transport pollute the air and noise [0..1]
    public Index Polluting
    {
        get { return polluting; }
        set { if (value.Value > 0 && value.Value <= 1) polluting = value; }
    }
    public Transport()
    {
        TransportType = TYPE.FEET;
        Safety = new Index("Safety", "Represents the safety of walking", 0.5f);
        Capacity = 100;
        Speed = 1f;
        Polluting = new Index("Safety", "Represents how much polluting is to walk", 0.5f);
    }
    public Transport(TYPE transportType, Index safety, int capacity, float speed, Index polluting)
    {
        TransportType = transportType;
        Safety = safety;
        Capacity = capacity;
        Speed = speed;
        Polluting = polluting;
    }
}
