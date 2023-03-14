using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ResetableDestroy : MonoBehaviour, IResetable
{

    public GameObject toDeactivate;

    private void Awake()
    {
        if(toDeactivate == null)
        {
            toDeactivate = gameObject;
        }
    }

    public void TempDeactivate()
    {
        toDeactivate.SetActive(false);
    }

    public void Reseting()
    {
        toDeactivate.SetActive(true);
    }
}
