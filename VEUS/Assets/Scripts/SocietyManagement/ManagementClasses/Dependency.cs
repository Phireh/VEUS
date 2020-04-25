using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Dependency
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    int influence;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    /// <summary>
    /// The power the influencer can apply to the influenced
    /// </summary>
    public int Influence
    {
        get { return influence; }
        set
        {
            if (value < 0) influence = 0;
            else if (value > 100) influence = 100;
            else influence = value;
        }
    }
    /// <summary>
    /// The change that the influencer produced in the influenced
    /// </summary>
    public float RealInfluence
    {
        get { return GetRealInfluence(); }
        private set { return; }
    }
    public Index From { get; private set; }
    public Index To { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public Dependency(Index from, Index to, int influence)
    {
        From = from;
        To = to;
        Influence = influence;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected abstract float GetRealInfluence();

    ////////////////////
    // Public Methods //
    ////////////////////
    
    public float ApplyInfluence()
    {
        float realInfluece = GetRealInfluence();
        To.Value += GetRealInfluence();
        return realInfluece;
    }

    public override string ToString() => "De " + From.Name + "[]" + From.ID +"(" + influence + ") A " + To.Name + "[]" + To.ID + "InfluenciaReal(" + RealInfluence + ")";
}

public class SubstractionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return - (Influence * From.Value) / 100f;
    }

    public SubstractionDependency(Index from, Index to, int influence) : base(from, to, influence) { }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Substracción";
}

public class AdditionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return (Influence * From.Value) / 100f;
    }

    public AdditionDependency(Index from, Index to, int influence) : base(from, to, influence) { }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Adición";
}

public class ReverseSubstractionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return - (Influence - Influence * From.Value) / 100f;
    }

    public ReverseSubstractionDependency(Index from, Index to, int influence) : base(from, to, influence) { }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Substracción Inversa";
}

public class ReverseAdditionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return (Influence - Influence * From.Value) / 100f;
    }

    public ReverseAdditionDependency(Index from, Index to, int influence) : base(from, to, influence) { }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Adición Inversa";
}

public class SameTendencyDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        float ri = 0f;
        if (From.Value > 0.5f) ri = 1f;
        else if (From.Value < 0.5f) ri = -1f;
        ri *= From.Value * Influence / 100f;
        return ri;
    }

    public SameTendencyDependency(Index from, Index to, int influence) : base(from, to, influence) { }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Misma Tendencia";
}
