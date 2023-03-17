using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

// event leaf does the same job !
/*public struct EventAtInt
{
    public int integer;
    public UnityEvent ev;
}*/


public class C_Counter : MonoBehaviour, IResetable
{
    public int defaultCounter = 0;
    public int counter = 0;
    public int Counter
    {
        get { return counter; }
        set {
            if (value != counter) {
                OnCouterChanged?.Invoke(value);
                UnityEvent ev;

                if(eventsByTime.TryGetValue(value,out ev))
                {
                    ev?.Invoke();
                }
            }
            counter = value;
        }

    }

    public UnityEvent<int> OnCouterChanged;
    public List<EventLeaf> events;
    Dictionary<int, UnityEvent> eventsByTime = new Dictionary<int, UnityEvent>();

    private void Awake()
    {
        foreach (var item in events)
        {
            eventsByTime.Add(item.time, item.ev);
        }

        Counter = defaultCounter;
    }

    public void _PlusOne() { Counter++; }

    public void _MinusOne() { Counter--; }

    public void _Plus(int amount) { Counter += amount; }

    public void _Minus(int amount) { Counter -= amount; }

    public void _Reset() { Counter = defaultCounter; }

    public void Reseting()
    {
        _Reset();
    }
}
