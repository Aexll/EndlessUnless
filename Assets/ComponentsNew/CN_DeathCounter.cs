using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CN_DeathCounter : MonoBehaviour
{
    public intc deaths;
    public UnityEvent<string> OnChangeText;

    private void OnEnable()
    {
        deaths.OnChange += (int i) =>
        {
            OnChangeText.Invoke(i.ToString());
        };
    }

    public void newDeath()
    {
        deaths.Value++;
    }

    public void clearDeath()
    {
        deaths.Value = 0;
    }
}
