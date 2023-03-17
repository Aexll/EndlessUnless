using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SO_BaseContainer<T> : ScriptableObject
{
    public Action<T> OnChange;
    private T containedValue;
    public T Value
    {
        get { return containedValue; }
        set
        {
            containedValue = value;
            OnChange?.Invoke(value);
        }
    }

    /* Experimental

    public static implicit operator T(SO_BaseContainer<T> obj)
    {
        return obj.Value;
    }

    public static SO_BaseContainer<T> operator +(SO_BaseContainer<T> obj, T value)
    {
        obj.Value = (dynamic)obj.Value + value;
        return obj;
    }

    public static SO_BaseContainer<T> operator -(SO_BaseContainer<T> obj, T value)
    {
        obj.Value = (dynamic)obj.Value - value;
        return obj;
    }

    */

}



