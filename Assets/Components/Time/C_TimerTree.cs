using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct EventLeaf
{
    public int time;
    public UnityEvent ev;
}

public class C_TimerTree : MonoBehaviour, IResetable
{
    [SerializeField] private bool autoStart = true;
    [SerializeField] private float deltaTime = 0.1f;
    [SerializeField] private int loopingTime = -1;
    [SerializeField] private List<EventLeaf> events;

    private bool isActive = false;
    private int t = 0;
    private Dictionary<int, UnityEvent> builtEvents = new Dictionary<int, UnityEvent>();
    private Coroutine coroutine;

    private void Awake()
    {
        foreach (var item in events)
        {
            builtEvents.Add(item.time,item.ev);
        }
    }

    private void Start()
    {
        if(autoStart) _Activate();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        coroutine = StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator Timer()
    {
        while(true)
        {
            if(isActive)
            {
                Tick(t);
                yield return new WaitForSeconds(deltaTime);
                t++;
                if (loopingTime > 0)
                {
                    t = t % loopingTime;
                }
            }
            else yield return null;
        }
    }

    public void Tick(int i)
    {
        //print(i);
        if(builtEvents.ContainsKey(i))
            builtEvents[i].Invoke();
    }

    public void _Activate()
    {
        isActive = true;
    }

    public void _Deactivate()
    {
        isActive = false;
    }

    public void Reseting()
    {
        t = 0;
        if(autoStart) _Activate();
        else _Deactivate();
    }
}
