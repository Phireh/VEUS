using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Change
{
    public Change()
    { }

    public abstract void ApplyChange();
}

public class ValueChange<T> : Change
{
    public Action<T> Setter { get; private set; }
    public T NewValue { get; private set; }

    public ValueChange(Action<T> setter, T newValue) : base()
    {
        Setter = setter;
        NewValue = newValue;
    }

    public override void ApplyChange() => Setter(NewValue);
    public override string ToString() => "Setter: " + Setter.ToString() + " | Value: " + NewValue.ToString();
}

public class IndexChange : Change
{
    public Index Target { get; private set; }
    public Index.CHANGE Change { get; private set; }
    public IndexChange(Index target, Index.CHANGE change) : base()
    {
        Target = target;
        Change = change;
    }
    public override void ApplyChange()
    {
        Target.ChangeIndexValue(Change);
    }
    public override string ToString() => "Target:\n" + Target + "\nChange: " + Change;
}