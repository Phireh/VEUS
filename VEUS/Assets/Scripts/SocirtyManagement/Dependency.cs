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
    public Index Influencer { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public Dependency(Index influencer, int influence)
    {
        Influencer = influencer;
        Influence = influence;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    protected abstract float GetRealInfluence();
}

public class SubstractionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return - (Influence * Influencer.Value) / 100f;
    }

    public SubstractionDependency(Index influencer, int influence) : base(influencer, influence) { }
}

public class AdditionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return (Influence * Influencer.Value) / 100f;
    }

    public AdditionDependency(Index influencer, int influence) : base(influencer, influence) { }
}

public class ReverseSubstractionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return - (Influence - Influence * Influencer.Value) / 100f;
    }

    public ReverseSubstractionDependency(Index influencer, int influence) : base(influencer, influence) { }
}

public class ReverseAdditionDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        return (Influence - Influence * Influencer.Value) / 100f;
    }

    public ReverseAdditionDependency(Index influencer, int influence) : base(influencer, influence) { }
}

public class SameTendencyDependency : Dependency
{
    protected override float GetRealInfluence()
    {
        float ri = 0f;
        if (Influencer.Value > 0.5f) ri = 1f;
        else if (Influencer.Value < 0.5f) ri = -1f;
        ri *= Influencer.Value * Influence / 100f;
        return ri;
    }

    public SameTendencyDependency(Index influencer, int influence) : base(influencer, influence) { }
}
