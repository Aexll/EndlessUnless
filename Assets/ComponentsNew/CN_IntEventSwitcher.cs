using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CN_IntEventSwitcher : MonoBehaviour
{
    public List<UnityEvent> eventlist;
    public intc currentValue;

    private void Awake()
    {
        currentValue.OnChange += (int newValue) =>
        {
            if (eventlist.Count > newValue)
            {
                //print();
                eventlist[newValue].Invoke();
            }
        };
    }
}
