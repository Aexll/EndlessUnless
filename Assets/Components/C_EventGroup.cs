using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_EventGroup : MonoBehaviour, IResetable
{
    public string groupName;
    public bool triggerOnPlay = false;
    public UnityEvent OnTrigger;

    public void Reseting()
    {
        if(triggerOnPlay)
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        OnTrigger.Invoke();
    }

    private void Start()
    {
        if(triggerOnPlay)
        {
            Trigger();
        }
    }
}
