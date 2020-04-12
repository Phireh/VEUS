using System;
using System.Collections;
using System.Collections.Generic;

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

    public abstract bool ApplyCondition();

}

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

public abstract class IndexToIndexCondition : IndexCondition
{
    ///////////////////////
    // Public Properties //
    ///////////////////////

    public Index Conditioned { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexToIndexCondition(Index conditioner, Index conditioned) : base(conditioner)
    {
        Conditioned = conditioned;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

unsafe public struct AttributeAndValor<T>
{
    public T* atr;
    public T* val;

    public AttributeAndValor(T atr, ref T val)
    {
        this.atr = *atr;
        this.val = *val;
    }
}

public abstract class IndexToAttributeCondition<T> : IndexCondition
{
    public AttributeAndValor<T> Result { get; private set; }

    public IndexToAttributeCondition(Index conditioner, AttributeAndValor<T> result) : base(conditioner)
    {
        Result = result;
    }

    //////////////////////
    // Abstract Methods //
    //////////////////////

    protected override abstract bool IsSatisfied();
    public override abstract bool ApplyCondition();
}

public class IndexToIndexStateCondition : IndexToIndexCondition
{
    ///////////////////////
    // Public Properties //
    ///////////////////////

    public Index.STATE TargetState { get; private set; }
    public Index.CHANGE Change { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public IndexToIndexStateCondition(Index conditioner, Index conditioned, Index.STATE state, Index.CHANGE change)
        : base(conditioner, conditioned)
    {
        TargetState = state;
        Change = change;
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied() { return Conditioned.GetIndexState() == TargetState; }

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


public class AttributeToAtributeStateCondition<T> : Condition
{
    ///////////////////////
    // Public Properties //
    ///////////////////////

    public AttributeAndValor<Enum> Condition { get; private set; }
    public AttributeAndValor<T> Result { get; private set; }

    //////////////////
    // Constructors //
    //////////////////

    public AttributeToAtributeStateCondition(AttributeAndValor<Enum> condition, AttributeAndValor<T> result)
    {
        Condition = condition;
        Result = result;
    }

    //////////////////////
    // Auxiliar Methods //
    //////////////////////

    protected override bool IsSatisfied()
    {
        return (Condition.atr.Equals(Condition.val));
    }

    ////////////////////
    // Public Methods //
    ////////////////////

    public override bool ApplyCondition()
    {
        if (Satisfied)
        {
            Result.atr = Result.val;
            return true;
        }
        return false;
    }
}