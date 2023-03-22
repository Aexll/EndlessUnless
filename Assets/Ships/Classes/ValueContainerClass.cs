using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[ Serializable ]
public class ValueContainerClass<C,SO> where SO : SO_ValueContainer<C>
{
    public C valueLocal;
    public SO valueContainer;

    public C Value
    {
        get {
            if (valueContainer != null) return valueContainer.Value;
            else return valueLocal;
        }
        set
        {
            if(valueContainer != null) { valueContainer.Value = value; }
            else { valueLocal = value; }
        }
    }
}


// subclasses

[Serializable] public class intcc : ValueContainerClass<int,intc> { };
[Serializable] public class floatcc : ValueContainerClass<float,floatc> { };
[Serializable] public class boolcc : ValueContainerClass<bool,boolc> { };
[Serializable] public class stringcc : ValueContainerClass<string,stringc> { };
