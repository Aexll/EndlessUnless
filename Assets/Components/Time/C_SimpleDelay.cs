using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_SimpleDelay : MonoBehaviour, IResetable
{
    [SerializeField] private bool autoActivate = true;
    [SerializeField] private float delay = 1f;
    [SerializeField] private bool loop = false;
    public UnityEvent OnTrigger;

    private void Start()
    {
        if(autoActivate)
        {
            _StartDelay();
        }
    }

    public void _StartDelay()
    {
        CancelInvoke();
        Invoke(nameof(Trigger),delay);
    }

    public void _StopDelay()
    {
        CancelInvoke();
    }

    public void Trigger()
    {
        OnTrigger?.Invoke();
        if (loop) _StartDelay();
    }

    public void Reseting()
    {
        // print("Hello");
        CancelInvoke();
        if(autoActivate)
        {
            _StartDelay();
        }
    }
}
