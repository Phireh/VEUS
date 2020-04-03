using System.Collections;
using System.Collections.Generic;

public enum NATURE
{
    ACTIVE = 0,
    CALM = 1,
    SOCIAL = 2,
    DREAMER = 3
}

public class Citizen
{
    int money;
    public int Money
    {
        get { return money; }
        set { if (value > 0) money = value; }
    }
    Index health;
    public Index Health
    {
        get { return health; }
        set { health = value; }
    }
    PLACE livingPlace;
    public PLACE LivingPlace
    {
        get { return livingPlace; }
        set { livingPlace = value; }
    }
    PLACE workingPlace;
    public PLACE WivingPlace
    {
        get { return workingPlace; }
        set { workingPlace = value; }
    }
}
