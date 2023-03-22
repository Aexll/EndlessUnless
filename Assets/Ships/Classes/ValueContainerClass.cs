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

[Serializable]
public class intcc : ValueContainerClass<int,intc> {
    public int valueL = 0;
    public intc valueC;
};

[Serializable]
public class intccc
{
    public int valueL = 0;
    public intc valueC;

    public int Value
    {
        get {
            if (valueC != null) return valueC.Value;
            else return valueL;
        }
        set
        {
            if(valueC != null) { valueC.Value = value; }
            else { valueL = value; }
        }
    }

}



public class floatcc : ValueContainerClass<float,floatc> { };
public class boolcc : ValueContainerClass<bool,boolc> { };
public class stringcc : ValueContainerClass<string,stringc> { };
