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
    float safety;
    // Is it healthy and safe to use it? [0..1]
    public float Safety
    {
        get { return safety; }
        set { if (value > 0 && value <= 1) safety = value; }
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
    float polluting;

    // How much does the transport pollute the air and noise [0..1]
    public float Polluting
    {
        get { return polluting; }
        set { if (value > 0 && value <= 1) polluting = value; }
    }
    public Transport()
    {
        TransportType = TYPE.FEET;
        Safety = 0.5f;
        Capacity = 100;
        Speed = 1f;
        Polluting = 0.5f;
    }
    public Transport(TYPE transportType, float safety, int capacity, float speed, float polluting)
    {
        TransportType = transportType;
        Safety = safety;
        Capacity = capacity;
        Speed = speed;
        Polluting = polluting;
    }
}
