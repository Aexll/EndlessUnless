using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RBReset : MonoBehaviour,IResetable
{
    public Rigidbody2D rb;

    public void Reseting()
    {
        rb.velocity= Vector3.zero;
        rb.angularVelocity = 0;
    }

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }


}
