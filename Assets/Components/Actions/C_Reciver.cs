using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_Reciver : MonoBehaviour
{
    public SO_Action ToListen;

    public UnityEvent OnRecive;

    private void _a()
    {
        OnRecive?.Invoke();
    }

    private void OnEnable()
    {
        ToListen.OnTrigger.AddListener(_a);
    }

    private void OnDisable()
    {
        ToListen.OnTrigger.RemoveListener(_a);
    }
}
