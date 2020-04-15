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
    // Private Variables //
    ///////////////////////

    protected static int idCounter = 0;

    ///////////////////////
    // Public Properties //
    ///////////////////////

    public bool Satisfied 
    {
        get { return IsSatisfied(); } 
        private set { return; } 
    }
    public int ID { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public Condition() { ID = idCounter++; }

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

    public override string ToString() => "Condición[" + ID + "](" + Satisfied + ")";
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
    public Index.STATE TargetState { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexCondition(Index conditioner, Index.STATE targetState) : base()
    {
        Conditioner = conditioner;
        TargetState = targetState;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Índice condicionante[" + Conditioner.ID + "] : TargetState(" + TargetState + ")";

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

/// <summary>
/// This kind of conditions have an Object's attribute as the conditioner
/// </summary>
/// <typeparam name="T">Type of the conditioner atributeiu</typeparam>
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

    public AttributeCondition(Func<T> conditionerGetter, T conditionerTriggerValue) : base()
    {
        this.conditionerGetter = conditionerGetter;
        this.conditionerTriggerValue = conditionerTriggerValue;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Atributo condicionante[" + typeof(T) + "]" + " : TriggerValue(" + conditionerTriggerValue + ")";

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

    public Index Affected { get; private set; }
    public Index.CHANGE Change { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexToIndexCondition(Index conditioner, Index affected, Index.STATE state, Index.CHANGE change) : base(conditioner, state)
    {
        Affected = affected;
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
            Affected.ChangeIndexValue(Change);
            return true;
        }
        return false;
    }

    public override string ToString() => base.ToString() + " | Índice Afectado[" + Affected.ID + "](" + Change + ")";
}

/// <summary>
/// This kind of condition have an Object's attribute as the conditioner and another Object's attribute as the conditioned
/// </summary>
public abstract class AttributeToAtributeCondition<T, V> : AttributeCondition<T>
{
    ///////////////////////
    // Private Variables //
    ///////////////////////

    protected Action<V> affectedSetter;
    protected V affectedResultValue;

    //////////////////
    // Constructors //
    //////////////////

    public AttributeToAtributeCondition(Func<T> conditionerGetter, Action<V> affectedSetter,
        T conditionerTriggerValue, V affectedResultValue) : base(conditionerGetter, conditionerTriggerValue)
    {
        this.affectedSetter = affectedSetter;
        this.affectedResultValue = affectedResultValue;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Atributo Afectado[" + typeof(T) + "]" + " : ValorReslutado(" + affectedResultValue + ")";

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

    protected Action<T> affectedSetter;
    protected T affectedResultValue;

    //////////////////
    // Constructors //
    //////////////////

    public IndexToAttributeCondition(Index conditioner, Index.STATE state, Action<T> affectedSetter, T affectedResultValue)
        : base(conditioner, state)
    {
        this.affectedSetter = affectedSetter;
        this.affectedResultValue = affectedResultValue;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Atributo Afectado[" + typeof(T) + "]" + " : ValorReslutado(" + affectedResultValue + ")";

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

    public Index Affected { get; private set; }
    public Index.CHANGE Change { get; private set; }


    //////////////////
    // Constructors //
    //////////////////

    public AttributeToIndexCondition(Func<T> conditionerGetter, T conditionerTriggerValue, Index affected, Index.CHANGE change)
        : base(conditionerGetter, conditionerTriggerValue)
    {
        Affected = affected;
        Change = change;
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override string ToString() => base.ToString() + " | Índice Afectado[" + Affected.ID + "](" + Change + ")";

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

    protected override bool IsSatisfied() { return Affected.GetIndexState() == TargetState; }
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

    protected override bool IsSatisfied() { return Affected.GetIndexState() >= TargetState; }
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
    /// <param name="affected">Conditioned Index</param>
    /// <param name="state">The state the conditioner has to reach to satisfy the condition</param>
    /// <param name="change"> The change that will be applied to the conditioned</param>
    public IndexToIndexSinkStateCondition(Index conditioner, Index affected, Index.STATE state, Index.CHANGE change)
        : base(conditioner, affected, state, change)
    { }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied() { return Affected.GetIndexState() <= TargetState; }
}

/// <summary>
/// This is a kind of AttributeToAttributeCondition where the condition is satisfied when de conditioner takes the TriggerValue
/// </summary>
/// <typeparam name="T">Type of the conditioner attribute</typeparam>
/// <typeparam name="V">Type of the affected attribute</typeparam>
public class AttributeToAtributeValueCondition<T, V> : AttributeToAtributeCondition<T, V>
{
    //////////////////
    // Constructors //
    //////////////////

    public AttributeToAtributeValueCondition(Func<T> conditionerGetter, Action<V> affectedSetter,
        T conditionerTriggerValue, V affectedResultValue)
        : base(conditionerGetter, affectedSetter, conditionerTriggerValue, affectedResultValue)
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
            affectedSetter(affectedResultValue);
            return true;
        }
        return false;
    }
}