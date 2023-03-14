using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct DelayEvent
{
    public float time;
    public UnityEvent<string> actionWithText;
}

public class C_Delayer : MonoBehaviour, IResetable
{

    public bool AutoStart = false;
    public float AutoStartTime = 1f;
    public bool Loop = false;


    public UnityEvent<float> WhileDelay;
    public UnityEvent<string> WhileDelayAsText;
    public UnityEvent OnTrigger;

    public List<DelayEvent> DelayEvents;
    public Dictionary<DelayEvent,bool> builtDelayEvents= new Dictionary<DelayEvent,bool>();

    private Coroutine coroutine;
    private float remainingTime;
    public float RemainingTime
    {
        get { return remainingTime; }
        set
        {
            remainingTime = value;
        }
    }

    private void Awake()
    {
        foreach (var item in DelayEvents)
        {
            builtDelayEvents.Clear();
            builtDelayEvents.Add(item, true);
        }
    }

    void Start()
    {
        if(AutoStart)
        {
            StartTimer(AutoStartTime);
        }
    }

    public void ResetTimer()
    {
        StartTimer(AutoStartTime);
    }

    public void StartTimer(float time)
    {
        if(coroutine!= null)
        {
            StopCoroutine(coroutine);
        }
        AutoStartTime= time;
        ResetEvents();
        remainingTime = time;
        coroutine = StartCoroutine(Timer());
    }

    public void StopTimer()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void ResetEvents()
    {
        foreach (var item in DelayEvents)
        {
            builtDelayEvents[item] = false;
        }
    }

    IEnumerator Timer()
    {
        while(remainingTime> 0)
        {
            foreach (var ev in DelayEvents)
            {
                if(!builtDelayEvents[ev] && remainingTime<ev.time)
                {
                    ev.actionWithText.Invoke(String.Format("{0:0.00}", remainingTime));
                    builtDelayEvents[ev]= true;
                }
            }

            WhileDelay.Invoke(remainingTime);
            WhileDelayAsText.Invoke(String.Format("{0:0.00}", remainingTime));
            yield return null;
            remainingTime-=Time.deltaTime;
        }
        OnTrigger.Invoke();
        if (Loop)
            Invoke(nameof(ResetTimer), 0);
    }

    public void Reseting()
    {
        remainingTime = AutoStartTime;
        if(AutoStart)
        {
            StartTimer(AutoStartTime);
        }
        else
        {
            StopTimer();
        }

    }
}
