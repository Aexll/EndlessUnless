using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_OnReset : MonoBehaviour, IResetable
{
    public UnityEvent OnReset;

    public void Reseting()
    {
        OnReset?.Invoke();
    }
}
