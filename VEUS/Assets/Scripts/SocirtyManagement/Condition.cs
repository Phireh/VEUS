using System;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////////////
// DEFINITION OF THE ABSTRACT CLASSES //
////////////////////////////////////////

/// <summary>
/// Every condition has the ApplyCondition() methd that returns true if the condition
/// is satisfied when called. The body of this method corresponds to te Condition effects
/// </summary>
public abstract class Condition
{

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public bool Satisfied 
    {
        get { return IsSatisfied(); } 
        private set { return; } 
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected abstract bool IsSatisfied();

    ////////////////////
    // Public Methods //
    ////////////////////

    /// <summary>
    /// Applys the effects of the condition if it's satisfied
    /// </summary>
    /// <returns>True if the condition is satisfied. False otherwise</returns>
    public abstract bool ApplyCondition();

}

/// <summary>
/// This kind of conditions have an Index as the conditioner
/// </summary>
public abstract class IndexCondition : Condition
{
    ///////////////////////
    // Public Properties //
    ///////////////////////

    public Index Conditioner { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexCondition(Index conditioner)
    {
        Conditioner = conditioner;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

/// <summary>
/// This kind of condition have an Index as the conditioner and another Index as the conditioned
/// If the condition is satisfied the conditioned index changes its value
/// </summary>
public abstract class IndexToIndexCondition : IndexCondition
{
    ///////////////////////
    // Public Properties //
    ///////////////////////

    public Index Conditioned { get; private set; }
    public Index.STATE TargetState { get; private set; }
    public Index.CHANGE Change { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexToIndexCondition(Index conditioner, Index conditioned, Index.STATE state, Index.CHANGE change) : base(conditioner)
    {
        Conditioned = conditioned;
        TargetState = state;
        Change = change;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();

    ////////////////////
    // Public Methods //
    ////////////////////

    public override bool ApplyCondition()
    {
        if (Satisfied)
        {
            Conditioned.ChangeIndexValue(Change);
            return true;
        }
        return false;
    }
}

/// <summary>
/// This kind of conditions have an Object's attribute as the conditioner
/// </summary>
public abstract class AttributeCondition<T> : Condition
{

    ///////////////////////
    // Private Variables //
    ///////////////////////

    protected Func<T> conditionerGetter;
    protected T conditionerTriggerValue;

    //////////////////
    // Constructors //
    //////////////////

    public AttributeCondition(Func<T> conditionerGetter, T conditionerTriggerValue)
    {
        this.conditionerGetter = conditionerGetter;
        this.conditionerTriggerValue = conditionerTriggerValue;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

/// <summary>
/// This kind of condition have an Object's attribute as the conditioner and another Object's attribute as the conditioned
/// </summary>
public abstract class AttributeToAtributeCondition<T, V> : AttributeCondition<T>
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    Action<V> conditionedSetter;
    V conditionedResultValue;

    //////////////////
    // Constructors //
    //////////////////

    public AttributeToAtributeCondition(Func<T> conditionerGetter, Action<V> conditionedSetter,
        T conditionerTriggerValue, V conditionedResultValue) : base(conditionerGetter, conditionerTriggerValue)
    {
        this.conditionedSetter = conditionedSetter;
        this.conditionedResultValue = conditionedResultValue;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();

}

/// <summary>
/// This kind of condition have an Index as the conditioner and an Object's attribute as the conditioned
/// </summary>
public abstract class IndexToAttributeCondition<T> : IndexCondition
{

    ///////////////////////
    // Private Variables //
    ///////////////////////

    protected Action<T> conditionedSetter;
    protected T conditionedResultValue;

    //////////////////
    // Constructors //
    //////////////////

    public IndexToAttributeCondition(Index conditioner, Action<T> conditionedSetter, T conditionedResultValue)
        : base(conditioner)
    {
        this.conditionedSetter = conditionedSetter;
        this.conditionedResultValue = conditionedResultValue;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

/// <summary>
/// This kind of condition have an Object's attribute and an Index as the conditioned
/// </summary>
public abstract class AttributeToIndexCondition<T> : AttributeCondition<T>
{

    ///////////////////////
    // Private Variables //
    ///////////////////////

    public Index Conditioned { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public AttributeToIndexCondition(Func<T> conditionerGetter, T conditionerTriggerValue, Index conditioned)
        : base(conditionerGetter, conditionerTriggerValue)
    {
        Conditioned = conditioned;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

///////////////////////////////////
// IMPLEMENTATION OF THE CLASSES //
///////////////////////////////////

/// <summary>
/// This is a kind of IndexToIndexCondition where the condition is satisfied if the conditioner Index state is exactly equal to the TriggerState
/// </summary>
public class IndexToIndexStateCondition : IndexToIndexCondition
{
    //////////////////
    // Constructors //
    //////////////////

    /// <summary>
    /// Creates an IndexToIndexStateCondition
    /// </summary>
    /// <param name="conditioner">Conditioner Index</param>
    /// <param name="conditioned">Conditioned Index</param>
    /// <param name="state">The state the conditioner has to reach to satisfy the condition</param>
    /// <param name="change"> The change that will be applied to the conditioned</param>
    public IndexToIndexStateCondition(Index conditioner, Index conditioned, Index.STATE state, Index.CHANGE change)
        : base(conditioner, conditioned, state, change)
    { }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied() { return Conditioned.GetIndexState() == TargetState; }
}

/// <summary>
/// This is a kind of IndexToIndexCondition where the condition is satisfied if the conditioner Index is equal or greater than the TriggerState
/// </summary>
public class IndexToIndexReachStateCondition : IndexToIndexCondition
{
    //////////////////
    // Constructors //
    //////////////////

    /// <summary>
    /// Creates an IndexToIndexStateCondition
    /// </summary>
    /// <param name="conditioner">Conditioner Index</param>
    /// <param name="conditioned">Conditioned Index</param>
    /// <param name="state">The state the conditioner has to reach to satisfy the condition</param>
    /// <param name="change"> The change that will be applied to the conditioned</param>
    public IndexToIndexReachStateCondition(Index conditioner, Index conditioned, Index.STATE state, Index.CHANGE change)
        : base(conditioner, conditioned, state, change)
    { }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied() { return Conditioned.GetIndexState() >= TargetState; }
}

/// <summary>
/// This is a kind of IndexToIndexCondition where the condition is satisfied if the conditioner Index is equal or greater than the TriggerState
/// </summary>
public class IndexToIndexSinkStateCondition : IndexToIndexCondition
{
    //////////////////
    // Constructors //
    //////////////////

    /// <summary>
    /// Creates an IndexToIndexStateCondition
    /// </summary>
    /// <param name="conditioner">Conditioner Index</param>
    /// <param name="conditioned">Conditioned Index</param>
    /// <param name="state">The state the conditioner has to reach to satisfy the condition</param>
    /// <param name="change"> The change that will be applied to the conditioned</param>
    public IndexToIndexSinkStateCondition(Index conditioner, Index conditioned, Index.STATE state, Index.CHANGE change)
        : base(conditioner, conditioned, state, change)
    { }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied() { return Conditioned.GetIndexState() <= TargetState; }
}

public class AttributeToAtributeValueCondition<T, V> : AttributeToAtributeCondition<T, V>
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    Action<V> conditionedSetter;
    V conditionedResultValue;

    //////////////////
    // Constructors //
    //////////////////

    public AttributeToAtributeValueCondition(Func<T> conditionerGetter, Action<V> conditionedSetter,
        T conditionerTriggerValue, V conditionedResultValue)
        : base(conditionerGetter, conditionedSetter, conditionerTriggerValue, conditionedResultValue)
    { }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied()
    {
        return (conditionerTriggerValue.Equals(conditionerGetter()));
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override bool ApplyCondition()
    {
        if (Satisfied)
        {
            conditionedSetter(conditionedResultValue);
            return true;
        }
        return false;
    }
}