using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RbHandler : MonoBehaviour, IResetable
{
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void Reseting()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }
}
