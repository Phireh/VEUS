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
    string name;
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
        set { if (value.Value > 0 && value.Value <= 1) health = value; }
    }
    Index happiness;
    public Index Happiness
    {
        get { return happiness; }
        set { if (value.Value > 0 && value.Value <= 1) happiness = value; }
    }
    PLACE livingPlace;
    public PLACE LivingPlace
    {
        get { return livingPlace; }
        set { livingPlace = value; }
    }
    PLACE workingPlace;
    public PLACE WorkingPlace
    {
        get { return workingPlace; }
        set { workingPlace = value; }
    }

    public Citizen()
    {
        name = "Ciudadano";
        Money = 1000;
        Health = new Index("Salud", "Salud de " + name, 0.75f);
        Happiness = new Index("Felicidad", "Felicidad de " + name, 0.75f);
        LivingPlace = PLACE.CENTER;
        WorkingPlace = PLACE.CENTER;
    }

    public Citizen(string name, int money, float healthValue, PLACE livingPlace, PLACE workingPlace)
    {
        this.name = name;
        Money = money;
        Health = new Index("Salud", "Salud de " + name,healthValue);
        LivingPlace = livingPlace;
        WorkingPlace = workingPlace;
    }
}
