using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AutoDestroy : MonoBehaviour, IResetable
{

    public float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DoDestroy), delay); 
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }

    public void Reseting()
    {
        Destroy(gameObject);
    }
}
