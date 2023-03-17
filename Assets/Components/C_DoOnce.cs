using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_DoOnce : MonoBehaviour, IResetable
{

    public UnityEvent OnTrigger;
    private bool did = false;

    public void _Trigger()
    {
        if(!did)
            OnTrigger?.Invoke();
        did = true;
    }

    public void _Reset()
    {
        did = false;
    }

    public void Reseting()
    {
        _Reset();
    }
}
