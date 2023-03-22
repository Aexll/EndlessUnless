using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class ValueContainerClass<C,SO> : MonoBehaviour where SO : SO_ValueContainer<C>
{
    C valueLocal;
    SO valueContainer;

    C Value
    {
        get {
            if (valueContainer != null) return (valueContainer).Value;
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


public class intcc : ValueContainerClass<int,intc> { };
public class floatcc : ValueContainerClass<float,floatc> { };
public class boolcc : ValueContainerClass<bool,boolc> { };
public class stringcc : ValueContainerClass<string,stringc> { };
