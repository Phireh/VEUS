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
    public override string ToString() => "Setter: " + Setter.ToString() + "Value: " + NewValue.ToString();
}
